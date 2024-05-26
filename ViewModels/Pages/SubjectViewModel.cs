using DdApp.Context;
using DdApp.Entities;
using DdApp.Models;
using Wpf.Ui;

namespace DdApp.ViewModels.Pages;

public partial class SubjectViewModel(StudentsDbContext studentsDbContext, ISnackbarService snackbarService)
    : FormViewModel<Subject>(studentsDbContext, snackbarService)
{
    [ObservableProperty] private long _code;

    [ObservableProperty] private string? _name;

    [ObservableProperty] private string? _description;

    protected override string ObjectName { get; } = "предмет";

    protected override void SetItemFromForm(Item<Subject> item)
    {
        item.Value.Code = Code;
        item.Value.Name = Name;
        item.Value.Description = Description;
    }

    protected override void SetFormFromItem(Item<Subject> item)
    {
        Code = item.Value.Code;
        Name = item.Value.Name;
        Description = item.Value.Description;
    }

    protected override void SetFormNull()
    {
        Code = 0;
        Name = null;
        Description = null;
    }

    protected override Subject CreateItemFromForm()
    {
        return new Subject() { Name = null, Description = null };
    }
}