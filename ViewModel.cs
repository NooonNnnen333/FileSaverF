using CommunityToolkit.Mvvm.ComponentModel;
using System.Text;
using System.Windows.Input;
using AngleSharp;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.Input;

namespace FileSaver;

public partial class ViewModel : ObservableObject
{
    private readonly IFileSaver fileSaver;
    private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

    public ViewModel(IFileSaver fileSaver)
    {
        this.fileSaver = fileSaver;
        SaveFileCommand = new RelayCommand(async () => await SaveFileAsync());
    }

    public ICommand SaveFileCommand { get; }

    private async Task SaveFileAsync()
    {
        using var stream = new MemoryStream(Encoding.Default.GetBytes("Смерть евреям, слава Фюреру"));
        await fileSaver.SaveAsync("HitlerFile.txt", stream, cancellationTokenSource.Token);
    }
    
    [RelayCommand]
    private async Task nnn()
    {
        // URL для парсинга
        string url = "https://www.susu.ru";

        // Конфигурация AngleSharp
        var config = Configuration.Default.WithDefaultLoader();

        // Загрузка страницы
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(url);

        // Извлечение текста страницы
        PageText = document.Body.TextContent;

        

    }

    [ObservableProperty] 
    public string pageText;







}