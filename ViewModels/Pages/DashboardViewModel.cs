using System.Collections.ObjectModel;
using DdApp.Views.Pages;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace DdApp.ViewModels.Pages
{
    public partial class DashboardViewModel(INavigationService navigationService) : ObservableObject
    {
        private INavigationService NavigationService { get; } = navigationService;


        [RelayCommand]
        private void NavigateToSpeciality()
        {
            NavigationService.Navigate(typeof(SpecialityPage));
        }
        
        [RelayCommand]
        private void NavigateToStudents()
        {
            NavigationService.Navigate(typeof(StudentPage));
        }
        
        [RelayCommand]
        private void NavigateToGrades()
        {
            NavigationService.Navigate(typeof(GradesPage));
        }
        
        [RelayCommand]
        private void NavigateToSubjects()
        {
            NavigationService.Navigate(typeof(SubjectPage));
        }
    }
}
