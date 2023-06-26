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
    public partial class Log : Page
    {
        public Log()
        {
            InitializeComponent();
        }

        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.Reg(null));
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.modelOdb.User.FirstOrDefault(x => x.Login == tb1.Text && x.Password == tb2.Password);
                if (userObj == null) 
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch (userObj.Id_Role)
                    {
                        case 1: MessageBox.Show("Здравствуйте, Агент007", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Admin admin = new Admin();
                            admin.Show();
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, Пользователь", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            Users users = new Users();
                            users.Show();
                            break;
                        default: MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK,MessageBoxImage.Warning); break;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            Users users = new Users();
            users.Show();
        }
    }
}
