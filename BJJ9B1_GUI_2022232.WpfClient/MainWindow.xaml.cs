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
            setBG("f1logo.png", mainGrid_BG);
        }
        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                if (button.Name == "drivers")
                {
                    setBG("2022Grid.jpg", mainGrid_BG);
                    description.Text = "Drivers and information about them";
                }
                else if (button.Name == "teams")
                {
                    setBG("f1teams.png", mainGrid_BG);
                    description.Text = "Teams and information about them";
                }
                else if (button.Name == "teamprincipals")
                {
                    setBG("f1teamprincipals.jpg", mainGrid_BG);
                    description.Text = "Team Principals and information about them";
                }
                else if (button.Name == "exit")
                {
                    setBG("f1logo.png", mainGrid_BG);
                    description.Text = "Exit";
                }
            }
        }
        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            setBG("f1logo.png", mainGrid_BG);
            description.Text = "Button descriptions here";
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
                    DriversWindow driverWindow = new DriversWindow(mainWindow,imagesDir);
                    driverWindow.Show();
                }
                else if (button.Name == "teams")
                {
                    TeamsWindow teamsWindow = new TeamsWindow(mainWindow,imagesDir);
                    teamsWindow.Show();
                }
                else if (button.Name == "teamprincipals")
                {
                    TeamPrincipalsWindow teamPrincipals = new TeamPrincipalsWindow(mainWindow, imagesDir);
                    teamPrincipals.Show();
                }
                else if (button.Name == "exit")
                {
                    mainWindow.Close();
                }
            }
        }

        private void setBG(string img, ImageBrush image)
        {
            BitmapImage background = new BitmapImage();
            background.BeginInit();
            background.UriSource = new Uri($"{imagesDir}/{img}");
            background.EndInit();
            image.ImageSource = background;
        }
    }
}
