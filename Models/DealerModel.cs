using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace DailyReport.Models
{
    public class DealerModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = null;
        public string MobileNo { get; set; } = null;
        public string Place { get; set; } = null;
    }

    public class TravelDataModel
    {
        public string Vehicle { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Distance { get; set; }
    }
    public class DataConnect
    {
        public string conString;
        public SqlConnection con;
        public DataConnect()
        {
            conString = "Data Source= localhost\\SQLEXPRESS; Database= DailyReportTool; Integrated Security=True;";//"Data Source=ATI-9\\MSSQLSERVER1;Initial Catalog=Rough;Persist Security Info=True;User ID=sa;Password=_056pwjr";

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

    public static class FillData
    {
        public static List<string> FillRemarkList()
        {
            List<string> list = new List<string>();
            list.Add("Order Received");
            list.Add("Followup order and payment");
            list.Add("Order Discussed");
            list.Add("For Regular Visit");
            //list.Add("");

            return list;
        }

        public static List<string> FillVehicleList()
        {
            List<string> mylist = new List<string>();
            mylist.Add("Bike");
            mylist.Add("Train");
            mylist.Add("Bus");
            mylist.Add("Private Vehicle");

            return mylist;
        }
        public static DataTable DataTemp()
        {
            DataTable myDataTable = new DataTable();
            //myDataTable.Columns.Add("SNo");
            myDataTable.Columns.Add("DealerName");
            myDataTable.Columns.Add("Throughput");
            myDataTable.Columns.Add("MobileNo");
            myDataTable.Columns.Add("Remarks");

            return myDataTable;
        }

        public static DataTable TravelData()
        {
            DataTable myDataTable = new DataTable();
            myDataTable.Columns.Add("Vehicle");
            myDataTable.Columns.Add("From");
            myDataTable.Columns.Add("To");
            myDataTable.Columns.Add("DistanceTravelled");
            myDataTable.Columns.Add("Amount", typeof(int));

            return myDataTable;
        }
    }




    
}
