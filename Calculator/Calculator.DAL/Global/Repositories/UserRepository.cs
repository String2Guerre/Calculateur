using Calculator.DAL.Global.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Global.Repositories
{
    public class UserRepository : BaseRepository<int, User>
    {
        private UserRepository instance;
        public UserRepository Instance
        {
            get { return instance ?? (instance=new UserRepository()); }
        }

        public UserRepository() : base("User") { }



        public override bool Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public override bool Update(User entity)
        {
            throw new NotImplementedException();
        }

        protected override User ReaderToClient(SqlDataReader reader)
        {
            return new User() {
                UserID = (int)reader["userID"],
                Name=reader["name"].ToString(),
                Email=reader["email"].ToString(),
                Pwd=reader["pwd"].ToString(),
                Gender=reader["gender"].ToString(),
                Birthdate=Convert.ToDateTime(reader["birthdate"]),
                InitialWeight=(double)reader["initialWeight"]
            };
        }
    }
}
