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

    /// <summary>
    /// �������� ������
    /// </summary>
    /// <param name="Warning"></param>
    public Error(string Warning)
    {
        InitializeComponent();

        if (Warning == "������! ������� ���!")
        {
            ErrorsWarning.Text = Warning;
        }
        if (Warning == "������! �������� ���������!")
        {
            ErrorsWarning.Text = Warning;
        }
        if (Warning == "������! �������� ������!")
        {
            ErrorsWarning.Text = Warning;
        }
        if (Warning == "������! ������� �������!")
        {
            ErrorsWarning.Text = Warning;
        }
        if (Warning == "������! �������� �������!")
        {
            ErrorsWarning.Text = Warning;
        }
        if (Warning == "������! ������� ���� ��������!")
        {
            ErrorsWarning.Text = Warning;
        }
    }

    /// <summary>
    /// �������� ���� � ��������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}