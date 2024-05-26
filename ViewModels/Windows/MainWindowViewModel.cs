using System.Collections.ObjectModel;
using DdApp.Entities;
using Wpf.Ui.Controls;

namespace DdApp.ViewModels.Windows
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty] private string _applicationTitle = "Студенты";

        [ObservableProperty] private ObservableCollection<object> _menuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Главная",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
                TargetPageType = typeof(Views.Pages.DashboardPage)
            },
            new NavigationViewItem()
            {
                Content = "Специальности",
                Icon = new SymbolIcon { Symbol = SymbolRegular.HatGraduation24 },
                TargetPageType = typeof(Views.Pages.SpecialityPage)
            },
            new NavigationViewItem()
            {
                Content = "Студенты",
                Icon = new SymbolIcon { Symbol = SymbolRegular.People24 },
                TargetPageType = typeof(Views.Pages.StudentPage)
            },
            new NavigationViewItem()
            {
                Content = "Предметы",
                Icon = new SymbolIcon { Symbol = SymbolRegular.Book24 },
                TargetPageType = typeof(Views.Pages.SubjectPage)
            },
            new NavigationViewItem()
            {
                Content = "Оценки",
                FontSize = 8,
                Icon = new SymbolIcon { Symbol = SymbolRegular.TextNumberListLtr24 },
                TargetPageType = typeof(Views.Pages.GradesPage)
            },
        };

        [ObservableProperty] private ObservableCollection<object> _footerMenuItems = new()
        {
            new NavigationViewItem()
            {
                Content = "Настройки",
                FontSize = 10,
                Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
                TargetPageType = typeof(Views.Pages.SettingsPage)
            }
        };

        [ObservableProperty] private ObservableCollection<MenuItem> _trayMenuItems = new()
        {
            new MenuItem { Header = "Home", Tag = "tray_home" }
        };
    }
}