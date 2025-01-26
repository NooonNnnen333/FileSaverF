namespace FileSaver;

public partial class MainPage : ContentPage
{
    public MainPage(ViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}