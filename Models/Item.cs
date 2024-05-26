namespace DdApp.Models;

public class Item<T>(T value, bool created)
{
    public T Value { get; init; } = value;
    public bool Deleted { get; set; } = false;
    public bool Created { get; set; } = created;
    public bool Updated { get; set; } = false;
}