using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailJunkCleaner.Domain.Interfaces
{
    public interface IGmailRepository
    {
        Task AuthenticateAsync();
        Task<int> DeleteSpamEmailsAsync();
    }
}
