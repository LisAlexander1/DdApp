using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DdApp.Entities;

[Table("Студенты")]
public partial class Student
{
    [Column("Код студента")]
    public long Code { get; set; }

    [Column("ФИО")]
    public string? FullName { get; set; }

    [Column("Пол")]
    public string? Sex { get; set; }

    [Column("Дата рождения")]
    public DateOnly? BirthDay { get; set; }

    [Column("Родители")]
    public string? Parents { get; set; }

    [Column("Адрес")]
    public string? Address { get; set; }

    [Column("Телефон")]
    public string? Phone { get; set; }

    [Column("Паспортные данные")]
    public string? PassportData { get; set; }

    [Column("Номер зачетки")]
    public long? GradeBookNumber { get; set; }

    [Column("Дата поступления")]
    public DateOnly? AdmissionDate { get; set; }

    [Column("Группа")]
    public string? Group { get; set; }

    [Column("Курс")]
    public byte? Course { get; set; }

    [Column("Код специальности")]
    [ForeignKey(nameof(Specialty))]
    public long? SpecialtyCode { get; set; }

    [Column("Очная форма обучения")]
    public bool? IsFullTimeEducation { get; set; }

    public virtual Specialty? Specialty { get; set; }
}
