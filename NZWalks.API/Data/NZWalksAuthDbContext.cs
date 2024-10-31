using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksAuthDbContext : IdentityDbContext
    {
        public NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        //Seeding:
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "c2db8f1f-58b8-4250-8b8b-976aa113a3e1";
            var WriterRoleId = "3825df3b-b8b3-47dd-b416-211d36acf356";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=readerRoleId,
                    ConcurrencyStamp=readerRoleId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()

                },
                 new IdentityRole
                {
                    Id=WriterRoleId,
                    ConcurrencyStamp=WriterRoleId,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()

                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
