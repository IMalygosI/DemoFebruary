using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.VisualTree;
using DemoFebruar.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DemoFebruar;

public partial class NewsPract : Window
{
    List<Employee> employees = new List<Employee>();
    List<News_Jsons.Class1> newsItems = new List<News_Jsons.Class1>();
    List<EventsCalendar> eventsCalendars = new List<EventsCalendar>();
    List<DateOnly> listDate = new List<DateOnly>();

    public NewsPract()
    {
        InitializeComponent();

        CalendarCustomer.Loaded += CalendarCustomer_Loaded;
        CalendarCustomer.DisplayDateChanged += CalendarCustomer_DisplayDateChanged;

        Loang();
    }

    private void CalendarCustomer_DisplayDateChanged(object? sender, CalendarDateChangedEventArgs e)
    {
        BrushesCalendar();
    }
    private void CalendarCustomer_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        BrushesCalendar();
    }

    /// <summary>
    /// Выделяем дни событий в календаре
    /// </summary>
    private void BrushesCalendar()
    {
        foreach (var child in CalendarCustomer.GetVisualDescendants())
        {
            if (child is CalendarDayButton dayButton)
            {
                var dateNow = (CalendarCustomer as Calendar).DisplayDate;

                string vv = dayButton.Content!.ToString()!;

                try
                {
                    if (listDate.Contains(new DateOnly(dateNow.Year, dateNow.Month, int.Parse(vv))))
                    {
                        dayButton.Background = Brushes.LightYellow;
                        dayButton.Foreground = Brushes.Red;
                    }
                    else
                    {
                        dayButton.Background = Brushes.LightGray;
                        dayButton.Foreground = Brushes.Black;
                    }
                }
                catch
                {
                    dayButton.Background = Brushes.LightGray;
                    dayButton.Foreground = Brushes.Black;
                }
            }
        }
    }




    /// <summary>
    /// Загрузка данных
    /// </summary>
    public void Loang()
    {
        // Загрузка данных
        employees = Helper.Base.Employees.Include(a => a.JobTitleNavigation).ToList();
        eventsCalendars = Helper.Base.EventsCalendars.Include(g => g.ResponsiblePerson).ToList();
        
        // Загрузка дат для календаря
        listDate = Helper.Base.EventsCalendars.Select(j => j.EventData).ToList();

        // Загружаем данные из JSON
        var baseDirectory = AppContext.BaseDirectory;
        var jsonPath = Path.Combine(baseDirectory, "News", "news_response.json");
        var json = File.ReadAllText(jsonPath);
        
        // Преобразуем данные JSON в список Class1
        newsItems = JsonConvert.DeserializeObject<List<News_Jsons.Class1>>(json);

        // Собираем вводимое значение
        var Search_Text = (SearchText.Text ?? "").ToLower().Split(' ');

        // Поиск по пользователям
        employees = employees.Where(a => Search_Text.Any(news => a.Fio.Contains(news))).ToList();
        // Поиск по событиям
        eventsCalendars = eventsCalendars.Where(b => Search_Text.Any(news => b.Name.Contains(news))).ToList();
        // Поиск по новостям
        newsItems = newsItems.Where(g => Search_Text.Any(news => g.title.Contains(news))).ToList();

        // Загрузка сотрудников
        Listbox_Employee.ItemsSource = employees;
        // Загрузка новостей
        Listbox_News.ItemsSource = newsItems;
        //Загрузка событий
        ListBox_Sob.ItemsSource = eventsCalendars;
    }

    /// <summary>
    /// Проверка на ввод с клавиатуры
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => Loang();

    /// <summary>
    /// выход к окну выбора
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Navigation navigation = new Navigation();
        navigation.Show();
        Close();
    }
}