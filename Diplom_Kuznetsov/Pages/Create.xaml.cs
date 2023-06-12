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
    /// <summary>
    /// Логика взаимодействия для Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        public Create()
        {
            InitializeComponent();
            DtGridStrahovka.ItemsSource = BD_DKuznetsovEntities.GetContext().Zayavki.ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BD_DKuznetsovEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(u => u.Reload());
                DtGridStrahovka.ItemsSource = BD_DKuznetsovEntities.GetContext().Zayavki.ToList();
            }
        }

        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.AddEditZayavki(null));
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.AddEditZayavki((sender as Button).DataContext as Zayavki));
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            var tovarForRemoving = DtGridStrahovka.SelectedItems.Cast<Zayavki>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {tovarForRemoving.Count()} элемент?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BD_DKuznetsovEntities.GetContext().Zayavki.RemoveRange(tovarForRemoving);
                    BD_DKuznetsovEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DtGridStrahovka.ItemsSource = BD_DKuznetsovEntities.GetContext().Zayavki.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
