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

namespace D_Ex_Danil
{
    /// <summary>
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        DExEntities db = new DExEntities();
        public Autorization()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            var login = log.Text;
            var password = pass.Password;
            var bd = new DExEntities();
            var user = bd.User.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
            if (user != null)
            {
                new Autorization().Show();
                this.Close();
            }
            else
                MessageBox.Show("Данные не верны", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btn_LoginGhost_Click(object sender, RoutedEventArgs e)
        {
            WindowForView win = new WindowForView(null);
            win.Show();
            this.Close();
        }
    }
}
