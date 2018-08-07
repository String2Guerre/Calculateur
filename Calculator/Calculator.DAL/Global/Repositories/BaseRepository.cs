using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Global.Repositories
{
    public abstract class BaseRepository<Tkey, TEntity>
    {
        protected SqlConnection db;
        private string instanceServer = @"(local)\SQL";
        private string database = "Calculator";

        private string tableName;
        protected string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private string tableID;
        public string TableID
        {
            get { return tableID; }
            set { tableID = value; }
        }

        protected virtual string GetAllCommand
        {
            get { return string.Format("SELECT * FROM {0}", TableName); }
        }

        protected virtual string GetOneCommand
        {
            get { return string.Format("{0} WHERE {1} = @id", GetAllCommand, TableID); }
        }

        protected virtual string DeleteCommand
        {
            get { return string.Format("DELETE FROM {0} WHERE {1} = @id", TableName, TableID); }
        }

        public string ConnectionString
        {
            get { return string.Format($"Data Source={instanceServer};Initial Catalog={database};Integrated Security=SSPI;"); }
        }

        public BaseRepository(string table)
        {
            this.TableName = $"[{table}]";
            this.TableID = $"[{table}ID]";
            this.db = new SqlConnection(ConnectionString);
        }


        public List<TEntity> GetAll()
        {
            List<TEntity> Items = new List<TEntity>();

            SqlCommand cmd = db.CreateCommand();
            cmd.CommandText = GetAllCommand;
            SqlDataReader reader = cmd.ExecuteReader();

            db.Open();
            while (reader.Read())
            {
                TEntity entity = ReaderToClient(reader);

                Items.Add(entity);
            }
            reader.Close();

            db.Close();

            return Items;
        }

        public TEntity GetOne(Tkey id)
        {
            TEntity item = default(TEntity);

            SqlCommand cmd = db.CreateCommand();
            cmd.CommandText = GetOneCommand;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();

            db.Open();
            if (reader.Read())
            {
                item = ReaderToClient(reader);
            }
            reader.Close();

            db.Close();

            return item;
        }

        public bool Delete(Tkey id)
        {
            SqlCommand cmd = db.CreateCommand();
            cmd.CommandText = DeleteCommand ;
            cmd.Parameters.AddWithValue("@id", id);

            db.Open();
            int isDeleted = cmd.ExecuteNonQuery();
            db.Close();

            return isDeleted == 1;
        }

        protected abstract TEntity ReaderToClient(SqlDataReader reader);
        public abstract int Insert(TEntity entity);
        public abstract bool Update(TEntity entity);
    }
}
