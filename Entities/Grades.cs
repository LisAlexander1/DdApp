using System;
using System.Collections.Generic;

namespace DdApp.Entities;

public partial class Grades
{
    public long? StudentCode { get; set; }

    public DateOnly? ExamDate1 { get; set; }

    public long? SubjectCode1 { get; set; }

    public byte? Grade1 { get; set; }

    public DateOnly? ExamDate2 { get; set; }

    public long? SubjectCode2 { get; set; }

    public byte? Grade2 { get; set; }

    public DateOnly? ExamDate3 { get; set; }

    public long? SubjectCode3 { get; set; }

    public byte? Grade3 { get; set; }

    public float? AverageGrade { get; set; }

    public virtual Subject? Subject1 { get; set; }

    public virtual Subject? Subject2 { get; set; }

    public virtual Subject? Subject3 { get; set; }

    public virtual Student? Student { get; set; }
}
