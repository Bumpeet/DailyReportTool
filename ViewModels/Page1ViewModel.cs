using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DailyReport.Models;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity.Migrations;
using System.Collections.Specialized;
using Xceed.Words.NET;
using System.Drawing;
using Xceed.Document.NET;
using System.Diagnostics;

namespace DailyReport.ViewModels
{
    #region commented
    //DataConnect DistributorData = new DataConnect();
    //DataConnect DealerData = new DataConnect();

    //private BindableCollection<DealerModel> _distributors = new BindableCollection<DealerModel>();
    //private BindableCollection<DealerModel> _dealers = new BindableCollection<DealerModel>();
    //private BindableCollection<string> _beats = new BindableCollection<string>();

    //public HashSet<string> HashSetStrings;
    //public List<string> ListStrings = new List<string>();

    //public BindableCollection<DealerModel> Distributors
    //{
    //    get { return _distributors; }
    //    set { _distributors = value; }
    //}
    //public BindableCollection<DealerModel> Dealers
    //{
    //    get { return _dealers; }
    //    set { 
    //        _dealers = value;
    //        //NotifyOfPropertyChange(() => Dealers);
    //    }
    //}
    //public BindableCollection<string> Beats
    //{
    //    get { return _beats; }
    //    set { _beats = value; }
    //}


    //DataTable dt_distributors = new DataTable();
    //DataTable dt_dealers = new DataTable();

    //private DealerModel _selectedDistributor;

    //public DealerModel SelectedDistributor
    //{
    //    get { return _selectedDistributor; }

    //    set
    //    {
    //        _selectedDistributor = value;
    //        NotifyOfPropertyChange(() => SelectedDistributor); //SelectedItem="{Binding Path= SelectedValue, Mode=OneWayToSource}"; SelectedItem="{Binding Path=SelectedValue, Mode=OneWayToSource}"
    //    }
    //}
    //private string _selectedBeat;

    //public string SelectedBeat
    //{
    //    get { return _selectedBeat; }
    //    set
    //    {
    //        _selectedBeat = value;
    //        NotifyOfPropertyChange(() => SelectedBeat); //SelectedItem="{Binding Path= SelectedValue, Mode=OneWayToSource}"; SelectedItem="{Binding Path=SelectedValue, Mode=OneWayToSource}"

    //    }
    //}
    //private DealerModel _selectedDealer;

    //public DealerModel SelectedDealer
    //{
    //    get { return _selectedDealer; }
    //    set
    //    {
    //        _selectedDealer = value;
    //        NotifyOfPropertyChange(() => SelectedDealer); //SelectedItem="{Binding Path= SelectedValue, Mode=OneWayToSource}"; SelectedItem="{Binding Path=SelectedValue, Mode=OneWayToSource}"

    //    }
    //}

    //public Page1ViewModel()
    //{
    //    dt_distributors = DistributorData.FetchData("select * from DistributorTable"); //Distributors or DistributorTable
    //    dt_dealers = DealerData.FetchData("select * from DealerTable");

    //    foreach (DataRow row in dt_distributors.Rows)
    //    {
    //        DealerModel distributor = new DealerModel();
    //        distributor.Id = (int)row["DistributorID"];
    //        distributor.Name = (string)row["DistributorName"];
    //        distributor.MobileNo = (string)row["MobileNo"];
    //        distributor.Place = (string)row["Place"];

    //        Distributors.Add(distributor);

    //    }
    //    //Distributors = Dis

    //    foreach (DataRow row in dt_dealers.Rows)
    //    {
    //        DealerModel dealer = new DealerModel();
    //        dealer.Id = (int)row["DealerID"];
    //        dealer.Name = (string)row["DealerName"];
    //        dealer.MobileNo = (string)row["MobileNo"];
    //        dealer.Place = (string)row["Place"];

    //        Dealers.Add(dealer);
    //        ListStrings.Add((string)row["Place"]);
    //    }
    //    //Dealers = Dealers.Distinct<DealerModel>(x => x.Place);

    //    HashSetStrings = new HashSet<string>(ListStrings);
    //    Beats = new BindableCollection<string>(HashSetStrings);

    //}

    //public void button()
    //{

    //    string distributor = SelectedDistributor.Name;
    //    string location = SelectedBeat;
    //}

    //public void cbBeat_SelectionChanged(SelectionChangedEventArgs e)
    //{
    //    //Dealers = new BindableCollection<DealerModel>(Dealers.Where(x => x.Name == SelectedBeat));
    //    MessageBox.Show($"{SelectedBeat}");

    //}

    //----------------------------------------------------------------
    #endregion

