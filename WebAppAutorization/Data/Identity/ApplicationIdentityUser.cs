using Microsoft.AspNetCore.Identity;

namespace WebAppAutorization.Data.Identity
{
    public class ApplicationIdentityUser : IdentityUser 
    {
        public long ApplicationId { get; set; }
    }
}
