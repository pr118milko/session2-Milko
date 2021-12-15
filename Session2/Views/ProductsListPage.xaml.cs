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

namespace Session2.Views
{
    /// <summary>
    /// Логика взаимодействия для ProductsListPage.xaml
    /// </summary>
    public partial class ProductsListPage : Page
    {
        public ProductsListPage()
        {
            InitializeComponent();
            productsList.ItemsSource = user11Entities.GetContext().Products.ToList();
            ComboProductsTypes.ItemsSource = user11Entities.GetContext().ProductsTypes.ToList();
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            string searchText = search.Text.ToString();
            productsList.ItemsSource = user11Entities.GetContext().Products.Where(item => item.Name.Contains(searchText)).ToList();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboSort.SelectedIndex) {
                case 0:
                    productsList.ItemsSource = user11Entities.GetContext().Products.ToList().OrderByDescending(item => item.Name); 
                    break;
                case 1:
                    productsList.ItemsSource = user11Entities.GetContext().Products.ToList().OrderBy(item => item.Name);
                    break;
                case 2:
                    productsList.ItemsSource = user11Entities.GetContext().Products.ToList().OrderByDescending(item => item.FactoryID);
                    break;
                case 3:
                    productsList.ItemsSource = user11Entities.GetContext().Products.ToList().OrderBy(item => item.FactoryID);
                    break;
                case 4:
                    productsList.ItemsSource = user11Entities.GetContext().Products.ToList().OrderByDescending(item => item.MinPrice);
                    break;
                case 5:
                    productsList.ItemsSource = user11Entities.GetContext().Products.ToList().OrderBy(item => item.MinPrice);
                    break;
                default:
                    productsList.ItemsSource = user11Entities.GetContext().Products.ToList().OrderBy(item => item.Name);
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ComboProductsTypes_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            var productType = (ProductsTypes)ComboProductsTypes.SelectedItem;
            productsList.ItemsSource = user11Entities.GetContext().Products.Where(item => item.ProductTypeID == productType.ID).ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigateManager.MainFrame.Navigate(new AddProductsPage());
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ProductsList_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void ProductsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var product = (Products)productsList.SelectedItem;
            NavigateManager.MainFrame.Navigate(new EditProductsPage(product));
        }
    }
}
