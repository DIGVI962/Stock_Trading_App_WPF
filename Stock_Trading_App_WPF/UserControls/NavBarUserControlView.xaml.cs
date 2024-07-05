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
    /// Interaction logic for NavBarUserControlView.xaml
    /// </summary>
    public partial class NavBarUserControlView : UserControl
    {
        public NavBarUserControlView()
        {
            InitializeComponent();
            OnLoad();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if(Application.Current.MainWindow.WindowState == WindowState.Normal)
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            else if(Application.Current.MainWindow.WindowState == WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Normal;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OnLoad()
        {
            BrushConverter bc = new BrushConverter();

            CloseButton.MouseEnter += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                CloseButton.Background = Brushes.Red;
            });

            CloseButton.MouseLeave += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                CloseButton.Background = (Brush)bc.ConvertFrom("#454545");
            });


            MaximizeButton.MouseEnter += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                MaximizeButton.Background = (Brush)bc.ConvertFrom("#606060");
            });

            MaximizeButton.MouseLeave += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                MaximizeButton.Background = (Brush)bc.ConvertFrom("#454545");
            });


            MinimizeButton.MouseEnter += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                MinimizeButton.Background = (Brush)bc.ConvertFrom("#606060");
            });

            MinimizeButton.MouseLeave += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                MinimizeButton.Background = (Brush)bc.ConvertFrom("#454545");
            });
        }

        private void MovableRectangle_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if(Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Window parent = Window.GetWindow(this);
                if(parent != null)
                {
                    parent.DragMove();
                }
            }
        }
    }
}
