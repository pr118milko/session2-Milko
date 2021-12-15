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
    /// Логика взаимодействия для AddProductsPage.xaml
    /// </summary>
    public partial class AddProductsPage : Page
    {
        public AddProductsPage()
        {
            InitializeComponent();
            comboTypes.ItemsSource = user11Entities.GetContext().ProductsTypes.ToList();
            DataContext = _currentProduct;
        }
        public Products _currentProduct;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user11Entities.GetContext().Products.Add(_currentProduct);
            }
            catch(ArgumentNullException ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message);
                return;
            }
            MessageBox.Show("Продукция успешно изменена!");
        }
    }
}


    









//namespace _3week.Views
//{
//    /// <summary>
//    /// Логика взаимодействия для AddNewAgentPage.xaml
//    /// </summary>
//    public partial class AddNewAgentPage : Page
//    {
//        private Agents _currentAgent = new Agents();
//        public AddNewAgentPage()
//        {
//            InitializeComponent();
//            DataContext = _currentAgent;
//            comboType.ItemsSource = NewProductsDBEntities.GetContext().AgentsTypes.ToList();
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {
//            StringBuilder errors = new StringBuilder();
//            if (errors.Length > 0)
//            {
//                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
//                return;
//            }
//            NewProductsDBEntities.GetContext().Agents.Add(_currentAgent);
//            try
//            {
//                NewProductsDBEntities.GetContext().SaveChanges();
//                MessageBox.Show("Агент добавлен!");
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message.ToString());
//            }
//        }
//    }
//}

