using BulkyRAZORWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyRAZORWebApp.Data
{
    //basic config for setting up EntityFramework
    public class ApplicationDbContext : DbContext
    {
        //here we'll pass our ConnectionString to DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  //here whatever config we'll do to options , options then will be passed on to base class of DbContext 
        {
            
        }

        //1.whenever we have to create a table, we have to create a DbSet
        //2.here Category is entity which is our class, we want category model table in out Db
        //3.Categories will be our actual table name in Db
        //4.the below single line will create the table in DB.
        //5.after writing below line,now we've to apply migration(by giving "add-migration Anymsg" in NugetManager Console)
        //6.running the step 5 command will only create the Db in VS, no migrations happened. means no such table created in Db
        //7.we'll run update-database command to actually make the migration happen
        //8.you can see the migration history in dbo_EFMigrationHistory
        public DbSet<Category> Categories { get; set; }

        //now Category table is created in DB, we need to fill it with data.
        //so we'll use Seed functionality to fill our table with data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Action", DisplayOrder = 1},
                    new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2},
                    new Category { Id = 3, Name = "History", DisplayOrder = 3},
                    new Category { Id = 4, Name = "Fiction", DisplayOrder = 4}
            );
        }
    }
}
