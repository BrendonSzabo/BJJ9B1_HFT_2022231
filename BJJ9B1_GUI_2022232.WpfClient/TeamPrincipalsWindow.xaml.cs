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
    /// Interaction logic for TeamPrincipals.xaml
    /// </summary>
    public partial class TeamPrincipalsWindow : Window
    {
        private Window indexWindow;
        public TeamPrincipalsWindow()
        {
            InitializeComponent();
        }
        public TeamPrincipalsWindow(Window mainWindow, string imagesDir)
        {
            InitializeComponent();
            this.indexWindow = mainWindow;
            indexWindow.Hide();
            BitmapImage background = new BitmapImage();
            background.BeginInit();
            background.UriSource = new Uri($"{imagesDir}/f1teamprincipals.jpg");
            background.EndInit();
            mainGrid_BG.ImageSource = background;
        }
        private void mainWindow_Closed(object sender, EventArgs e)
        {
            indexWindow.Show();
        }
    }
}
