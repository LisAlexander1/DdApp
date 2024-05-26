using System;
using System.Collections.Generic;
using DdApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DdApp.Context;

public partial class StudentsDbContext : DbContext
{
    public StudentsDbContext()
    {
    }

    public StudentsDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<ЗапросОценкиСтуденты> ЗапросОценкиСтудентыs { get; set; }

    public virtual DbSet<ЗапросСтудентыСпециальности> ЗапросСтудентыСпециальностиs { get; set; }

    public virtual DbSet<Grades> Grades { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Specialty> Specialties { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<ФильтрБу> ФильтрБуs { get; set; }

    public virtual DbSet<ФильтрЗаочнаяФормаОбучения> ФильтрЗаочнаяФормаОбученияs { get; set; }

    public virtual DbSet<ФильтрМать> ФильтрМатьs { get; set; }

    public virtual DbSet<ФильтрМм> ФильтрМмs { get; set; }

    public virtual DbSet<ФильтрМо> ФильтрМоs { get; set; }

    public virtual DbSet<ФильтрНетРодителей> ФильтрНетРодителейs { get; set; }

    public virtual DbSet<ФильтрОтец> ФильтрОтецs { get; set; }

    public virtual DbSet<ФильтрОтецИМать> ФильтрОтецИМатьs { get; set; }

    public virtual DbSet<ФильтрОчнаяФормаОбучения> ФильтрОчнаяФормаОбученияs { get; set; }

    public virtual DbSet<ФильтрПи> ФильтрПиs { get; set; }

    public virtual DbSet<ФильтрСт> ФильтрСтs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_100_CI_AS");

        modelBuilder.Entity<ЗапросОценкиСтуденты>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Запрос Оценки+Students");

            entity.Property(e => e.ДатаЭкзамена1).HasColumnName("Дата экзамена 1");
            entity.Property(e => e.ДатаЭкзамена2).HasColumnName("Дата экзамена 2");
            entity.Property(e => e.ДатаЭкзамена3).HasColumnName("Дата экзамена 3");
            entity.Property(e => e.НаименованияПредмета1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименования предмета 1");
            entity.Property(e => e.НаименованияПредмета2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименования предмета 2");
            entity.Property(e => e.НаименованияПредмета3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименования предмета 3");
            entity.Property(e => e.Оценка1).HasColumnName("Оценка 1");
            entity.Property(e => e.Оценка2).HasColumnName("Оценка 2");
            entity.Property(e => e.Оценка3).HasColumnName("Оценка 3");
            entity.Property(e => e.СреднийБалл).HasColumnName("Средний балл");
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ЗапросСтудентыСпециальности>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Запрос Students+Специальности");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Grades>(entity =>
        {
            entity.HasKey(e => e.Code);
            entity
                .ToTable("Оценки", tb =>
                {
                    tb.HasTrigger("Индикатор добавления оценки");
                    tb.HasTrigger("Индикатор изменения оценки");
                    tb.HasTrigger("Индикатор удаления оценки");
                });

            entity.Property(e => e.Code).HasColumnName("Код оценок");
            entity.Property(e => e.ExamDate1).HasColumnName("Дата экзамена 1");
            entity.Property(e => e.ExamDate2).HasColumnName("Дата экзамена 2");
            entity.Property(e => e.ExamDate3).HasColumnName("Дата экзамена 3");
            entity.Property(e => e.SubjectCode1).HasColumnName("Код предмета 1");
            entity.Property(e => e.SubjectCode2).HasColumnName("Код предмета 2");
            entity.Property(e => e.SubjectCode3).HasColumnName("Код предмета 3");
            entity.Property(e => e.StudentCode).HasColumnName("Код студента");
            entity.Property(e => e.Grade1).HasColumnName("Оценка 1");
            entity.Property(e => e.Grade2).HasColumnName("Оценка 2");
            entity.Property(e => e.Grade3).HasColumnName("Оценка 3");
            entity.Property(e => e.AverageGrade).HasColumnName("Средний балл");

            entity.HasOne(d => d.Subject1).WithMany()
                .HasForeignKey(d => d.SubjectCode1)
                .HasConstraintName("Оценки_Предметы_Код предмета_fk");

            entity.HasOne(d => d.Subject2).WithMany()
                .HasForeignKey(d => d.SubjectCode2)
                .HasConstraintName("Оценки_Предметы_Код предмета_fk2");

            entity.HasOne(d => d.Subject3).WithMany()
                .HasForeignKey(d => d.SubjectCode3)
                .HasConstraintName("Оценки_Предметы_Код предмета_fk3");

            entity.HasOne(d => d.Student).WithMany()
                .HasForeignKey(d => d.StudentCode)
                .HasConstraintName("Оценки_Студенты_Код студента_fk");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("Предметы_pk");

            entity.ToTable("Предметы", tb =>
            {
                tb.HasTrigger("Индикатор добавления предмета");
                tb.HasTrigger("Индикатор изменения предмета");
                tb.HasTrigger("Индикатор удаления предмета");
            });

            entity.Property(e => e.Code).HasColumnName("Код предмета");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование предмета");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("Описание предмета");
        });

        modelBuilder.Entity<Specialty>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("Специальности_pk");

            entity.ToTable("Специальности", tb =>
            {
                tb.HasTrigger("Индикатор добавления специальности");
                tb.HasTrigger("Индикатор изменения специальности");
                tb.HasTrigger("Индикатор удаления специальности");
                tb.HasTrigger("Удаления специальности");
            });

            entity.Property(e => e.Code).HasColumnName("Код специальности");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("Студенты_pk");

            entity.ToTable("Студенты", tb =>
            {
                tb.HasTrigger("Индикатор добавления");
                tb.HasTrigger("Индикатор зменения");
                tb.HasTrigger("Индикатор удаления");
                tb.HasTrigger("Удаление студента");
            });

            entity.Property(e => e.Code).HasColumnName("Код студента");
            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.Group)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AdmissionDate).HasColumnName("Дата поступления");
            entity.Property(e => e.BirthDay).HasColumnName("Дата рождения");
            entity.Property(e => e.SpecialtyCode).HasColumnName("Код специальности");
            entity.Property(e => e.GradeBookNumber).HasColumnName("Номер зачетки");
            entity.Property(e => e.IsFullTimeEducation).HasColumnName("Очная форма обучения");
            entity.Property(e => e.PassportData)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Parents)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");

            entity.HasOne(d => d.Specialty).WithMany(p => p.Students)
                .HasForeignKey(d => d.SpecialtyCode)
                .HasConstraintName("Студенты_Специальности_Код специальности_fk");
        });

        modelBuilder.Entity<ФильтрБу>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр БУ");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрЗаочнаяФормаОбучения>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр заочная форма обучения");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрМать>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Мать");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрМм>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр ММ");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрМо>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр МО");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрНетРодителей>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Нет родителей");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрОтец>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр отец");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрОтецИМать>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр Отец и Мать");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрОчнаяФормаОбучения>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр очная форма обучения");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрПи>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр ПИ");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<ФильтрСт>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Фильтр СТ");

            entity.Property(e => e.Адрес).IsUnicode(false);
            entity.Property(e => e.Группа)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ДатаПоступления).HasColumnName("Дата поступления");
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.НаименованиеСпециальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Наименование специальности");
            entity.Property(e => e.НомерЗачетки).HasColumnName("Номер зачетки");
            entity.Property(e => e.ОписаниеСпецальности)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Описание спецальности");
            entity.Property(e => e.ОчнаяФормаОбучения).HasColumnName("Очная форма обучения");
            entity.Property(e => e.ПаспортныеДанные)
                .IsUnicode(false)
                .HasColumnName("Паспортные данные");
            entity.Property(e => e.Пол)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Родители)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Телефон)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Фио)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ФИО");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}