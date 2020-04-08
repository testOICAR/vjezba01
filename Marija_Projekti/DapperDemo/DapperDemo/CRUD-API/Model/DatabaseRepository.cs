using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Model
{
    public class DatabaseRepository
    {
        private string connectionString;
        public DatabaseRepository()
        {
            connectionString = @"Server=.\SQLEXPRESS; Database=DapperDemoCRUD; Integrated Security=True;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(Menu menu)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Menu (Place, Type) VALUES(@Place, @Type)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, menu);
            }
        }

        public IEnumerable<Menu> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * From Menu";
                dbConnection.Open();
                return dbConnection.Query<Menu>(sQuery);
            }
        }

        public Menu GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * From Menu Where IDMenu=@Id";
                dbConnection.Open();
                return dbConnection.Query<Menu>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE From Menu Where IDMenu=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Menu menu)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Update Menu SET Place=@Place, Type=@Type Where IDMenu=@IDMenu";
                dbConnection.Open();
                dbConnection.Query(sQuery, menu);
            }
        }
    }
}