    public class Page1ViewModel: Screen
    {
        #region constructor
        public Page1ViewModel()
        {

            Beats = new BindableCollection<string>(dailyReportToolEntities.DealerTables.ToList().Select(x => x.Place).Distinct());
            Distributors = new BindableCollection<DistributorTable>(dailyReportToolEntities.DistributorTables.ToList());
            RemarksList = new BindableCollection<string>(FillData.FillRemarkList());
            VehicleList = new BindableCollection<string>(FillData.FillVehicleList());
            MyTempData = FillData.DataTemp();
            MyTravelData = FillData.TravelData();

        }
        #endregion

        #region bindingSource Variables
        DailyReportToolEntities dailyReportToolEntities = new DailyReportToolEntities();

        private BindableCollection<DistributorTable> _distributors;
        private BindableCollection<DealerTable> _dealers;
        private BindableCollection<string> _beats;
        private BindableCollection<TempData> _viewData = new BindableCollection<TempData>();
        private DataTable _myTempData;
        private BindableCollection<string> _remarksList;
        private BindableCollection<string> _vehicleList;
        private DataTable _myTravelData;

        public DataTable MyTempData
        {
            get { return _myTempData; }
            set
            {
                _myTempData = value;
                NotifyOfPropertyChange(() => MyTempData);
            }
        }
        public BindableCollection<TempData> ViewData
        {
            get { return _viewData; }
            set
            {
                _viewData = value;
                NotifyOfPropertyChange(() => ViewData); // Notify Caliburn.Micro that the collection has changed
            }
        }
        public BindableCollection<DealerTable> Dealers
        {
            get { return _dealers; }
            set
            {
                _dealers = value;
                NotifyOfPropertyChange(() => Dealers);
            }
        }
        public BindableCollection<string> Beats
        {
            get { return _beats; }
            set
            {
                _beats = value;
            }
        }
        public BindableCollection<DistributorTable> Distributors
        {
            get { return _distributors; }
            set { _distributors = value; }
        }
        public DataTable MyTravelData
        {
            get { return _myTravelData; }
            set { _myTravelData = value; NotifyOfPropertyChange(() => MyTravelData); }
        }

        public BindableCollection<string> RemarksList
        {
            get { return _remarksList; }
            set { _remarksList = value; }
        }

        public BindableCollection<string> VehicleList { get { return _vehicleList; } set { _vehicleList = value; } }
        #endregion

        #region Selected Variables
        private DealerTable _selectedDealer;
        private DistributorTable _selectedDistributor;
        private string _selectedBeat;
        private string _selectedRemark;
        private string _throughput;
        private DateTime _selectedDate;

        private string _selectedVehicle;
        private string _from;
        private string _to;
        private int _distance;
        private int _amount;

        public string SelectedVehicle
        {
            get { return _selectedVehicle; }
            set
            {
                _selectedVehicle = value;
                NotifyOfPropertyChange(() => SelectedVehicle);

            }
        }
        public string From
        {
            get { return _from; }
            set { _from = value; NotifyOfPropertyChange(() => From); }
        }

        public string To
        {
            get { return _to; }
            set { _to = value; NotifyOfPropertyChange(() => To); }
        }

