using System.Collections.ObjectModel;
using DdApp.Context;
using DdApp.Extensions;
using DdApp.Models;
using Microsoft.EntityFrameworkCore;
using Wpf.Ui.Controls;

namespace DdApp.ViewModels.Pages;

public abstract partial class FormViewModel<TEntity>(StudentsDbContext studentsDbContext)
    : ObservableObject, INavigationAware where TEntity : class
{
    private StudentsDbContext StudentsDbContext { get; } = studentsDbContext;

    [ObservableProperty]
    private int _index;

    [ObservableProperty]
    private ObservableCollection<Item<TEntity>> _itemsList = [];

    [ObservableProperty]
    private Item<TEntity>? _selectedItem;

    [ObservableProperty]
    private bool _isNewItem;

    [ObservableProperty]
    private bool _isDeleteItem;

    partial void OnIndexChanged(int oldValue,int newValue)
    {
        
    }

    partial void OnItemsListChanged(ObservableCollection<Item<TEntity>> value)
    {
        
    }

    partial void OnSelectedItemChanged(Item<TEntity>? value)
    {
        
    }

    [RelayCommand]
    private void Add()
    {
        Index = 0;
    }

    [RelayCommand]
    private void Delete(int index)
    {
        IsDeleteItem = !IsDeleteItem;
    }

    [RelayCommand]
    private async Task Save()
    {
        SaveCurrentForm(Index);

        var dbSet = StudentsDbContext.Set<TEntity>();

        var createdItems = ItemsList.Where(item => !item.Deleted & item.Created).Select(item => item.Value)
            .ToList();

        var deletedItems = ItemsList.Where(item => item.Deleted & !item.Created).Select(item => item.Value)
            .ToList();

        var updatedItems = ItemsList.Where(item => !item.Deleted & !item.Created & item.Updated).Select(item => item.Value)
            .ToList();
        
        dbSet.AddRange(createdItems);
        dbSet.RemoveRange(deletedItems);
        dbSet.UpdateRange(updatedItems);
        await StudentsDbContext.SaveChangesAsync();

        Update();
    }

    [RelayCommand]
    private void IncreaseIndex()
    {
        Index = Math.Min(Index + 1, ItemsList.Count - 1);
    }
    
    [RelayCommand]
    private void DecreaseIndex()
    {
        Index = Math.Max(Index - 1, 0);
    }

    [RelayCommand]
    private void FirstIndex()
    {
        Index = Math.Min(ItemsList.Count, 1) - 1;
    }

    [RelayCommand]
    private void LastIndex()
    {
        Index = ItemsList.Count - 1;
    }
    
    [RelayCommand]
    private void Create()
    {
        Index = -1;
    }

    [RelayCommand]
    private void Update()
    {
        ItemsList = StudentsDbContext.Set<TEntity>().Select((entity) => new Item<TEntity>(entity))
            .ToObservableCollection();
    }

    public virtual void OnNavigatedTo()
    {
      Update();   
    }

    public virtual void OnNavigatedFrom()
    {
        
    }

    protected virtual void SaveCurrentForm(int index)
    {
        var item = ItemsList.ElementAtOrDefault(index);
        if (item == null) return;
        item.Deleted = IsDeleteItem;
    }

    protected abstract SetValueFromItem()
    {
        
    }
}