using System.Windows.Input;
using DdApp.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace DdApp.Views.Pages
{
    public partial class SpecialityPage : INavigableView<SpecialityViewModel>
    {
        public SpecialityViewModel ViewModel { get; }

        public SpecialityPage(SpecialityViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;

            InitializeComponent();
        }

        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Return) return;
            ItemCountTextBlock.Focus();
        }
    }
}