        public int Distance
        {
            get { return _distance; }
            set { _distance = value; NotifyOfPropertyChange(() => Distance); }
        }
        public int Amount
        {
            get { return _amount; }
            set { _amount = value; NotifyOfPropertyChange(() => _amount); }
        }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value; }

        }
        public DealerTable SelectedDealer
        {
            get { return _selectedDealer; }
            set { 
                _selectedDealer = value; 
                NotifyOfPropertyChange(() => SelectedDealer);

            }
        }

        public DistributorTable SelectedDistributor
        {
            get { return _selectedDistributor; }
            set { _selectedDistributor = value; }
        }

        public string SelectedBeat
        {
            get { return (_selectedBeat == null) ? null : _selectedBeat.ToString(); }
            set { 
                _selectedBeat = value;
                NotifyOfPropertyChange(() => SelectedBeat);
            }
        }

        public string Throughput
        {
            get { return _throughput; }
            set { 
                _throughput = value; 
                NotifyOfPropertyChange(() => Throughput);
            }
        }

        public string SelectedRemark
        {
            get { return _selectedRemark; }
            set { 
                _selectedRemark = value;
                NotifyOfPropertyChange(() => SelectedRemark);

            }
        }


        #endregion

        #region Amount Source Variables
        private int _ta;
        public int TA
        {
            get { return _ta; }
            set { _ta = value; NotifyOfPropertyChange(() => TA); }
        }

        private int _da;
        public int DA
        {
            get { return _da; }
            set { _da = value; }
        }
        private int _misc;
        public int Misc
        {
            get { return _misc; }
            set { _misc = value; }
        }

        private int _total;
        public int Total
        {
            get { return _total; }
            set { _total = value; NotifyOfPropertyChange(() => TA); }
        }

        #endregion

        #region Events and Functions
        public void cbBeat_SelectionChanged(SelectionChangedEventArgs e)
        {
            Dealers = new BindableCollection<DealerTable>(dailyReportToolEntities.DealerTables.ToList().Where(x => x.Place == SelectedBeat));
        }

        public void clearData()
        {
            SelectedDealer = null;
            Throughput = null;
            SelectedRemark = null;

            SelectedVehicle = null;
            From = null;
            To = null;
            Distance = 0;

        }
        #endregion

        #region Button's
        public void addDealerButton()
        {

            MyTempData.Rows.Add($"{SelectedDealer.DealerName}", $"{Throughput}", $"{SelectedDealer.MobileNo}", $"{SelectedRemark}");

            clearData();

            //MessageBox.Show(SelectedDate.Date.ToString());

        }

        public void addTravelButton()
        {

            if (SelectedVehicle != "Bike")
            {

                MyTravelData.Rows.Add($"{SelectedVehicle}", $"{From}", $"{To}", $"{Distance}", $"{Amount}");
                MyTravelData.Rows.Add($"{SelectedVehicle}", $"{To}", $"{From}", $"{Distance}", $"{Amount}");

            }
            else if (SelectedVehicle == "Bike")
            {
                Amount = Distance * 3;
                MyTravelData.Rows.Add($"{SelectedVehicle}", $"{From}", $"{To}", $"{Distance}", $"{Amount}");

            }

            foreach (DataRow row in MyTravelData.Rows)
            {
                TA += (int)row["Amount"];
            }

            clearData();
        }

        public void generateButton()
        {
            Total = TA + DA + Misc;

            string fileName = $"C:\\Users\\pavan\\desktop\\reprot.docx";
            var doc = DocX.Create(fileName);

            string title = "Daily TA Bill" + Environment.NewLine;
            Formatting titleForamt = new Formatting();
            titleForamt.FontFamily = new Xceed.Document.NET.Font("Times New Roman");
            titleForamt.Size = 28D;
            Paragraph paragraphTitle = doc.InsertParagraph(title, false, titleForamt);
            paragraphTitle.Alignment = Alignment.center;

            string date_place = $"Date: {SelectedDate.ToShortDateString()}" + 
                Environment.NewLine + 
                $"Beat Name: {SelectedBeat}" + 
                Environment.NewLine + 
                $"Distributor: {SelectedDistributor.DistributorName}" + 
                Environment.NewLine;

            Formatting paragraphFormat = new Formatting();
            paragraphFormat.FontFamily = titleForamt.FontFamily;
            paragraphFormat.Size = 12D;
            Paragraph paragraph = doc.InsertParagraph(date_place, false, paragraphFormat);
            paragraph.Alignment = Alignment.left;

            Table t1 = doc.AddTable(MyTempData.Rows.Count + 1, 4);
            t1.Alignment = Alignment.left;

            t1.Rows[0].Cells[0].Paragraphs.First().Append("Dealer");
            t1.Rows[0].Cells[1].Paragraphs.First().Append("Throughput");
            t1.Rows[0].Cells[2].Paragraphs.First().Append("Mobile No.");
            t1.Rows[0].Cells[3].Paragraphs.First().Append("Remarks");

            for (int i = 0; i < MyTempData.Rows.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    t1.Rows[i+1].Cells[j].Paragraphs.First().Append((string)MyTempData.Rows[i][j]);
                }

            }
            doc.InsertTable(t1);

            doc.InsertParagraph(Environment.NewLine);

            Table t2 = doc.AddTable(MyTravelData.Rows.Count + 1, 5);
            t2.Alignment = Alignment.left;

            t2.Rows[0].Cells[0].Paragraphs.First().Append("Vehicle");
            t2.Rows[0].Cells[1].Paragraphs.First().Append("From");
            t2.Rows[0].Cells[2].Paragraphs.First().Append("To");
            t2.Rows[0].Cells[3].Paragraphs.First().Append("Distance");
            t2.Rows[0].Cells[4].Paragraphs.First().Append("Amount");

            for (int i = 0; i < MyTravelData.Rows.Count; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    t2.Rows[i + 1].Cells[j].Paragraphs.First().Append($"{MyTravelData.Rows[i][j]}");
                }

            }
            doc.InsertTable(t2);

            doc.InsertParagraph(Environment.NewLine);

            string para2 = $"TA Charges: {TA} " + Environment.NewLine +
                           $"DA Charges: {DA} " + Environment.NewLine +
                           $"Misc. Charges: {Misc} " + Environment.NewLine +
                           $"Total Charges: {Total} " + Environment.NewLine;
            Paragraph paragraph2 = doc.InsertParagraph(para2, false, paragraphFormat);
            paragraph.Alignment = Alignment.left;

            doc.Save();

            MessageBox.Show("done.. Generating DOCX");

        }
        #endregion

    }

}
