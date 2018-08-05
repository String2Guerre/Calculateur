using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.DAL.Global.Repositories
{
    public class BaseRepository<Tkey, TEntity>
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
        
        public string ConnectioString
        {
            get { return string.Format($"Data Source={instanceServer};Initial Catalog={database};Integrated Security=SSPI;"); }
        }

        public BaseRepository()
        {
            this.db = new SqlConnection(ConnectioString);
        }

        
        public IEnumerable<TEntity> GetAll()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM {TableName}");

            IEnumerable<TEntity> list
            return 
        }

    }
}
