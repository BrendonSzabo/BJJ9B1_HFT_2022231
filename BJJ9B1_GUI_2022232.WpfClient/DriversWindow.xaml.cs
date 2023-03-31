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
    public partial class DriversWindow : Window
    {
        private Window indexWindow;
        public DriversWindow()
        {
            InitializeComponent();
        }
        public DriversWindow(Window mainWindow, string imagesDir)
        {
            InitializeComponent();
            this.indexWindow = mainWindow;
            indexWindow.Hide();
            BitmapImage background = new BitmapImage();
            background.BeginInit();
            background.UriSource = new Uri($"{imagesDir}/charactercreator.jpg");
            background.EndInit();
            mainGrid_BG.ImageSource = background;
        }
        private void mainWindow_Closed(object sender, EventArgs e)
        {
            indexWindow.Show();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
