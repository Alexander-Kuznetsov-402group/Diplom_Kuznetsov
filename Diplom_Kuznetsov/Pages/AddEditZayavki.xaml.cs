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
    /// Логика взаимодействия для AddEditZayavki.xaml
    /// </summary>
    public partial class AddEditZayavki : Page
    {
        private Zayavki _currentZayavki = new Zayavki();

        public AddEditZayavki(Zayavki selectedZayavki)
        {
            InitializeComponent();
            if (selectedZayavki != null)
                _currentZayavki = selectedZayavki;
            DataContext = _currentZayavki;

            ComBoxAgenta.ItemsSource = BD_DKuznetsovEntities.GetContext().Strahovoi_agent.ToList();
            ComBoxStraxovanie.ItemsSource = BD_DKuznetsovEntities.GetContext().Vidi_strahovki.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentZayavki.FIO))
                errors.AppendLine("Укажите ФИО Клиента");
            if (string.IsNullOrWhiteSpace(_currentZayavki.Telefon))
                errors.AppendLine("Укажите номер телефона");
            if (string.IsNullOrWhiteSpace(_currentZayavki.DR))
                errors.AppendLine("Укажите дату рождения Клиента");
            if (string.IsNullOrWhiteSpace(_currentZayavki.Adres))
                errors.AppendLine("Укажите адрес проживания");
            if (_currentZayavki.Vidi_strahovki == null)
                errors.AppendLine("Выберите страхование");

            if (_currentZayavki.Strahovoi_agent == null)
                errors.AppendLine("Выберите агента для страхования ");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentZayavki.Id_Zayavki == 0)
                BD_DKuznetsovEntities.GetContext().Zayavki.Add(_currentZayavki);
            try
            {
                BD_DKuznetsovEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
    }
}
