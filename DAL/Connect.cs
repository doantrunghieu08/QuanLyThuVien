using System.Data.SqlClient;
using System.Data;

namespace DTO
{
    public class Connect
    {
        
        private string strConn = "Data Source=TrungHieu\\SQLEXPRESS;Initial Catalog=QLTV_HieuDT_3725_LTMT5;User ID=sa;Password=1234567890;Encrypt=False";

        
        public SqlConnection GetConnection()
        {
            return new SqlConnection(strConn);
        }

        public DataTable loadData(string sql)
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable loadDataByParameter(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection()) 
            {
                conn.Open();

           
                cmd.Connection = conn; 
                

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            } 
            return dt;
        }

        public void ExcuteNonQuery(SqlCommand cmd)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                cmd.Connection = conn; 
                cmd.ExecuteNonQuery();
            }
        }
    }
}