using DataLayer;
using DataLayer.APIDataFetch;
using DataLayer.ResponseClasses;
using Stock_Trading_App_WPF.Models;
using Stock_Trading_App_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Stock_Trading_App_WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _currentView;
        private string _marketType;
        private BSEMethods _bSEMethods;
        private StockContext _stockContext;
        private Dispatcher _dispatcher;
        //private MainWindowModel _model = new MainWindowModel();
        private string _counted;

        public ICommand HomeCommand { get; set; }
        public ICommand SecurityListCommand { get; set; }
        public ICommand MarketWatchCommand { get; set; }
        public ICommand ChangeMarketCommand { get; set; }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        public ObservableCollection<BSEEqtyMarketWatch> FavList
        {
            get { return MainWindowModel.FavouriteStocks; }
            set { MainWindowModel.FavouriteStocks = value; OnPropertyChanged(nameof(FavList)); }
        }

        /*public object CurrentView
        {
            get { return MainWindowModel.currView; }
            set
            {
                MainWindowModel.currView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }*/
        public string MarketType
        {
            get { return _marketType; }
            set { _marketType = value; OnPropertyChanged(nameof(MarketType)); }
        }
        public string Counted
        {
            get { return _counted; }
            set { _counted = value; OnPropertyChanged(nameof(Counted)); }
        }

        public MainWindowViewModel(BSEMethods bseM, StockContext sc)
        {
            // Startup Page
            CurrentView = new HomeViewModel();
            MarketType = "BSE";
            FavList = new ObservableCollection<BSEEqtyMarketWatch>();
            MainWindowModel.EqtyMarketList = new ObservableCollection<ObservableCollection<BSEEqtyMarketWatch>>();
            for (int k = 0; k < 300; k++)
            {
                MainWindowModel.EqtyMarketList.Add(null);
            }

            /*_model.mrktType = MarketType;
            _model.bMethods = bseM;
            _model.stockContext = sc;*/

            Counted = sc.bseScrips.Count().ToString();
            _bSEMethods = bseM;
            _stockContext = sc;

            HomeCommand = new RelayCommand(Home);
            SecurityListCommand = new RelayCommand(SecurityList);
            MarketWatchCommand = new RelayCommand(MarketWatch);
            ChangeMarketCommand = new RelayCommand(ChangeMarket);

            _dispatcher = Dispatcher.CurrentDispatcher;

            //StartUpAsync();
        }

        public async void RefreshFavListAsync()
        {
            Task.Run(() => { });
            _dispatcher.Invoke(() =>
            {
                FavList = MainWindowModel.FavouriteStocks;
            });
            
            await Task.Delay(500);
        }

        private async void StartUpAsync()
        {
            
            int q = 0;
            while (true)
            {
                int p = 1;
                for(int j=0; j<1; j++) { 
                    for(int i=0; i<1; i++)
                    {
                        //Thread thread = new Thread(GetMarketWatchMultiThreaded);
                        //thread.IsBackground = true;
                        //await Task.Run(() => thread.Start(p));
                        await Task.Run(() => GetMarketWatchMultiThreaded(p));
                        //p++;
                    }

                    Thread.Sleep(5000);
                }

                q++;
            }
        }

        private void GetMarketWatchMultiThreaded(object pg)
        {
            int page = (int)pg;

            //var tempListMKW = _bSEMethods.BSEEquityMarketWatch(page, "Equity", "Index", "All", "D", 6);
            MainWindowModel.EqtyMarketList[page] = new ObservableCollection<BSEEqtyMarketWatch>
                    (_bSEMethods.BSEEquityMarketWatch(page, "Equity", "Index", "All", "D", 6));

            /*if (MainWindowModel.EqtyMarketList[page] != null)
            {
                //MainWindowModel.EqtyMarketList[page] = new ObservableCollection<BSEEqtyMarketWatch>(tempListMKW);
                
            }
            else
            {

            }*/
        }

        private void ChangeMarket(object obj)
        {
            if (MarketType == "BSE")
                MarketType = "NSE";
            else if (MarketType == "NSE")
                MarketType = "BSE";
        }

        private void Home(object obj) => CurrentView = new HomeViewModel();
        private void SecurityList(object obj) => CurrentView = new SecurityListViewModel(_bSEMethods, _stockContext, MarketType);
        private void MarketWatch(object obj)
        {
            CurrentView = new MarketWatchViewModel(_bSEMethods, _stockContext, MarketType, this);
        }
    }
}