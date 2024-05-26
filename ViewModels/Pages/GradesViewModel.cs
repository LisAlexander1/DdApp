using System.Collections.ObjectModel;
using System.Windows.Documents;
using DdApp.Context;
using DdApp.Entities;
using DdApp.Extensions;
using DdApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Logging;
using Wpf.Ui;

namespace DdApp.ViewModels.Pages;

public partial class GradesViewModel(StudentsDbContext studentsDbContext, ISnackbarService snackbarService)
    : FormViewModel<Grades>(studentsDbContext, snackbarService)
{
    [ObservableProperty] private long _studentCode;

    [ObservableProperty] private long _code;

    [ObservableProperty] private long? _subjectCode1;

    [ObservableProperty] private long? _subjectCode2;

    [ObservableProperty] private long? _subjectCode3;

    [ObservableProperty] private DateOnly? _examDate1;

    [ObservableProperty] private DateOnly? _examDate2;

    [ObservableProperty] private DateOnly? _examDate3;

    [NotifyPropertyChangedFor(nameof(AverageGrade))] [ObservableProperty]
    private byte? _grade1;

    [NotifyPropertyChangedFor(nameof(AverageGrade))] [ObservableProperty]
    private byte? _grade2;

    [NotifyPropertyChangedFor(nameof(AverageGrade))] [ObservableProperty]
    private byte? _grade3;

    public float AverageGrade =>
        Convert.ToSingle(new List<byte?>([Grade1, Grade2, Grade3])
            .Where(v => v != null)
            .DefaultIfEmpty<byte?>(0)
            .Average(v => (byte)v!));

    [ObservableProperty] private ObservableCollection<Student> _students = [];
    [ObservableProperty] private ObservableCollection<Subject> _subjects = [];

    protected override string ObjectName { get; } = "оценки";

    protected override void SetItemFromForm(Item<Grades> item)
    {
        item.Value.Code = Code;
        item.Value.StudentCode = StudentCode;
        item.Value.SubjectCode1 = SubjectCode1;
        item.Value.SubjectCode2 = SubjectCode2;
        item.Value.SubjectCode3 = SubjectCode3;
        item.Value.Grade1 = Grade1;
        item.Value.Grade2 = Grade2;
        item.Value.Grade3 = Grade3;
        item.Value.ExamDate1 = ExamDate1;
        item.Value.ExamDate2 = ExamDate2;
        item.Value.ExamDate3 = ExamDate3;
        item.Value.AverageGrade = AverageGrade;
    }

    protected override void SetFormFromItem(Item<Grades> item)
    {
        Code = item.Value.Code;
        StudentCode = item.Value.StudentCode;
        SubjectCode1 = item.Value.SubjectCode1;
        SubjectCode2 = item.Value.SubjectCode2;
        SubjectCode3 = item.Value.SubjectCode3;
        Grade1 = item.Value.Grade1;
        Grade2 = item.Value.Grade2;
        Grade3 = item.Value.Grade3;
        ExamDate1 = item.Value.ExamDate1;
        ExamDate2 = item.Value.ExamDate2;
        ExamDate3 = item.Value.ExamDate3;
    }

    protected override void SetFormNull()
    {
        StudentCode = 0;
        SubjectCode1 = null;
        SubjectCode2 = null;
        SubjectCode3 = null;
        Grade1 = null;
        Grade2 = null;
        Grade3 = null;
        ExamDate1 = null;
        ExamDate2 = null;
        ExamDate3 = null;
        Code = 0;
    }

    protected override Grades CreateItemFromForm()
    {
        return new Grades()
        {
            StudentCode = StudentCode,
            SubjectCode1 = SubjectCode1,
            SubjectCode2 = SubjectCode2,
            SubjectCode3 = SubjectCode3,
            Grade1 = Grade1,
            Grade2 = Grade2,
            Grade3 = Grade3,
            ExamDate1 = ExamDate1,
            ExamDate2 = ExamDate2,
            ExamDate3 = ExamDate3,
            AverageGrade = AverageGrade,
        };
    }

    protected override void Update()
    {
        // ItemsList = StudentsDbContext.Grades.AsNoTracking().Select(g => new Item<Grades>(g, false)).ToObservableCollection();
        base.Update();
        Students = StudentsDbContext.Students.ToObservableCollection();
        Subjects = StudentsDbContext.Subjects.ToObservableCollection();
    }

    [RelayCommand]
    private void ClearExam(int value)
    {
        switch (value)
        {
            case 1:
                ExamDate1 = null;
                Grade1 = null;
                SubjectCode1 = null;
                break;
            case 2:
                ExamDate2 = null;
                Grade2 = null;
                SubjectCode2 = null;
                break;
            case 3:
                ExamDate3 = null;
                Grade3 = null;
                SubjectCode3 = null;
                break;
        }
    }
}