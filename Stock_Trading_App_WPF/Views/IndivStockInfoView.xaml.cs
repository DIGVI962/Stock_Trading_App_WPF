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
    /// Interaction logic for IndivStockInfoView.xaml
    /// </summary>
    public partial class IndivStockInfoView : UserControl
    {
        public IndivStockInfoView()
        {
            InitializeComponent();
            OnLoad();
        }

        public void OnLoad()
        {
            CloseBorder.MouseEnter += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                CloseImage.Height = 20;
                CloseImage.Width = 20;
            });
            CloseBorder.MouseLeave += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                CloseImage.Height = 16;
                CloseImage.Width = 16;
            });
        }

        private void CloseBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(DataContext is IndivStockInfoViewModel viewModel)
            {
                viewModel.BackButtonClickCommand.Execute(sender);
            }
        }
    }
}
