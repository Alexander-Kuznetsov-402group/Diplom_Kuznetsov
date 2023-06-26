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
    /// Логика взаимодействия для Pechat.xaml
    /// </summary>
    public partial class Pechat : Window
    {
        public Pechat()
        {
            InitializeComponent();
        }

        private void BtClick_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog p = new PrintDialog();
                if (p.ShowDialog() == true)
            {
                p.PrintVisual(Grid_Document, "Печать");
            }
        }
    }
}
