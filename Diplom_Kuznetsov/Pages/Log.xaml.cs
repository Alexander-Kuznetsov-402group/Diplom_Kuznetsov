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
            Manager.MainFrame.Navigate(new Pages.Reg());
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
