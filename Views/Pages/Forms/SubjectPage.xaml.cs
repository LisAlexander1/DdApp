using DdApp.Entities;
using DdApp.Models;
using DdApp.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace DdApp.Views.Pages
{
    public partial class SubjectPage : IFormPage<SubjectViewModel, Subject>, INavigableView<SubjectViewModel>
    {
        public SubjectPage(SubjectViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        public SubjectViewModel ViewModel { get; }
    }
}
