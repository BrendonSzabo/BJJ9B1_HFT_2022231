using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using BJJ9B1_HFT_2022231.Models;
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
    public class DriversViewModel : ObservableRecipient
    {
        public RestCollection<Drivers> Drivers { get; set; }

        private Drivers selectedDriver;

        public Drivers SelectedDriver
        {
            get { return selectedDriver; }
            set
            {
                if (value != null)
                {
                    selectedDriver = new Drivers()
                    {
                        DriverName = value.DriverName,
                        Id = value.Id
                    };
                }
                OnPropertyChanged();
                (DeleteDriverCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        public ICommand CreateDriverCommand { get; set; }
        public ICommand DeleteDriverCommand { get; set; }
        public ICommand UpdateDriverCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public DriversViewModel()
        {
            if (!IsInDesignMode)
            {
                Drivers = new RestCollection<Drivers>("http://localhost:12023/", "Drivers", "hub");

                CreateDriverCommand = new RelayCommand(() =>
                {
                    Drivers.Add(new Drivers()
                    {
                        DriverName = SelectedDriver.DriverName
                    });
                });

                DeleteDriverCommand = new RelayCommand(() =>
                {
                    Drivers.Delete(SelectedDriver.Id);
                },
                () =>
                {
                    return SelectedDriver != null;
                });

                UpdateDriverCommand = new RelayCommand(() =>
                {
                    Drivers.Update(SelectedDriver);
                });

                SelectedDriver = new Drivers();
            }
        }
    }
}
