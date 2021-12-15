using Session2.Views;
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

namespace Session2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigateManager.MainFrame = MainFrame;
            NavigateManager.MainFrame.Navigate(new ProductsListPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigateManager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (NavigateManager.MainFrame.CanGoBack)
            {
                buttonBack.Visibility = Visibility.Visible;
            }
            else
                buttonBack.Visibility = Visibility.Hidden;
        }
        
    }
}
