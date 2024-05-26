using System.Collections.ObjectModel;
using DdApp.Context;
using DdApp.Entities;
using DdApp.Extensions;
using DdApp.Models;
using Wpf.Ui;

namespace DdApp.ViewModels.Pages;


public partial class StudentViewModel(StudentsDbContext studentsDbContext, ISnackbarService snackbarService) : FormViewModel<Student>(studentsDbContext, snackbarService)
{

    [ObservableProperty]
    private string? _fullName;
    
    [ObservableProperty]
    private string? _parents;

    [ObservableProperty]
    private string? _sex;
    
    [ObservableProperty]
    private string? _address;
    
    [ObservableProperty]
    private string? _passportData;

    [ObservableProperty]
    private string? _phone;
    
    [ObservableProperty]
    private int? _course;

    [ObservableProperty]
    private DateOnly? _birthDay;
    
    [ObservableProperty]
    private DateOnly? _admissionDate;

    [ObservableProperty]
    private ObservableCollection<Specialty> _specialties = [];

    [ObservableProperty]
    private Specialty? _specialty;
    
    [ObservableProperty]
    private string? _group;
    
    [ObservableProperty]
    private long? _gradeBookNumber;
    
    [ObservableProperty]
    private long? _specialtyCode;

    [ObservableProperty]
    private bool? _isFullTimeEducation;
    
    protected override void SetItemFromForm(Item<Student> item)
    {
          item.Value.FullName = FullName;
          item.Value.Sex = Sex;
          item.Value.BirthDay = BirthDay;
          item.Value.Parents = Parents;
          item.Value.Address = Address;
          item.Value.PassportData = PassportData;
          item.Value.Phone = Phone;
          item.Value.Course = Convert.ToByte(Course);
          item.Value.Specialty = Specialty;
          item.Value.IsFullTimeEducation = IsFullTimeEducation;
          item.Value.SpecialtyCode = SpecialtyCode;
          item.Deleted = IsDeleteItem;
          item.Value.AdmissionDate = AdmissionDate;
          item.Value.Group = Group;
          item.Value.GradeBookNumber = GradeBookNumber;
    }

    protected override void SetFormFromItem(Item<Student> item)
    {
        FullName = item.Value.FullName;
        Sex = item.Value.Sex;
        BirthDay = item.Value.BirthDay;
        Parents = item.Value.Parents;
        Address = item.Value.Address;
        PassportData = item.Value.PassportData;
        Phone = item.Value.Phone;
        Course = item.Value.Course;
        Specialty = item.Value.Specialty;
        IsFullTimeEducation = item.Value.IsFullTimeEducation;
        SpecialtyCode = item.Value.SpecialtyCode;
        IsDeleteItem = item.Deleted;
        AdmissionDate = item.Value.AdmissionDate;
        Group = item.Value.Group;
        GradeBookNumber = item.Value.GradeBookNumber;
    }

    protected override void SetFormNull()
    {
        FullName = null;
        Sex = null;
        BirthDay = DateOnly.FromDateTime(DateTime.Today.AddYears(-18));
        Parents = "Отец, Мать";
        Address = null;
        PassportData = null;
        Phone = null;
        Course = null;
        Specialty = null;
        IsFullTimeEducation = false;
        AdmissionDate = DateOnly.FromDateTime(DateTime.Today);
        Group = null;
        GradeBookNumber = null;
        
        Console.WriteLine($"Saving {Index}");
    }

    protected override Student CreateItemFromForm()
    {
        return new Student()
        {
            FullName = FullName,
            Sex = Sex,
            BirthDay = BirthDay,
            Parents = Parents,
            Address = Address,
            PassportData = PassportData,
            Phone = Phone,
            Course = Convert.ToByte(Course),
            Specialty = Specialty,
            IsFullTimeEducation = IsFullTimeEducation,
            SpecialtyCode = SpecialtyCode,
            AdmissionDate = AdmissionDate,
            Group = Group,
            GradeBookNumber = GradeBookNumber
        };
    }

    protected override string ObjectName { get; } = "студент";

    protected override void Update()
    {
        base.Update();
        Specialties = StudentsDbContext.Specialties.ToObservableCollection();
    }
}