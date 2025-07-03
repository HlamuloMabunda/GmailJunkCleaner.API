using GmailJunkCleaner.Domain.Interfaces;
using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GmailJunkCleaner.Infrastructure.Repositories
{
    public class GmailRepository : IGmailRepository
    {
        private GmailService _gmailService;
        private const string ApplicationName = "Gmail Junk Cleaner";
        private static readonly string[] Scopes = { GmailService.Scope.GmailModify };

        public async Task AuthenticateAsync()
        {
            UserCredential credential;

            using (var stream = new FileStream("C:\\C# APPS\\GmailJunkCleaner.API\\GmailJunkCleaner.API\\clientsecretfilename.apps.googleusercontent.com.json",FileMode.Open,FileAccess.Read))
            {
                string credPath = "token.json";
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.FromStream(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));
            }

            _gmailService = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public async Task<int> DeleteSpamEmailsAsync()
        {
            var request = _gmailService.Users.Messages.List("me");
            request.LabelIds = "SPAM";
            request.MaxResults = 100;

            var response = await request.ExecuteAsync();
            int deleteCount = 0;

            Console.WriteLine($"📨 Found {response.Messages?.Count ?? 0} spam messages.");

            if (response.Messages != null && response.Messages.Count > 0)
            {
                foreach (var msg in response.Messages)
                {
                    try
                    {
                        Console.WriteLine($"🗑 Deleting message ID: {msg.Id}");
                        await _gmailService.Users.Messages.Trash("me", msg.Id).ExecuteAsync();
                        deleteCount++;
                    }
                    catch (GoogleApiException ex)
                    {
                        Console.WriteLine($"⚠️ Error deleting message {msg.Id}: {ex.Message}");
                    }
                }

                Console.WriteLine($"✅ Deleted {deleteCount} spam messages.");
                return deleteCount;
            }
            else
            {
                Console.WriteLine("📭 0 spam messages: hlamu01mabunda@gmaill.com  .");
                return deleteCount;
            }
        }
    }
}
