using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DemoFebruar;

public partial class Navigation : Window
{
    public Navigation()
    {
        InitializeComponent();
    }

    /// <summary>
    /// ������� � �������� ���� 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click_GlavnoeOkko(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    /// <summary>
    /// ������� � ���������� ����
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click_PublicPortal(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        NewsPract newsPract = new NewsPract();
        newsPract.Show();
        Close();
    }
}