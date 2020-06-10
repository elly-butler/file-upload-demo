using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Nexul.Demo.SqlDbServices
{
    public class NexulIdentityDbContext : IdentityDbContext<NexulIdentityUser>
    {
        public NexulIdentityDbContext(DbContextOptions<NexulIdentityDbContext> options) : base(options) { }
        protected NexulIdentityDbContext() : base() { }
    }
}
