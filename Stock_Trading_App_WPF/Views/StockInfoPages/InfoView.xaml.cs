using Stock_Trading_App_WPF.Models;
using Stock_Trading_App_WPF.ViewModels.StockInfoPageVM;
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

namespace Stock_Trading_App_WPF.Views.StockInfoPages
{
    /// <summary>
    /// Interaction logic for InfoView.xaml
    /// </summary>
    public partial class InfoView : UserControl
    {
        public InfoView()
        {
            InitializeComponent();
            OnLoad();
        }

        private void OnLoad()
        {
            FavouriteBorder.MouseEnter += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                FavouriteImage.Height = 25;
                FavouriteImage.Width = 25;
            });
            FavouriteBorder.MouseLeave += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                FavouriteImage.Height = 20;
                FavouriteImage.Width = 20;
            });
        }

        private void FavouriteBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                //if(MainWindowModel.FavouriteStocks.Contains)
                if (DataContext is InfoViewModel infoView)
                {
                    infoView.FavouriteButtonClickCommand.Execute(sender);
                }
            }
        }
    }
}
