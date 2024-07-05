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
using System.Xml.Serialization;

namespace Stock_Trading_App_WPF.Views
{
    /// <summary>
    /// Interaction logic for SecurityListView.xaml
    /// </summary>
    public partial class SecurityListView : UserControl
    {
        public SecurityListView()
        {
            //DataContext = new SecurityListViewModel();
            
            InitializeComponent();
            OnLoad();
        }

        private void OnLoad()
        {
            BrushConverter bc = new BrushConverter();

            GetTickersButton.MouseEnter += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                GetTickersButton.Background = (Brush)bc.ConvertFrom("#606060");
            });

            GetTickersButton.MouseLeave += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                GetTickersButton.Background = (Brush)bc.ConvertFrom("#454545");
            });
        }
    }
}
