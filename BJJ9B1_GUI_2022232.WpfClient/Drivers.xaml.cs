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

namespace BJJ9B1_GUI_2022232.WpfClient
{
    /// <summary>
    /// Interaction logic for Drivers.xaml
    /// </summary>
    public partial class Drivers : Window
    {
        private Window indexWindow;
        public Drivers()
        {
            InitializeComponent();
        }
        public Drivers(Window mainWindow)
        {
            InitializeComponent();
            this.indexWindow = mainWindow;
            indexWindow.Hide();
        }
        private void mainWindow_Closed(object sender, EventArgs e)
        {
            indexWindow.Show();
            this.Close();
        }
    }
}
