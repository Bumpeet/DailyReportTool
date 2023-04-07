using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DailyReport.Models
{
    public class DealerModel
    {
        public int DealerId { get; set; } = 0;
        public string DealerName { get; set; } = null;
        public string MobileNo { get; set; } = null;
        public string Place { get; set; } = null;
    }

    public class DataConnect
    {
        public string conString;
        public SqlConnection con;
        public DataConnect()
        {
            conString = "Data Source=ATI-9\\MSSQLSERVER1;Initial Catalog=Rough;Persist Security Info=True;User ID=sa;Password=_056pwjr";

            con = new SqlConnection(conString);

        }

        public DataTable FetchData(String cmd)
        {
            DataTable data = new DataTable();
            using (con)
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(cmd, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        data.Load(reader);

                    }
                }


            }
            return data;
        }

        //public List<string> FetchNames(String cmd)
        //{
        //    List<string> data = new List<string>();
        //    DataTable wholeData = this.FetchData(cmd);

        //    foreach (DataRow row in wholeData.Rows)
        //    {
        //        data.Add($"{row["DistributorName"]}");
        //    }
        //    return data;
            
        //}
    }
}
