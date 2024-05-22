using System.Collections.ObjectModel;
using DdApp.Context;
using DdApp.Entities;
using DdApp.Extensions;
using DdApp.Models;
using Microsoft.IdentityModel.Tokens;
using Wpf.Ui.Controls;

namespace DdApp.ViewModels.Pages
{
    public partial class SpecialityViewModel : ObservableObject, INavigationAware
    {
        private StudentsDbContext DbContext { get; }

        public SpecialityViewModel(StudentsDbContext dbContext)
        {
            DbContext = dbContext;
            Update();
            if (Specialties.Count > 0)
                Index = 0;
            else
                Index = -1;
        }

        [ObservableProperty] private int _index = -1;

        [ObservableProperty] private string? _name;

        [ObservableProperty] private bool _new;

        [ObservableProperty] private long? _code;

        [ObservableProperty] private bool _deleted;

        [ObservableProperty] private string? _description;

        [ObservableProperty] private ObservableCollection<Item<Specialty>> _specialties = [];

        [ObservableProperty] private Item<Specialty>? _specialty;

        [RelayCommand]
        private void OnCounterIncrement()
        {
            Index++;
        }

        [RelayCommand]
        private void IncreaseIndex()
        {
            Index = Math.Min(Index + 1, Specialties.Count - 1);
        }

        [RelayCommand]
        private void DecreaseIndex()
        {
            Index = Math.Max(Index - 1, 0);
        }

        [RelayCommand]
        private void TopIndex()
        {
            Index = Specialties.Count - 1;
        }

        [RelayCommand]
        private void LowIndex()
        {
            Index = 0;
        }

        [RelayCommand]
        private void Delete(int index)
        {
            Deleted = !Deleted;
        }

        [RelayCommand]
        private void Create()
        {
            Index = -1;
        }

        [RelayCommand]
        private void Save()
        {
            SaveCurrentForm(Index);

            var createItems = Specialties.Where(item => !item.Deleted & item.New).Select(item => item.Value).ToList();
            DbContext.AddRange(createItems);

            var deleteItems = Specialties.Where(item => item.Deleted & !item.New).Select(item => item.Value).ToList();
            DbContext.Specialties.RemoveRange(deleteItems);

            var updateItems = Specialties.Where(item => !item.Deleted & !item.New).Select(item => item.Value).ToList();
            DbContext.UpdateRange(updateItems);
            DbContext.SaveChanges();

            Update();
        }

        private void Update()
        {
            Specialties = DbContext.Specialties.Select((sp) => new Item<Specialty> { Value = sp })
                .ToObservableCollection();
        }

        [RelayCommand]
        private void Add()
        {
            if (!Name.IsNullOrEmpty() || !Description.IsNullOrEmpty())
            {
                Specialties.Add(new Item<Specialty>
                    { New = true, Value = new Specialty { Name = Name, Description = Description } });
            }

            Index = Specialties.Count - 1;
        }

        partial void OnIndexChanged(int oldValue, int newValue)
        {
            SaveCurrentForm(oldValue);
            Specialty = Specialties.ElementAtOrDefault(newValue);
        }

        partial void OnSpecialtyChanged(Item<Specialty>? value)
        {
            SetValueFromItem(value);
        }

        partial void OnSpecialtiesChanged(ObservableCollection<Item<Specialty>> value)
        {
            Index = Math.Min(Index, value.Count - 1);
            Specialty = Specialties.ElementAtOrDefault(Index);
        }

        private void SaveCurrentForm(int index)
        {
            var specialty = Specialties.ElementAtOrDefault(index);
            if (specialty != null)
            {
                specialty.Deleted = Deleted;
                specialty.Value.Name = Name;
                specialty.Value.Description = Description;
            }
        }

        private void SetValueFromItem(Item<Specialty>? value)
        {
            if (value != null)
            {
                Name = value.Value.Name;
                Description = value.Value.Description;
                Code = value.Value.Code;
                Deleted = value.Deleted;
                New = false;
            }
            else
            {
                New = true;
                Name = null;
                Description = null;
                Code = null;
                Deleted = false;
            }
        }

        public void OnNavigatedTo()
        {
            Update();
        }

        public void OnNavigatedFrom()
        {
        }
    }
}