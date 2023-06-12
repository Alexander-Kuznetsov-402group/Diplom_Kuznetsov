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

namespace Diplom_Kuznetsov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();
            DStrah.ItemsSource = BD_DKuznetsovEntities.GetContext().Vidi_strahovki.ToList();
        }

 

        private void BtOfis_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Адрес офиса: пр.Мира 2 офис 3 \nТелефон: 8(914) 276-09-12");
        }
    

    private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            BD_DKuznetsovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            DStrah.ItemsSource = BD_DKuznetsovEntities.GetContext().Vidi_strahovki.ToList();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
