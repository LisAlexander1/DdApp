using System;
using System.Collections.Generic;

namespace DdApp.Entities;

public partial class ФильтрСт
{
    public string? Фио { get; set; }

    public string? Пол { get; set; }

    public DateOnly? ДатаРождения { get; set; }

    public string? Родители { get; set; }

    public string? Адрес { get; set; }

    public string? Телефон { get; set; }

    public string? ПаспортныеДанные { get; set; }

    public long? НомерЗачетки { get; set; }

    public DateOnly? ДатаПоступления { get; set; }

    public string? Группа { get; set; }

    public byte? Курс { get; set; }

    public bool? ОчнаяФормаОбучения { get; set; }

    public string? НаименованиеСпециальности { get; set; }

    public string? ОписаниеСпецальности { get; set; }
}
