using DataLayer;
using DataLayer.APIDataFetch;
using DataLayer.ResponseClasses;
using Microsoft.EntityFrameworkCore;
using Stock_Trading_App_WPF.Utils;
using System.Windows.Input;

namespace Stock_Trading_App_WPF.ViewModels
{
    public class SecurityListViewModel : ViewModelBase
    {
        private List<BSEScrips> _securityList;
        private string _marketType;

        public ICommand GetTickersCommand { get; set; }

        public List<BSEScrips> SecurityList
        {
            get { return _securityList; }
            set 
            { 
                _securityList = value;
                OnPropertyChanged(nameof(SecurityList));
            }
        }

        private BSEMethods _bseMethods;
        private StockContext _stockContext;

        public SecurityListViewModel(BSEMethods bseM, StockContext sc, string mt)
        {
            SecurityList = [];
            _bseMethods = bseM;
            _stockContext = sc;
            _marketType = mt;

            GetTickersCommand = new RelayCommand(GetTickersAsync);
            
            LoadSecurityListAsync();
        }

        public async Task LoadSecurityListAsync()
        {
            var scrips = await _stockContext.bseScrips.ToListAsync();
            SecurityList = scrips;
        }

        private async void GetTickersAsync(object obj)
        {
            SecurityList.Clear();

            var temp = await Task.Run(() => _bseMethods.BSEGetTickers());

            SecurityList = temp;
        }
    }
}
