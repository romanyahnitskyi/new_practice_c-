using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReceiptsAPI.Entities;

namespace ReceiptsAPI
{
    public class ReceiptContext : IdentityDbContext<User>
    {
        public DbSet<Receipt> Receipts { get; set; }

        public ReceiptContext(DbContextOptions<ReceiptContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
