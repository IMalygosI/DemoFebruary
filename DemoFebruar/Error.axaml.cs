using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DemoFebruar;

public partial class Error : Window
{
    public Error()
    {
        InitializeComponent();
    }
    public Error(string Warning)
    {
        InitializeComponent();

        if (Warning == "Ошибка! Введите ФИО!")
        {
            ErrorsWarning.Text = Warning;
        }

    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}