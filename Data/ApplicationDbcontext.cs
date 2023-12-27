using Microsoft.EntityFrameworkCore;
using DemoMVC.Models;
namespace DemoMVC.Data 
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext>options) : base(options)
        {}
        public  DbSet <Person> Person { get; set; }
        public  DbSet <Employee> Employee { get; set; }
         public  DbSet <DaiLy> DaiLy { get; set; }
    }
}