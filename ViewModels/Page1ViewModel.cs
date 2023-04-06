using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DailyReport.Models;
using System.Data;

namespace DailyReport.ViewModels
{

    public class Page1ViewModel: Screen
    {
        DataConnect data = new DataConnect();
        List<string> selectedDistributor;

        //public List<string> _selectedDistributor;
        //public List<string> SelectedDistributor
        //{
        //    set
        //    {
        //        _selectedDistributor = value;
        //    }
        //    get
        //    {

        //        return _selectedDistributor;
        //    }
        //}

        public Page1ViewModel()
        {
            selectedDistributor = data.FetchDistributorName();
        }



        

        


    }

}
