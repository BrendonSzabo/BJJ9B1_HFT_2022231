using BJJ9B1_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace BJJ9B1_GUI_2022232.WpfClient
{
    internal class TeamPrincipalsViewModel : ObservableRecipient
    {
        public RestCollection<TeamPrincipals> TeamPrincipals { get; set; }

        private TeamPrincipals selectedTeamPrincipal;

        public TeamPrincipals SelectedTeamPrincipal
        {
            get { return selectedTeamPrincipal; }
            set
            {
                if (value != null)
                {
                    selectedTeamPrincipal = new TeamPrincipals()
                    {
                        PrincipalName = value.PrincipalName,
                        Id = value.Id,
                        Birth = value.Birth
                    };
                }
                OnPropertyChanged();
                (DeleteTeamPrincipalCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }



        public ICommand CreateTeamPrincipalCommand { get; set; }
        public ICommand DeleteTeamPrincipalCommand { get; set; }
        public ICommand UpdateTeamPrincipalCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public TeamPrincipalsViewModel()
        {
            if (!IsInDesignMode)
            {
                TeamPrincipals = new RestCollection<TeamPrincipals>("http://localhost:12023/", "TeamPrincipals", "hub");

                CreateTeamPrincipalCommand = new RelayCommand(() =>
                {
                    TeamPrincipals.Add(new TeamPrincipals()
                    {
                        PrincipalName = SelectedTeamPrincipal.PrincipalName,
                        Birth = SelectedTeamPrincipal.Birth
                    });
                });

                DeleteTeamPrincipalCommand = new RelayCommand(() =>
                {
                    TeamPrincipals.Delete(SelectedTeamPrincipal.Id);
                },
                () =>
                {
                    return SelectedTeamPrincipal != null;
                }
                );

                UpdateTeamPrincipalCommand = new RelayCommand(() =>
                {
                    TeamPrincipals.Update(SelectedTeamPrincipal);
                });

                SelectedTeamPrincipal = new TeamPrincipals();
            }
        }
    }
}
