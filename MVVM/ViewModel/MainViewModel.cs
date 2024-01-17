using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFNavigation.Core;
using WPFNavigation.Services;

namespace WPFNavigation.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {
        private INavigationService _navigationService;
        public INavigationService NavigationService
        {
            get { return _navigationService; }
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToSettingsCommand { get; set; }
        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigateToHomeCommand = new RelayCommand(execute: o => { NavigationService.NavigateTo<HomeViewModel>(); }, canExecute: o => true);
            NavigateToSettingsCommand = new RelayCommand(execute: o => { NavigationService.NavigateTo<SettingsViewModel>(); }, canExecute: o => true);
        }
    }
}
