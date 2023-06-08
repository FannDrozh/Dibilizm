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
    /// Логика взаимодействия для Avtor.xaml
    /// </summary>
    public partial class Avtor : Page
    {
        public Frame frame1;
        public Avtor(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
        }

        private void Entre_Click(object sender, RoutedEventArgs e)
        {
            var Userlog = Entities.GetContext().Users.ToList();
            int countUser = Entities.GetContext().Users.Count();
            for (int i = 0; i < countUser; i++)
            {
                if (Log.Text == Userlog[i].login)
                {
                    if (Pas.Password == Userlog[i].password)
                    {
                        frame1.Navigate(new Glavnaya(frame1));
                    }
                }
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Registr(frame1));
        }
    }
}
