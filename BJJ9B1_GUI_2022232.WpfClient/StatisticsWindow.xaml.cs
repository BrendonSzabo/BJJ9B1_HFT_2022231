using BJJ9B1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {
        private Window indexWindow;
        public StatisticsWindow()
        {
            InitializeComponent();
        }
        public StatisticsWindow(Window mainWindow, string imagesDir)
        {
            InitializeComponent();
            this.indexWindow = mainWindow;
            indexWindow.Hide();
            BitmapImage background = new BitmapImage();
            background.BeginInit();
            background.UriSource = new Uri($"{imagesDir}/f1stats.png");
            background.EndInit();
            mainGrid_BG.ImageSource = background;
        }

        private void mainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            indexWindow.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            switch (btn.Name)
            {
                case "british":
                    Loadout(britishDrivers.Items);
                    break;
                case "oldest":
                    Loadout(oldestDriver.Content);
                    break;
                case "youngest":
                    Loadout(youngestDriver.Content);
                    break;
                case "bestteam":
                    Loadout(bestTeam.Content);
                    break;
                case "worstteam":
                    Loadout(worstTeam.Content);
                    break;
                case "bestprinc":
                    Loadout(bestTeamPrincipal.Content);
                    break;
                case "teams20":
                    Loadout(teamsDebutIn20th.Items);
                    break;
                case "champ":
                    Loadout(mostChampionshipWinTeamPrincipal.Content);
                    break;
                case "wins":
                    Loadout(principalsWithWin.Items);
                    break;
                case "princ20":
                    Loadout(principalWhoDebutedIn20thCentury.Items);
                    break;
                case "princbest":
                    Loadout(principalOfBestTeam.Content);
                    break;
                default: break;
            }
        }
        private void Loadout(object values)
        {
            if (values == null)
            {
                MainBox.Items.Clear();
                MainBox.Items.Add("Click again please im buggy.");
            }
            else
            {
                if (values is ItemCollection)
                {
                    List<string> strings = new List<string>();
                    foreach (var item in values as ItemCollection)
                    {
                        strings.Add(item.ToString());
                    }
                    MainBox.Items.Clear();
                    foreach (string value in strings)
                    {
                        MainBox.Items.Add(value);
                    }
                }
                else
                {
                    if (values is Drivers)
                    {
                        MainBox.Items.Clear();
                        MainBox.Items.Add((values as Drivers).ToString());
                    }
                    else if (values is Teams)
                    {
                        MainBox.Items.Clear();
                        MainBox.Items.Add((values as Teams).ToString());
                    }
                    else
                    {
                        MainBox.Items.Clear();
                        MainBox.Items.Add((values as TeamPrincipals).ToString());
                    }

                }
            }
        }
    }
}
