using DdApp.Context;
using DdApp.Entities;

namespace DdApp.ViewModels.Pages;

public class StudentViewModel(StudentsDbContext studentsDbContext) : FormViewModel<Student>(studentsDbContext)
{
    
}