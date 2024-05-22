using System;
using System.Collections.Generic;

namespace DdApp.Entities;

public partial class ЗапросОценкиСтуденты
{
    public string? Фио { get; set; }

    public DateOnly? ДатаЭкзамена1 { get; set; }

    public string? НаименованияПредмета1 { get; set; }

    public byte? Оценка1 { get; set; }

    public DateOnly? ДатаЭкзамена2 { get; set; }

    public string? НаименованияПредмета2 { get; set; }

    public byte? Оценка2 { get; set; }

    public DateOnly? ДатаЭкзамена3 { get; set; }

    public string? НаименованияПредмета3 { get; set; }

    public byte? Оценка3 { get; set; }

    public float? СреднийБалл { get; set; }
}
