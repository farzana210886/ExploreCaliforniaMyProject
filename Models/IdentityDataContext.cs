using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExploreCaliforniaMyProject.Models
{
    public class IdentityDataContext : IdentityDbContext<IdentityUser>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}