using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using BJJ9B1_HFT_2022231.Models;

namespace BJJ9B1_GUI_2022232.WpfClient.ViewModels
{
    public class StatisticsViewModel : ObservableRecipient
    {
        public static RestService rest;
        #region drivers
        public ObservableCollection<Drivers> britishDrivers { get; set; }
        public ObservableCollection<Drivers> BritishDrivers
        {
            get { return britishDrivers; }
            set
            {
                britishDrivers = value;
                OnPropertyChanged();
            }
        }
        public Drivers oldestDriver { get; set; }
        public Drivers OldestDriver
        {
            get { return oldestDriver; }
            set
            {
                oldestDriver = value;
                OnPropertyChanged();
            }
        }
        public Drivers youngestDriver { get; set; }
        public Drivers YoungestDriver
        {
            get { return youngestDriver; }
            set
            {
                youngestDriver = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region teams
        public Teams bestTeam { get; set; }
        public Teams BestTeam
        {
            get { return bestTeam; }
            set
            {
                bestTeam = value;
                OnPropertyChanged();
            }
        }
        public Teams worstTeam { get; set; }
        public Teams WorstTeam
        {
            get { return worstTeam; }
            set
            {
                worstTeam = value;
                OnPropertyChanged();
            }
        }
        public TeamPrincipals bestTeamPrincipal { get; set; }
        public TeamPrincipals BestTeamPrincipal
        {
            get { return bestTeamPrincipal; }
            set
            {
                bestTeamPrincipal = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Teams> teamsDebutIn20th { get; set; }
        public ObservableCollection<Teams> TeamsDebutIn20th
        {
            get { return teamsDebutIn20th; }
            set
            {
                teamsDebutIn20th = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region principals
        public TeamPrincipals mostChampionshipWinTeamPrincipal { get; set; }
        public TeamPrincipals MostChampionshipWinTeamPrincipal
        {
            get { return mostChampionshipWinTeamPrincipal; }
            set
            {
                mostChampionshipWinTeamPrincipal = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<TeamPrincipals> principalsWithWin { get; set; }
        public ObservableCollection<TeamPrincipals> PrincipalsWithWin
        {
            get { return principalsWithWin; }
            set
            {
                principalsWithWin = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<TeamPrincipals> principalWhoDebutedIn20thCentury { get; set; }
        public ObservableCollection<TeamPrincipals> PrincipalWhoDebutedIn20thCentury
        {
            get { return principalWhoDebutedIn20thCentury; }
            set
            {
                principalWhoDebutedIn20thCentury = value;
                OnPropertyChanged();
            }
        }
        public TeamPrincipals principalOfBestTeam { get; set; }
        public TeamPrincipals PrincipalOfBestTeam
        {
            get { return principalOfBestTeam; }
            set
            {
                principalOfBestTeam = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region commands
        public ICommand GetBritishDrivers { get; set; }
        public ICommand GetOldestDriver { get; set; }
        public ICommand GetYoungestDriver { get; set; }
        public ICommand GetBestTeam { get; set; }
        public ICommand GetWorstTeam { get; set; }
        public ICommand GetBestTeamPrincipal { get; set; }
        public ICommand TeamsDebutIn20thCentury { get; set; }
        public ICommand GetMostChampionshipWinTeamPrincipal { get; set; }
        public ICommand GetPrincipalsWithWin { get; set; }
        public ICommand GetPrincipalsWhoDebutedIn20thCentury { get; set; }
        public ICommand GetPrincipalOfBestTeam { get; set; }
        #endregion
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public StatisticsViewModel()
        {
            if (!IsInDesignMode)
            {
                rest = new RestService("http://localhost:12023/");
                #region drivers
                GetBritishDrivers = new RelayCommand(() =>
                {
                    var a = rest.Get<Drivers>($"http://localhost:12023/Statistics/GetBritishDrivers");
                    BritishDrivers = new ObservableCollection<Drivers>(a);
                });
                GetOldestDriver = new RelayCommand(() =>
                {
                    var a = rest.Get<Drivers>($"http://localhost:12023/Statistics/GetOldestDriver");
                    OldestDriver = a.First();
                });
                GetYoungestDriver = new RelayCommand(() =>
                {
                    var a = rest.Get<Drivers>($"http://localhost:12023/Statistics/GetYoungestDriver");
                    YoungestDriver = a.First();
                });
                #endregion
                #region teams
                GetBestTeam = new RelayCommand(() =>
                {
                    var a = rest.Get<Teams>($"http://localhost:12023/Statistics/GetBestTeam");
                    BestTeam = a.First();
                });
                GetWorstTeam = new RelayCommand(() =>
                {
                    var a = rest.Get<Teams>($"http://localhost:12023/Statistics/GetWorstTeam");
                    WorstTeam = a.First();
                });
                GetBestTeamPrincipal = new RelayCommand(() =>
                {
                    var a = rest.Get<TeamPrincipals>($"http://localhost:12023/Statistics/GetBestTeamPrincipal");
                    BestTeamPrincipal = a.First();
                });
                TeamsDebutIn20thCentury = new RelayCommand(() =>
                {
                    var a = rest.Get<Teams>($"http://localhost:12023/Statistics/TeamsDebutIn20thCentury");
                    TeamsDebutIn20th = new ObservableCollection<Teams>(a);
                });
                #endregion
                #region principals
                GetMostChampionshipWinTeamPrincipal = new RelayCommand(() =>
                {
                    var a = rest.Get<TeamPrincipals>($"http://localhost:12023/Statistics/GetMostChampionshipWinTeamPrincipal");
                    MostChampionshipWinTeamPrincipal = a.First();
                });
                GetPrincipalsWithWin = new RelayCommand(() =>
                {
                    var a = rest.Get<TeamPrincipals>($"http://localhost:12023/Statistics/GetPrincipalsWithWin");
                    PrincipalsWithWin = new ObservableCollection<TeamPrincipals>(a);
                });
                GetPrincipalsWhoDebutedIn20thCentury = new RelayCommand(() =>
                {
                    var a = rest.Get<TeamPrincipals>($"http://localhost:12023/Statistics/GetPrincipalWhoDebutedIn20thCentury");
                    PrincipalWhoDebutedIn20thCentury = new ObservableCollection<TeamPrincipals>(a);
                });
                GetPrincipalOfBestTeam = new RelayCommand(() =>
                {
                    var a = rest.Get<TeamPrincipals>($"http://localhost:12023/Statistics/GetPrincipalOfBestTeam");
                    PrincipalOfBestTeam = a.First();
                });
                #endregion
            }
        }
    }
}
