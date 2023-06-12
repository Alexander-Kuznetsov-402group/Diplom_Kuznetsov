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

namespace Diplom_Kuznetsov.Pages
{
  
    public partial class Reg : Page
    {

        

        public Reg(User selectedUser)
        {
            InitializeComponent();
          
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Log());
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.modelOdb.User.Count(x => x.Login == tb1.Text) > 0)
            {
                MessageBox.Show("Пользователя с таким логином есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                User userObj = new User()
                {
                    Login = tb1.Text,
                    Password = tb2.Password,
                    Id_Role = 2
                };
                AppConnect.modelOdb.User.Add(userObj);
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK,MessageBoxImage.Error); 
            }
        }
    }
}
