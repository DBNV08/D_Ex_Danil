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

namespace D_Ex_Danil.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        DExEntities db = new DExEntities();
        Product current = new Product();
        public AddProduct()
        {
            InitializeComponent();

            if (product != null)
            {
                current = db.Product.Where(w => w.ID_Product == product.ID).ToList().FirstOrDefault();
            }

            DataContext = current;
            Producer.ItemsSource = db.Producer.ToList();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Iamge.Text != "")
                    current.Image = Iamge.Text;
                if (Discount.Text != "")
                    current.Discount = Convert.ToInt32(Discount.Text);
                if (Producer.SelectedIndex != -1)
                    current.ID_Producer = (Producer.SelectedItem as Producer).ID_Producer;

                db.Product.AddOrUpdate(current);
                db.SaveChanges();
                MessageBox.Show("Данные сохранены успешно!", "Сохранено", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Проверьте правильно ли заполнены все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Count_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private void TextBlock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        private void Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
    }
}
