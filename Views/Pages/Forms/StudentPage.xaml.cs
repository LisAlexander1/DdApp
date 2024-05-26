using DdApp.Entities;
using DdApp.Models;
using DdApp.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace DdApp.Views.Pages
{
    public partial class StudentPage : IFormPage<StudentViewModel, Student>, INavigableView<StudentViewModel>
    {
        public StudentPage(StudentViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        public StudentViewModel ViewModel { get; }
    }
}
