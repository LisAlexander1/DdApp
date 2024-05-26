using DdApp.Entities;
using DdApp.Models;
using DdApp.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace DdApp.Views.Pages
{
    public partial class GradesPage : IFormPage<GradesViewModel, Grades>, INavigableView<GradesViewModel>
    {
        public GradesPage(GradesViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        public GradesViewModel ViewModel { get; }
    }
}
