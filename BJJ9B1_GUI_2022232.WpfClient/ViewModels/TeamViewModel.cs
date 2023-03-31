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
    internal class TeamViewModel : ObservableRecipient
    {
        public RestCollection<Teams> Teams { get; set; }

        private Teams selectedTeam;

        public Teams SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (value != null)
                {
                    selectedTeam = new Teams()
                    {
                        TeamName = value.TeamName,
                        Id = value.Id
                    };
                }
                OnPropertyChanged();
                (DeleteTeamCommand as RelayCommand).NotifyCanExecuteChanged();

            }
        }

        public ICommand CreateTeamCommand { get; set; }
        public ICommand DeleteTeamCommand { get; set; }
        public ICommand UpdateTeamCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public TeamViewModel()
        {
            if (!IsInDesignMode)
            {
                Teams = new RestCollection<Teams>("http://localhost:12023/", "Teams", "hub");

                CreateTeamCommand = new RelayCommand(() =>
                {
                    Teams.Add(new Teams()
                    {
                        TeamName = SelectedTeam.TeamName
                    });
                });

                DeleteTeamCommand = new RelayCommand(() =>
                {
                    Teams.Delete(SelectedTeam.Id);
                },
                () =>
                {
                    return SelectedTeam != null;
                }
                );

                UpdateTeamCommand = new RelayCommand(() =>
                {
                    Teams.Update(SelectedTeam);
                });

                SelectedTeam = new Teams();
            }
        }
    }
}
