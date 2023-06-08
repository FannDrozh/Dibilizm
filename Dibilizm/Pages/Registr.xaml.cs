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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Page
    {
        public Frame frame1;
        public Registr(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Avtor(frame1));
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            List<Users> user = new List<Users>() { new Users() };
            string log = Log.Text;
            string pas = Pas.Text;
            user[0].login = log;
            user[0].password = pas;
            Entities.GetContext().Users.Add(user[0]);
            Entities.GetContext().SaveChanges();
            frame1.Navigate(new Avtor(frame1));
        }
    }
}
