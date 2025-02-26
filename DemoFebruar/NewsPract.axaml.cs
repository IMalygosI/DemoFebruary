using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DemoFebruar;

public partial class NewsPract : Window
{
    public NewsPract()
    {
        InitializeComponent();
        Loang();
    }

    public void Loang() 
    {



    }

    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => Loang();
}