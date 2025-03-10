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
    /// Загрузка ошибок
    /// </summary>
    /// <param name="Warning"></param>
    public Error(string Warning)
    {
        InitializeComponent();

        if (Warning == "Ошибка! Введите ФИО!")
        {
            ErrorsWarning.Text = Warning;
        }
        if (Warning == "Ошибка! Выберите Структуру!")
        {
            ErrorsWarning.Text = Warning;
        }
        if (Warning == "Ошибка! Выберите работу!")
        {
            ErrorsWarning.Text = Warning;
        }
        if (Warning == "Ошибка! Введите телефон!")
        {
            ErrorsWarning.Text = Warning;
        }
        if (Warning == "Ошибка! Выберите кабинет!")
        {
            ErrorsWarning.Text = Warning;
        }
        if (Warning == "Ошибка! Введите день рождения!")
        {
            ErrorsWarning.Text = Warning;
        }
    }

    /// <summary>
    /// Закрытие окна с ошибками
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }
}