using DataLayer;
using DataLayer.APIDataFetch;
using DataLayer.ResponseClasses;
using Stock_Trading_App_WPF.Utils;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Stock_Trading_App_WPF.Models;

namespace Stock_Trading_App_WPF.ViewModels
{
    public class MarketWatchViewModel : ViewModelBase
    {
        private string _showRefreshIcon;
        private string _currPageAPIGet;
        private int _pgNo;
        private string _flagAPIParam;
        private string _ddlVal1APIParam;
        private string _ddlVal2APIParam;
        private string _srtsAPIParam;
        private int _srtbAPIParam;
        private BSEMethods _bseMethods;
        private StockContext _stockContext;
        private ObservableCollection<BSEEqtyMarketWatch> _eqtyMarketList;
        private Dispatcher _dispatcher;
        private string _marketType;
        private ObservableCollection<String> _typeComboBoxItems;
        public MainWindowViewModel mainWindow;
        public ICommand GetMarketButtonClickCommand { get; set; }
        public ICommand TypeComboBoxItemChangedCommand { get; set; }
        public ICommand PrevButtonClickCommand { get; set; }
        public ICommand NextButtonClickCommand { get; set; }
        public ICommand StockItemSelectedCommand { get; set; }

        public ObservableCollection<string> TypeComboBoxItems
        {
            get { return _typeComboBoxItems; }
            set { _typeComboBoxItems = value; }
        }
        public string CurrPageAPIGet
        {
            get { return _currPageAPIGet; }
            set { _currPageAPIGet = value; OnPropertyChanged(nameof(CurrPageAPIGet)); }
        }
        public string ShowRefreshIcon
        {
            get { return _showRefreshIcon; }
            set { _showRefreshIcon = value; OnPropertyChanged(nameof(ShowRefreshIcon)); }
        }
        public int PgNo
        {
            get { return _pgNo; }
            set { _pgNo = value; OnPropertyChanged(nameof(PgNo)); }
        }
        public string FlagAPIParam
        {
            get { return _flagAPIParam; }
            set { _flagAPIParam = value; OnPropertyChanged(nameof(FlagAPIParam)); }
        }
        public string DdlVal1APIParam
        {
            get { return _ddlVal1APIParam; }
            set { _ddlVal1APIParam = value; OnPropertyChanged(nameof(DdlVal1APIParam)); }
        }
        public string DdlVal2APIParam
        {
            get { return _ddlVal2APIParam; }
            set { _ddlVal2APIParam = value; OnPropertyChanged(nameof(DdlVal2APIParam)); }
        }
        public string SrtsAPIParam
        {
            get { return _srtsAPIParam; }
            set { _srtsAPIParam = value; OnPropertyChanged(nameof(SrtsAPIParam)); }
        }
        public int SrtbAPIParam
        {
            get { return _srtbAPIParam; }
            set { _srtbAPIParam = value; OnPropertyChanged(nameof(SrtbAPIParam)); }
        }
        public ObservableCollection<BSEEqtyMarketWatch> EqtyMarketList
        {
            get { return _eqtyMarketList; }
            set { _eqtyMarketList = value; OnPropertyChanged(nameof(EqtyMarketList)); }
        }


        public MarketWatchViewModel(BSEMethods bseM, StockContext sc, string mt, MainWindowViewModel cv)
        {
            _bseMethods = bseM;
            _stockContext = sc;
            _marketType = mt;
            mainWindow = cv;
            EqtyMarketList = new ObservableCollection<BSEEqtyMarketWatch>();
            ShowRefreshIcon = "H";
            //EqtyMarketList = MainWindowModel.EqtyMarketList[PgNo];

            // Initialize COmboBoxLists
            TypeComboBoxItems = new ObservableCollection<string>()
            {
                "All",
                "S%26P%20BSE%20SEXSEX",
                "S%26P%20BSE%20100",
            };

            // Initialize API Params
            PgNo = 1;
            FlagAPIParam = "Equity";
            DdlVal1APIParam = "Index";
            DdlVal2APIParam = "All";
            SrtsAPIParam = "D";
            SrtbAPIParam = 6;

            // Initialize Commands
            GetMarketButtonClickCommand = new RelayCommand(GetMarketButtonClick);
            TypeComboBoxItemChangedCommand = new RelayCommand(TypeComboBoxItemChanged);
            PrevButtonClickCommand = new RelayCommand(PrevButtonClick);
            NextButtonClickCommand = new RelayCommand(NextButtonClick);
            StockItemSelectedCommand = new RelayCommand(StockItemSelected);

            // Async
            _dispatcher = Dispatcher.CurrentDispatcher;
            StartAutoUpdate();

            EqtyMarketList = new ObservableCollection<BSEEqtyMarketWatch>(_bseMethods.BSEEquityMarketWatch(1, FlagAPIParam, DdlVal1APIParam, DdlVal2APIParam, SrtsAPIParam, SrtbAPIParam));

            /*
            Thread thread1 = new Thread(StartAutoUpdate);
            thread1.IsBackground = true;
            thread1.Start();*/
        }

