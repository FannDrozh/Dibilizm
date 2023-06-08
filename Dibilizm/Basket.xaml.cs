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
using System.Windows.Shapes;

namespace Dibilizm
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class Basket : Window
    {
        List<Table> tables = new List<Table>();

        public Basket()
        {
            InitializeComponent();
            tables = Entities.GetContext().Table.ToList();
            LBasket.ItemsSource = tables;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintVisual(LBasket, "");
            Entities.GetContext().Table.RemoveRange(tables);
            Entities.GetContext().SaveChanges();
            LBasket.ItemsSource = tables;
        }
        private async void Minus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(100);
            List<Table> t = new List<Table> { new Table() };
            List<Table> t1 = Entities.GetContext().Table.ToList();
            t[0] = LBasket.SelectedItem as Table;
            for (int i = 0; i < t1.Count; i++)
            {
                if (t1[i].id == t[i].id)
                {
                    t1[i].Koli -= 1;
                }
            }
            for (int i = 0; i < t1.Count; i++)
            {
                if (t1[i].id == t[i].id)
                {
                    if (t1[i].Koli == 0)
                    {
                        Entities.GetContext().Table.Remove(t[i]);
                    }
                }
            }
            Entities.GetContext().SaveChanges();
            LBasket.ItemsSource = Entities.GetContext().Table.ToList();
            int c = 0;
            for (int i = 0; c < t1.Count; i++)
            {
                c += Convert.ToInt32(t1[i].MinCostForAgent) * Convert.ToInt32(t1[i].Koli);
            }
            PriceP.Content = Convert.ToString(c + " руб.");
        }

        private async void Plus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            await Task.Delay(100);
            List<Table> t = new List<Table> { new Table() };
            List<Table> t1 = Entities.GetContext().Table.ToList();
            t[0] = LBasket.SelectedItem as Table;
            for (int i = 0; i < t1.Count; i++)
            {
                if (t1[0].id == t[0].id)
                {
                    t1[0].Koli += 1;
                }
            }
            Entities.GetContext().SaveChanges();
            LBasket.ItemsSource = tables;
            int c = 0;
            for (int i = 0; i < t1.Count; i++)
            {
                c += Convert.ToInt32(t1[i].MinCostForAgent) * Convert.ToInt32(t1[i].Koli);
            }
            PriceP.Content = Convert.ToString(c + " руб.");
        }
    }
}
