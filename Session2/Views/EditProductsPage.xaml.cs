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
    /// Логика взаимодействия для EditProductsPage.xaml
    /// </summary>
    public partial class EditProductsPage : Page
    {
        public EditProductsPage(Products product)
        {
            InitializeComponent();
            _currentProduct = product;
            comboTypes.ItemsSource = user11Entities.GetContext().ProductsTypes.ToList();
            DataContext = _currentProduct;

        }
        public Products _currentProduct; 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы точно хотите удалить данный элемент?", null, MessageBoxButton.YesNo);
            user11Entities.GetContext().Products.Remove(_currentProduct);
            NavigateManager.MainFrame.Navigate(new ProductsListPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                user11Entities.GetContext().Products.Add(_currentProduct);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message);
                return;
            }
            user11Entities.GetContext().SaveChanges();
            MessageBox.Show("Новая продукция успешно добавлена!");
        }
    }
}
