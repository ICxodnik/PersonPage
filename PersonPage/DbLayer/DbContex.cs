using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.Entity;
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using System.Data.Entity.Infrastructure;

namespace PersonPage.DbLayer
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class DbContex: DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbContex() : base(MakeConnection(), true)
        {
            Database.SetInitializer<DbContex>(new CreateDatabaseIfNotExists<DbContex>());
        }

        private static DbConnection MakeConnection()
        {
            string connectionString = "server=localhost;uid=client;database=RegistrationPerson;Pwd=clientPassword";
            return new MySqlConnection(connectionString);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
