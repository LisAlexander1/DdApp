namespace DdApp.Models;

public class Item<T>
{
    public T Value { get; set; }
    public bool Deleted { get; set; } = false;
    public bool New { get; set; } = false;
}