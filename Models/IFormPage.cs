using DdApp.ViewModels.Pages;

namespace DdApp.Models;

public interface IFormPage<out TViewModel,TEntity> where TViewModel : FormViewModel<TEntity> where TEntity : class
{ 
    TViewModel ViewModel { get; }
}