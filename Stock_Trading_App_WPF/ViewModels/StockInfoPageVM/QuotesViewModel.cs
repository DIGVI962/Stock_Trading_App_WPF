using DataLayer.ResponseClasses;
using Stock_Trading_App_WPF.Models;
using Stock_Trading_App_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Stock_Trading_App_WPF.ViewModels.StockInfoPageVM
{
    public class QuotesViewModel : ViewModelBase
    {
        private BSEEqtyMarketWatch _stockObj;

        public BSEEqtyMarketWatch StockObj
        {
            get { return _stockObj; }
            set { _stockObj = value; OnPropertyChanged(nameof(StockObj)); }
        }

        public string Name { get; set; }

        public QuotesViewModel()
        {
            StockObj = MainWindowModel.SelectedTicker;
            Name = "Quotes Info Page";
        }
    }
}
