using Microsoft.EntityFrameworkCore;
using MyApp.Models;


namespace MyApp.DataAccessLayer.data
{
    public class ApplicationDbContext:DbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; } // this will kind of making table in the database table with the columns of categories//
       
    
    }
}
