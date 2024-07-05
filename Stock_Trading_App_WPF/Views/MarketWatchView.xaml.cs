using Stock_Trading_App_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stock_Trading_App_WPF.Views
{
    /// <summary>
    /// Interaction logic for MarketWatchView.xaml
    /// </summary>
    public partial class MarketWatchView : UserControl
    {
        public MarketWatchView()
        {
            InitializeComponent();
            OnLoad();
        }

        private void OnLoad()
        {
            BrushConverter bc = new BrushConverter();

            GetMarketListButton.MouseEnter += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                GetMarketListButton.Background = (Brush)bc.ConvertFrom("#606060");
            });
            GetMarketListButton.MouseLeave += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                GetMarketListButton.Background = (Brush)bc.ConvertFrom("#454545");
            });

            PrevButton.MouseEnter += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                PrevButton.Background = (Brush)bc.ConvertFrom("#606060");
            });
            PrevButton.MouseLeave += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                PrevButton.Background = (Brush)bc.ConvertFrom("#454545");
            });

            NextButton.MouseEnter += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                NextButton.Background = (Brush)bc.ConvertFrom("#606060");
            });
            NextButton.MouseLeave += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                NextButton.Background = (Brush)bc.ConvertFrom("#454545");
            });
        }

        private void TypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(DataContext is MarketWatchViewModel viewModel)
            {
                viewModel.TypeComboBoxItemChangedCommand.Execute(sender);
            }
        }

        private void MarketListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                if (DataContext is MarketWatchViewModel viewModel)
                {
                    viewModel.StockItemSelectedCommand.Execute(sender);
                }
            }
        }
    }
}
