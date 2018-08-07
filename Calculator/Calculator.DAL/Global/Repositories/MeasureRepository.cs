using Calculator.DAL.Global.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Global.Repositories
{
    public class MeasureRepository : BaseRepository<int, Measure>
    {
        private MeasureRepository instance;
        public MeasureRepository Instance
        {
            get { return instance ?? (instance = new MeasureRepository()); }
        }

        public MeasureRepository() : base("Measure"){ }

        public override int Insert(Measure entity)
        {
            SqlCommand cmd = db.CreateCommand();
            cmd.CommandText = $"INSERT INTO {TableName} (date) OUTPUT inserted.{TableID} VALUES (@date)";
            cmd.Parameters.AddWithValue("@date", entity.Date);

            db.Open();
            int inserted = (int)cmd.ExecuteScalar();
            db.Close();

            return inserted;
        }

        public override bool Update(Measure entity)
        {
            SqlCommand cmd = db.CreateCommand();
            cmd.CommandText = $"UPDATE {TableName} SET date = @date WHERE {TableID} = @id";
            cmd.Parameters.AddWithValue("@id", entity.MeasureID);
            cmd.Parameters.AddWithValue("@date", entity.Date);

            db.Open();
            int isUpdated = (int)cmd.ExecuteScalar();
            db.Close();

            return isUpdated > 0;
        }

        protected override Measure ReaderToClient(SqlDataReader reader)
        {
            return new Measure()
            {
                MeasureID = (int)reader["measureID"],
                Date = Convert.ToDateTime(reader["date"])
            };
        }
    }
}
