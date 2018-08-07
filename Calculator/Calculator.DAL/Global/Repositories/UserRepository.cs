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
            get { return instance ?? (instance = new UserRepository()); }
        }

        public UserRepository() : base("User") { }



        public override int Insert(User entity)
        {
            SqlCommand cmd = db.CreateCommand();
            cmd.CommandText = $"INSERT INTO {TableName} (name, email, pwd, gender, birthdate, initialWeight) OUTPUT INSERTED.{TableID} VALUES (@name, @email, @pwd, @gender, @birthdate, @initialWeight);";
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("@pwd", entity.Pwd);
            cmd.Parameters.AddWithValue("@gender", entity.Gender);
            cmd.Parameters.AddWithValue("@birthdate", entity.Birthdate);
            cmd.Parameters.AddWithValue("@initialWeight", entity.InitialWeight);

            db.Open();
            int inserted = (int)cmd.ExecuteScalar();
            db.Close();

            return inserted;
        }

        public override bool Update(User entity)
        {
            SqlCommand cmd = db.CreateCommand();
            cmd.CommandText = $"UPDATE {TableName} SET name = @name, email = @email, pwd = @pwd, gender = @gender, birthdate = @birthdate, initialWeight = @initialWeight) WHERE {TableID} = @id;";
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("@pwd", entity.Pwd);
            cmd.Parameters.AddWithValue("@gender", entity.Gender);
            cmd.Parameters.AddWithValue("@birthdate", entity.Birthdate);
            cmd.Parameters.AddWithValue("@initialWeight", entity.InitialWeight);
            cmd.Parameters.AddWithValue("@id", entity.UserID);

            db.Open();
            int isUpdated = (int)cmd.ExecuteScalar();
            db.Close();

            return isUpdated > 0;
        }

        protected override User ReaderToClient(SqlDataReader reader)
        {
            return new User()
            {
                UserID = (int)reader["userID"],
                Name = reader["name"].ToString(),
                Email = reader["email"].ToString(),
                Pwd = reader["pwd"].ToString(),
                Gender = reader["gender"].ToString(),
                Birthdate = Convert.ToDateTime(reader["birthdate"]),
                InitialWeight = (double)reader["initialWeight"]
            };
        }
    }
}
