using DataLayer;
using DataLayer.APIDataFetch;
using DataLayer.ResponseClasses;
using Stock_Trading_App_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Trading_App_WPF.Models
{
    public static class MainWindowModel
    {
        public static BSEMethods bMethods { get; set; }
        public static StockContext stockContext { get; set; }
        public static string mrktType = "";

        public static object currView { get; set; }
        public static BSEEqtyMarketWatch SelectedTicker { get; set; }

        public static ObservableCollection<ObservableCollection<BSEEqtyMarketWatch>> EqtyMarketList { get; set; }
        public static ObservableCollection<BSEEqtyMarketWatch> FavouriteStocks { get; set; }

    }
}
