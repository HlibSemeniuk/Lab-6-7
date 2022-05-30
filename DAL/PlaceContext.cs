using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace DAL
{
    public class PlaceContext : DbContext
    {
        static PlaceContext()
        {
            Database.SetInitializer<PlaceContext>(new PlaceDbInitializer());
        }
        public PlaceContext(string connectionString)
             : base(connectionString)
        {
        }

        public DbSet<Place> Places { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }

    public class PlaceDbInitializer : DropCreateDatabaseAlways<PlaceContext>
    {
        protected override void Seed(PlaceContext db)
        {
            List<Question> questionList = new List<Question>();
            questionList.Add(new Question() { Description = "What is your expression?" });
            db.Places.Add(new Place { Id = 1, Name = "Motherland", Type = "Statue", Questions = questionList });
            db.Places.Add(new Place { Id = 2, Name = "Mariinsky Palace", Type = "Palace" });
            db.SaveChanges();
        }
    }
}