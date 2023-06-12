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
    /// Логика взаимодействия для Add_Admin_zayavki.xaml
    /// </summary>
    public partial class Add_Admin_zayavki : Window
    {
        public Add_Admin_zayavki()
        {
            InitializeComponent();
            Manager.MainFrame = myFrame;
            myFrame.Navigate(new Pages.Create());
        }
    }
}
