using FirstMVCApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApplication1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<AddAddress> AddAddresses { get; set; }
    }
}
