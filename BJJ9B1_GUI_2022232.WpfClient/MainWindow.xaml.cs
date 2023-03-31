using System;
using System.Collections.Generic;
using System.IO;
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

namespace BJJ9B1_GUI_2022232.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string imagesDir = "";
        public MainWindow()
        {
            InitializeComponent();
            imagesDir = Directory.GetCurrentDirectory() + "/images";

        }
        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                BitmapImage background = new BitmapImage();
                background.BeginInit();
                Button button = (Button)sender;
                if (button.Name == "drivers")
                {
                    background.UriSource = new Uri($"{imagesDir}/2022Grid.jpg");
                }
                else if (button.Name == "teams")
                {
                    background.UriSource = new Uri($"{imagesDir}/f1teams.png");
                }
                else if (button.Name == "teamprincipals")
                {
                    background.UriSource = new Uri($"{imagesDir}/f1teamprincipals.jpg");
                }
                else if (button.Name == "statistics")
                {
                    background.UriSource = new Uri($"{imagesDir}/statistics.jpg");
                }
                background.EndInit();
                mainGrid_BG.ImageSource = background;
            }
        }
        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage background = new BitmapImage();
            background.BeginInit();
            background.UriSource = new Uri($"{imagesDir}/f1logo.png");
            background.EndInit();
            mainGrid_BG.ImageSource = background;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ;
            if (sender is Button)
            {
                Button button = (Button)sender;
                string name = button.Name;
                if (button.Name == "drivers")
                {
                    Drivers driverWindow = new Drivers(mainWindow);
                    driverWindow.Show();
                }
                else if (button.Name == "teams")
                {
                    Teams teamsWindow = new Teams(mainWindow);
                    teamsWindow.Show();
                }
                else if (button.Name == "teamprincipals")
                {
                    TeamPrincipals teamPrincipals = new TeamPrincipals(mainWindow);
                    teamPrincipals.Show();
                }
                else if (button.Name == "statistics")
                {
                    Statistics statistics = new Statistics(mainWindow);
                    statistics.Show();
                }
                else if (button.Name == "exit")
                {
                    mainWindow.Close();
                }
            }
        }

    }
}
