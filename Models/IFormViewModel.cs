namespace DdApp.Models;

public interface IFormViewModel
{

    public int Index { get; set; }
    
    public IRelayCommand AddCommand();

    public IRelayCommand DeleteCommand();

    public IRelayCommand SaveCommand();

    public IRelayCommand IncreaseIndexCommand();

    public IRelayCommand DecreaseIndexCommand();
    
    public IRelayCommand FirstIndexCommand();

    public IRelayCommand LastIndexCommand();

    public IRelayCommand CreateCommand();

    public IRelayCommand UpdateCommand();
}