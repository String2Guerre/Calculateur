using Calculator.DAL.Global.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Global.Repositories
{
    public class MeasureTypeRepository : BaseRepository<int, MeasureType>
    {
        private MeasureRepository instance;
        public MeasureRepository Instance
        {
            get { return instance ?? (instance = new MeasureRepository()); }
        }

        public MeasureTypeRepository() : base("MeasureType") { }

        public override int Insert(MeasureType entity)
        {
            SqlCommand cmd = db.CreateCommand();
            cmd.CommandText = $"INSERT INTO {TableName} (name, value, measureID) OUTPUT inserted.{TableID} VALUES (@name, @value, @measureID)";
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@value", entity.Value);
            cmd.Parameters.AddWithValue("@measureID", entity.MeasureID);

            db.Open();
            int inserted = (int)cmd.ExecuteScalar();
            db.Close();

            return inserted;
        }

        public override bool Update(MeasureType entity)
        {
            SqlCommand cmd = db.CreateCommand();
            cmd.CommandText = $"UPDATE {TableName} SET name = @name, value = @value, measureID = @measureID WHERE {TableID} = @id";
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@value", entity.Value);
            cmd.Parameters.AddWithValue("@measureID", entity.MeasureID);
            cmd.Parameters.AddWithValue("@id", entity.MeasureTypeID);

            db.Open();
            int isUpdated = (int)cmd.ExecuteScalar();
            db.Close();

            return isUpdated > 0;
        }

        protected override MeasureType ReaderToClient(SqlDataReader reader)
        {
            return new MeasureType()
            {
                MeasureTypeID = (int)reader["measureTypeID"],
                Name = reader["name"].ToString(),
                Value = (double)reader["value"],
                MeasureID = (int)reader["measureID"]
            };
        }
    }
}
