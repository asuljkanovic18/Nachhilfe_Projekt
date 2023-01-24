using Northwnd_DbLib;
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

namespace Nachhilfe_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindContext _db;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var category = new Category
            {
                CategoryName = CategoryNameTextBox.Text,
                Description = CategoryDescriptionTextBox.Text
            };
            _db.Categories.Add(category);
            _db.SaveChanges();

            CategoryNameTextBox.Text = "";
            CategoryDescriptionTextBox.Text = "";
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _db = new NorthwindContext();
            dg_Products.ItemsSource= _db.Products.ToList();
        }

        private void CreateProductButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new product
            var product = new Product
            {
                ProductName = ProductNameTextBox.Text,
                SupplierId = int.Parse(SupplierIDTextBox.Text),
                CategoryId = int.Parse(CategoryIDTextBox.Text),
                QuantityPerUnit = QuantityPerUnitTextBox.Text,
                UnitPrice = (decimal) double.Parse(UnitPriceTextBox.Text)
            };

            _db.Products.Add(product);
            _db.SaveChanges();

            dg_Products.ItemsSource = null;
            dg_Products.ItemsSource = _db.Products.ToList();
        }
    }
}
