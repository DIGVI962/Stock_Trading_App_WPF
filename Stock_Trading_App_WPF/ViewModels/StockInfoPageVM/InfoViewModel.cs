using DataLayer.ResponseClasses;
using Stock_Trading_App_WPF.Models;
using Stock_Trading_App_WPF.Utils;
using Stock_Trading_App_WPF.Views.StockInfoPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Stock_Trading_App_WPF.ViewModels.StockInfoPageVM
{
    public class InfoViewModel : ViewModelBase
    {
        private BSEEqtyMarketWatch _stockObj;
        private string _isFavourite;
        private int _page;

        public ICommand FavouriteButtonClickCommand { get; set; }

        public BSEEqtyMarketWatch StockObj
        {
            get { return _stockObj; } 
            set { _stockObj = value; OnPropertyChanged(nameof(StockObj)); }
        }

        public string IsFavourite
        {
            get { return _isFavourite; }
            set { _isFavourite = value; OnPropertyChanged(nameof(IsFavourite)); }
        }

        public int Page
        {
            get { return _page; }
            set { _page = value; OnPropertyChanged(nameof(Page)); }
        }

        public string Name { get; set; }

        /*public InfoViewModel(object stockObj)
        {
            StockObj = (BSEEqtyMarketWatch)stockObj;    
        }*/

        public InfoViewModel(int pg)
        {
            StockObj = MainWindowModel.SelectedTicker;
            Name = "Basic Info Page";
            Page = pg;

            FavouriteButtonClickCommand = new RelayCommand(FavouriteButtonClick);


            if (!MainWindowModel.FavouriteStocks.Contains(StockObj))
            {
                IsFavourite = "N";
            }
            else
            {
                IsFavourite = "Y";
            }
        }

        private void FavouriteButtonClick(object obj)
        {
            if (IsFavourite == "N")
            {
                IsFavourite = "Y";
                MainWindowModel.FavouriteStocks.Add(StockObj);
            }
            else if (IsFavourite == "Y")
            {
                IsFavourite = "N";
                MainWindowModel.FavouriteStocks.Remove(StockObj);
            }
        }
    }
}
