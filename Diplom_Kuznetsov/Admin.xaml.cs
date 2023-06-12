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

namespace Diplom_Kuznetsov
{

    public partial class Admin : Window
    {



        public Admin()
        {
            InitializeComponent();
            DStrah.ItemsSource = BD_DKuznetsovEntities.GetContext().Vidi_strahovki.ToList();
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Pages.Add_Admin_zayavki add_Admin_Zayavki = new Pages.Add_Admin_zayavki();
            add_Admin_Zayavki.Show();
        }

        private void BtnEditStrahovka_Click(object sender, RoutedEventArgs e)
        {
            Pages.AddEdit_vidi_strahovki addEdit_Vidi_Strahovki = new Pages.AddEdit_vidi_strahovki(null);
            addEdit_Vidi_Strahovki.Show();

        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BD_DKuznetsovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(u => u.Reload());
                DStrah.ItemsSource = BD_DKuznetsovEntities.GetContext().Vidi_strahovki.ToList();
            }
        }
           
    }
}
