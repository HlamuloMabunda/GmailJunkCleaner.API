using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmailJunkCleaner.Domain.Interfaces;

namespace GmailJunkCleaner.Services.Services
{
    public class JunkInboxCleanerService
    {
        private readonly IGmailRepository _gmailRepository;

        public JunkInboxCleanerService(IGmailRepository gmailRepository)
        {
            _gmailRepository = gmailRepository;
        }

        public async Task<int> CleanAsync()
        {
            await _gmailRepository.AuthenticateAsync();
            return await _gmailRepository.DeleteSpamEmailsAsync();
        }
    }
}
