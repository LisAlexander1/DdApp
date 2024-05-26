using System.Windows.Controls;

namespace DdApp.Views.Pages.UserControls;

public partial class FormControl : UserControl
{
    public FormControl()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty TitleProperty;
    
    public static readonly DependencyProperty AddCommandProperty;
    public static readonly DependencyProperty DeleteCommandProperty;
    public static readonly DependencyProperty SaveCommandProperty;
    public static readonly DependencyProperty CreateCommandProperty;
    
    public static readonly DependencyProperty IncreaseIndexCommandProperty;
    public static readonly DependencyProperty DecreaseIndexCommandProperty;
    public static readonly DependencyProperty FirstIndexCommandProperty;
    public static readonly DependencyProperty LastIndexCommandProperty;
    
    public static readonly DependencyProperty IndexProperty;
    public static readonly DependencyProperty CountProperty;
    
    public static readonly DependencyProperty IsCreateFormProperty;
    public static readonly DependencyProperty IsDeleteItemProperty;
    public static readonly DependencyProperty LoadingProperty;

    
    

    static FormControl()
    {
        TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(FormControl),
            new FrameworkPropertyMetadata(
                string.Empty));

        AddCommandProperty = DependencyProperty.Register(
            "AddCommand",
            typeof(RelayCommand),
            typeof(FormControl));
        
        CreateCommandProperty = DependencyProperty.Register(
            "CreateCommand",
            typeof(RelayCommand),
            typeof(FormControl));
        
        DeleteCommandProperty = DependencyProperty.Register(
            nameof(DeleteCommand),
            typeof(RelayCommand),
            typeof(FormControl));
        
        SaveCommandProperty = DependencyProperty.Register(
            "SaveCommand",
            typeof(RelayCommand),
            typeof(FormControl));
        
        
        
        IncreaseIndexCommandProperty = DependencyProperty.Register(
            nameof(IncreaseIndexCommand),
            typeof(RelayCommand),
            typeof(FormControl));
        
        DecreaseIndexCommandProperty = DependencyProperty.Register(
            nameof(DecreaseIndexCommand),
            typeof(RelayCommand),
            typeof(FormControl));
        
        FirstIndexCommandProperty = DependencyProperty.Register(
            nameof(FirstIndexCommand),
            typeof(RelayCommand),
            typeof(FormControl));
        
        LastIndexCommandProperty = DependencyProperty.Register(
            nameof(LastIndexCommand),
            typeof(RelayCommand),
            typeof(FormControl));
        
        
        IndexProperty = DependencyProperty.Register(
            nameof(Index),
            typeof(int),
            typeof(FormControl),
            new FrameworkPropertyMetadata(
                defaultValue: 0));
        
        CountProperty = DependencyProperty.Register(
            nameof(Count),
            typeof(int),
            typeof(FormControl),
            new FrameworkPropertyMetadata(
                defaultValue: 0));
        
        IsCreateFormProperty = DependencyProperty.Register(
            nameof(IsCreateForm),
            typeof(bool),
            typeof(FormControl),
            new FrameworkPropertyMetadata(
                defaultValue: false));
        IsDeleteItemProperty = DependencyProperty.Register(
            nameof(IsDeleteItem),
            typeof(bool),
            typeof(FormControl),
            new FrameworkPropertyMetadata(
                defaultValue: false));
        
        LoadingProperty = DependencyProperty.Register(
            nameof(Loading),
            typeof(bool),
            typeof(FormControl),
            new FrameworkPropertyMetadata(
                defaultValue: false));
    }
    
    public string Title
    { 
        get => (string) GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    
    
    
    public RelayCommand AddCommand
    { 
        get => (RelayCommand) GetValue(AddCommandProperty);
        set => SetValue(AddCommandProperty, value);
    }
    
    public RelayCommand CreateCommand
    { 
        get => (RelayCommand) GetValue(CreateCommandProperty);
        set => SetValue(CreateCommandProperty, value);
    }
    
    public RelayCommand DeleteCommand
    { 
        get => (RelayCommand) GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    } 
    
    public RelayCommand SaveCommand
    { 
        get => (RelayCommand) GetValue(SaveCommandProperty);
        set => SetValue(SaveCommandProperty, value);
    }
    
    
    
    public RelayCommand IncreaseIndexCommand
    { 
        get => (RelayCommand) GetValue(IncreaseIndexCommandProperty);
        set => SetValue(IncreaseIndexCommandProperty, value);
    }
    
    public RelayCommand DecreaseIndexCommand
    { 
        get => (RelayCommand) GetValue(DecreaseIndexCommandProperty);
        set => SetValue(DecreaseIndexCommandProperty, value);
    }
    
    public RelayCommand FirstIndexCommand
    { 
        get => (RelayCommand) GetValue(FirstIndexCommandProperty);
        set => SetValue(FirstIndexCommandProperty, value);
    }
    
    public RelayCommand LastIndexCommand
    { 
        get => (RelayCommand) GetValue(LastIndexCommandProperty);
        set => SetValue(LastIndexCommandProperty, value);
    }
    
    
    
    public int Index
    { 
        get => (int) GetValue(IndexProperty);
        set => SetValue(IndexProperty, value);
    }
    
    public int Count
    { 
        get => (int) GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }
    
    public bool IsCreateForm
    { 
        get => (bool) GetValue(IsCreateFormProperty);
        set => SetValue(IsCreateFormProperty, value);
    }
    
    public bool IsDeleteItem
    { 
        get => (bool) GetValue(IsCreateFormProperty);
        set => SetValue(IsCreateFormProperty, value);
    }
    
    public bool Loading
    { 
        get => (bool) GetValue(LoadingProperty);
        set => SetValue(LoadingProperty, value);
    }
}