        private async void StartAutoUpdate()
        {
            while (true)
            {
                var newMarketList = await Task.Run(() => _bseMethods.BSEEquityMarketWatch(PgNo, FlagAPIParam, DdlVal1APIParam, DdlVal2APIParam, SrtsAPIParam, SrtbAPIParam));
                MainWindowModel.EqtyMarketList[PgNo] = new ObservableCollection<BSEEqtyMarketWatch>(newMarketList);
                // Update the market list
                _dispatcher.Invoke(() =>
                {
                    //EqtyMarketList = UpdateMarketList(newMarketList);
                    //EqtyMarketList = newMarketList;
                    if (ShowRefreshIcon == "H")
                        ShowRefreshIcon = "S";
                    else if (ShowRefreshIcon == "S")
                        ShowRefreshIcon = "H";
                    EqtyMarketList = MainWindowModel.EqtyMarketList[PgNo];

                });

                await Task.Delay(500);

                /*int i = 1;
                while (true)
                {
                    CurrPageAPIGet = i.ToString();
                    var newMarketList = await Task.Run(() => _bseMethods.BSEEquityMarketWatch(i, FlagAPIParam, DdlVal1APIParam, DdlVal2APIParam, SrtsAPIParam, SrtbAPIParam));
                    MainWindowModel.EqtyMarketList[i] = new ObservableCollection<BSEEqtyMarketWatch>(newMarketList);

                    // Update the market list

                    if(newMarketList.Count() < 30)
                    //if (i == 150)
                    {
                        Thread.Sleep(500);
                        break;
                    }

                    i++;
                    await Task.Delay(500);
                }
                _dispatcher.Invoke(() =>
                {
                    //EqtyMarketList = UpdateMarketList(newMarketList);
                    //EqtyMarketList = newMarketList;
                    if (ShowRefreshIcon == "H")
                        ShowRefreshIcon = "S";
                    else if (ShowRefreshIcon == "S")
                        ShowRefreshIcon = "H";
                    EqtyMarketList = MainWindowModel.EqtyMarketList[PgNo];
                });*/
            }
        }

        private List<BSEEqtyMarketWatch> UpdateMarketList(List<BSEEqtyMarketWatch> newMarketList)
        {
            List<BSEEqtyMarketWatch> temp = new List<BSEEqtyMarketWatch>(EqtyMarketList);
            foreach (var item in newMarketList)
            {
                var existingItem = temp.FirstOrDefault(i => i.Symbol == item.Symbol);

                if (existingItem != null)
                {
                    existingItem.Price = item.Price;
                    existingItem.BuyQty = item.BuyQty;
                    existingItem.BuyPrice = item.BuyPrice;
                }
                else
                {
                    temp.Add(item);
                }
            }

            return temp;
        }

        private void StockItemSelected(object obj)
        {
            var randTemp = (ListView)obj;
            //BSEEqtyMarketWatch selectedItem = (BSEEqtyMarketWatch)randTemp.SelectedItem;
            MainWindowModel.SelectedTicker = MainWindowModel.EqtyMarketList[PgNo][randTemp.SelectedIndex];

            mainWindow.CurrentView = new IndivStockInfoViewModel(this);
        }

        private void TypeComboBoxItemChanged(object obj)
        {
            var stype = (ComboBox)obj;

            var temps = stype.SelectedItem.ToString().Substring(stype.SelectedItem.ToString().LastIndexOf(':') + 1).Trim();
            
            if(stype.Name == "SrtsComboBox")
            {
                if (temps == "Ascending")
                    SrtsAPIParam = "A";
                else if (temps == "Descending")
                    SrtsAPIParam = "D";
            }

        }

        private async void NextButtonClick(object obj)
        {
            PgNo++;
            await Task.Delay(1000);
            EqtyMarketList = MainWindowModel.EqtyMarketList[PgNo];
        }

        private async void PrevButtonClick(object obj)
        {
            if(PgNo > 1)
            {
                PgNo--;
                await Task.Delay(1000);
                EqtyMarketList = MainWindowModel.EqtyMarketList[PgNo];
            }
        }

        private void GetMarketButtonClick(object obj)
        {
            GetMarketPgList(PgNo);
        }

        private void GetMarketPgList(int page)
        {
            //EqtyMarketList.Clear();

            //EqtyMarketList = _bseMethods.BSEEquityMarketWatch(page);
            //StartAutoUpdate();
        }
    }
}
