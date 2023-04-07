using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DailyReport.Models;
using System.Data;
using System.Windows;

namespace DailyReport.ViewModels
{

    public class Page1ViewModel: Screen
    {
        DataConnect DistributorData = new DataConnect();
        DataConnect DealerData = new DataConnect();

        private BindableCollection<DealerModel> _distributors = new BindableCollection<DealerModel>();
        private BindableCollection<DealerModel> _dealers = new BindableCollection<DealerModel>();
        public BindableCollection<DealerModel> Distributors
        {
            get { return _distributors; }
            set 
            { 
                _distributors = value;
            }
        }
        public BindableCollection<DealerModel> Dealers
        {
            get { return _dealers; }
            set{ _dealers = value; }
        }

        DataTable dt_distributors = new DataTable();
        DataTable dt_dealers = new DataTable();

        private DealerModel _selectedValue;

        public DealerModel SelectedValue
        {
            get { return _selectedValue; }

            set
            {
                _selectedValue = value;
                NotifyOfPropertyChange(() => SelectedValue);
            }
        }

        public Page1ViewModel()
        {
            dt_distributors = DistributorData.FetchData("select * from Distributors");
            dt_dealers = DealerData.FetchData("select Place from DealerTable group by Place");

            foreach (DataRow row in dt_distributors.Rows)
            {
                DealerModel distributor = new DealerModel();
                distributor.DealerId = (int)row["DistributorID"];
                distributor.DealerName = (string)row["DistributorName"];
                distributor.MobileNo = (string)row["MobileNo"];
                distributor.Place = (string)row["Place"];

                Distributors.Add(distributor);
               
            }

            foreach (DataRow row in dt_dealers.Rows)
            {
                DealerModel dealer = new DealerModel();
                    //dealer.DealerId = (int)row["ID"];
                    //dealer.DealerName = (string)row["DealerName"];
                    //dealer.MobileNo = (string)row["MobileNo"];
                dealer.Place = (string)row["Place"];

                Dealers.Add(dealer);

            }
            

        }

        














    }

}
