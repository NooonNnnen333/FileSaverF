﻿namespace lab3;

public partial class MainPage : ContentPage
{
    private readonly ViewModel _viewModel;
    
    public MainPage()
    {
        InitializeComponent();

        // Создаём ViewModel и передаём ей ссылку на CanvasControl из XAML
        _viewModel = new ViewModel(CanvasControl);

        // Назначаем ViewModel в качестве BindingContext (если нужно биндинги)
        BindingContext = _viewModel;
    }
}