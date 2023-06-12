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
    /// Логика взаимодействия для AddEdit_vidi_strahovki.xaml
    /// </summary>
    public partial class AddEdit_vidi_strahovki : Window
    {
        private Vidi_strahovki _currentVidiStrahovania= new Vidi_strahovki();

        public AddEdit_vidi_strahovki(Vidi_strahovki currentVidiStrahovki)
        {
            InitializeComponent();
            if (currentVidiStrahovki != null)
                _currentVidiStrahovania = currentVidiStrahovki;
            DataContext = _currentVidiStrahovania;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder(); 

            if (string.IsNullOrWhiteSpace(_currentVidiStrahovania.Nazvanie))
                errors.AppendLine("Введмите название страховании");

            if (string.IsNullOrWhiteSpace(_currentVidiStrahovania.Description))
                errors.AppendLine("Введите описание страховки");

            if (_currentVidiStrahovania.Money <= 0)
                errors.AppendLine("Цена не может быть меньше или равно 0");

            if (string.IsNullOrWhiteSpace(_currentVidiStrahovania.Date_deistvia))
                errors.AppendLine("Укажите дату действия страховании");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentVidiStrahovania.Id_Strahovki == 0)

                BD_DKuznetsovEntities.GetContext().Vidi_strahovki.Add(_currentVidiStrahovania);
            try
            {
                BD_DKuznetsovEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
