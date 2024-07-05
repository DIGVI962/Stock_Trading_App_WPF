using DataLayer.ResponseClasses;
using Stock_Trading_App_WPF.Models;
using Stock_Trading_App_WPF.Utils;
using Stock_Trading_App_WPF.ViewModels.StockInfoPageVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Stock_Trading_App_WPF.ViewModels
{
    public class IndivStockInfoViewModel : ViewModelBase
    {
        //private object _selectedStock;
        private MarketWatchViewModel _mmv;
        private object _selectedInfo;

        public ICommand BackButtonClickCommand { get; set; }
        public ICommand InfoButtonClickCommand { get; set; }
        public ICommand QuotesButtonClickCommand { get; set; }
        public ICommand AdditionalButtonClickCommand { get; set; }

        /*public object SelectedTicker
        {
            get { return _selectedStock; }
            set { _selectedStock = value; OnPropertyChanged(nameof(SelectedTicker)); }
        }*/
        public object SelectedInfo
        {
            get { return _selectedInfo; }
            set { _selectedInfo = value; OnPropertyChanged(nameof(SelectedInfo)); }
        }

        public IndivStockInfoViewModel(MarketWatchViewModel mmv)
        {
            _mmv = mmv;
            SelectedInfo = new InfoViewModel(_mmv.PgNo);

            BackButtonClickCommand = new RelayCommand(BackButtonClick);
            InfoButtonClickCommand = new RelayCommand(InfoButtonClick);
            QuotesButtonClickCommand = new RelayCommand(QuotesButtonClick);
            AdditionalButtonClickCommand = new RelayCommand(AdditionalButtonClick);
        }

        private void AdditionalButtonClick(object obj)
        {
            SelectedInfo = new AdditionalViewModel();
        }

        private void QuotesButtonClick(object obj)
        {
            SelectedInfo = new QuotesViewModel();
        }

        private void InfoButtonClick(object obj)
        {
            SelectedInfo = new InfoViewModel(_mmv.PgNo);
        }

        private void BackButtonClick(object obj)
        {
            _mmv.mainWindow.CurrentView = _mmv;
        }
    }
}
