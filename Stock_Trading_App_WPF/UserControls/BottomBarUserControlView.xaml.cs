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

namespace Stock_Trading_App_WPF.UserControls
{
    /// <summary>
    /// Interaction logic for BottomBarUserControlView.xaml
    /// </summary>
    public partial class BottomBarUserControlView : UserControl
    {
        public BottomBarUserControlView()
        {
            InitializeComponent();
            OnLoad();
        }

        private void SwitchBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;

            if(border != null)
            {
                if(DataContext is MainWindowViewModel context)
                {
                    if (border.HorizontalAlignment == HorizontalAlignment.Left)
                    {
                        border.HorizontalAlignment = HorizontalAlignment.Right;
                        context.MarketType = "NSE";
                    }
                    else
                    {
                        border.HorizontalAlignment = HorizontalAlignment.Left;
                        context.MarketType = "BSE";
                    }

                }
            }
        }

        private void OnLoad()
        {
            SwitchBorder.MouseEnter += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                SwitchBorder.Background = Brushes.SkyBlue;
            });
            SwitchBorder.MouseLeave += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                SwitchBorder.Background = Brushes.White;
            });
        }
    }
}
