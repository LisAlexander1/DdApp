namespace DdApp.Models;

public class Item<T>
{
    public Item(T value)
    {
        Value = value;
        Created = true;
    }

    public T Value { get; init; }
    public bool Deleted { get; set; } = false;
    public bool Created { get; set; } = false;
    public bool Updated { get; set; } = false;
}