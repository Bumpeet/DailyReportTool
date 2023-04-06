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
        public string DealerName { get; set; }
        public string LastName { get; set; }
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

        public DataTable FetchDistributorData()
        {
            DataTable data = new DataTable();
            using (con)
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("select * from Distributors"))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        data.Load(reader);

                    }
                }

            }
            return data;
        }

        public List<string> FetchDistributorName()
        {
            List<string> data = new List<string>();
            //DataRow[] names;

            DataTable wholeData = this.FetchDistributorData();
            //names = wholeData.Select("DistributorName");

            //return names;
            foreach (DataRow row in wholeData.Rows)
            {
                data.Add($"row['DistributorName']");
            }
            return data;
            
        }
    }
}
