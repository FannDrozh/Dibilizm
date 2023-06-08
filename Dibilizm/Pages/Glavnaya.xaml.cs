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

namespace Dibilizm.Pages
{
    /// <summary>
    /// Логика взаимодействия для Glavnaya.xaml
    /// </summary>
    public partial class Glavnaya : Page
    {
        /// <summary>
        /// 
        /// </summary>
        public Frame frame1;
        List<Product> products = new List<Product>();
        List<Table> tables = new List<Table> { new Table() };
        public Glavnaya(Frame frame)
        {
            InitializeComponent();
            products = Entities.GetContext().Product.ToList();
            ProdL.ItemsSource = products;
            frame1 = frame;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            object item = ProdL.SelectedItem;
            List<Product> p = new List<Product> { new Product() };
            List<Table> t1 = Entities.GetContext().Table.ToList();
            p[0] = (Product)item;
            tables[0].Title = p[0].Title;
            tables[0].Koli = 1;
            tables[0].MinCostForAgent = p[0].MinCostForAgent;
            tables[0].ArticleNumber = p[0].ArticleNumber;
            if (t1.Count == 0)
            {
                Entities.GetContext().Table.Add(tables[0]);
            }
            else
            {
                for(int i = 0; i < t1.Count; i++)
                {
                    if (p[0].Title == t1[i].Title)
                    {
                        t1[i].Koli += 1;
                        break;
                    }
                    else
                    {
                        Entities.GetContext().Table.Add(tables[0]);
                        break;
                    }
                }
            }
            Entities.GetContext().SaveChanges();
            MessageBox.Show("Продукт добавлен в корзину", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            Basket backet = new Basket();
            backet.ShowDialog();



        }

        private void DElProd_Click(object sender, RoutedEventArgs e)
        {
            object item = ProdL.SelectedItem;
            List<Product> products1 = new List<Product> { new Product() };
            products1[0] = (Product)item;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].ID == products1[0].ID)
                {
                    Entities.GetContext().Product.Remove(products[i]);
                    Entities.GetContext().SaveChanges();
                    frame1.Navigate(new Glavnaya(frame1));
                }
            }
        }

        private void BasketProd_Click(object sender, RoutedEventArgs e)
        {
            Basket basket = new Basket();
            basket.ShowDialog();
        }
    }
}
