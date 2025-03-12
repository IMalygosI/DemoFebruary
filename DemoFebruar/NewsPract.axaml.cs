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

    // Даты Ивентов
    List<DateOnly> listEventData = new List<DateOnly>();
    List<DateOnly> listDateBrightDay = new List<DateOnly>();

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
                string vivod = dayButton.Content!.ToString()!;

                try
                {
                    var currentDate = new DateOnly(dateNow.Year, dateNow.Month, int.Parse(vivod));

                    if (listEventData.Contains(currentDate) ||
                        listDateBrightDay.Contains(currentDate))
                    {
                        if (CalendarCustomer.SelectedDates.Count >= 5)
                        {
                            dayButton.Background = Brushes.Red;
                            dayButton.Foreground = Brushes.Black;
                        }
                        else if (CalendarCustomer.SelectedDates.Count < 2)
                        {
                            dayButton.Background = Brushes.Green;
                            dayButton.Foreground = Brushes.Black;
                        }
                        else if (CalendarCustomer.SelectedDates.Count >= 2 &&
                                 CalendarCustomer.SelectedDates.Count < 5)
                        {
                            dayButton.Background = Brushes.LightYellow;
                            dayButton.Foreground = Brushes.Red;
                        }
                        else
                        {
                            // по умолчанию
                            dayButton.Background = Brushes.LightGray;
                            dayButton.Foreground = Brushes.Black;
                        }
                    }
                    else
                    {
                        // по умолчанию
                        dayButton.Background = Brushes.LightGray;
                        dayButton.Foreground = Brushes.Black;
                    }
                }
                catch
                {
                    dayButton.Background = Brushes.LightGray;
                    dayButton.Foreground = Brushes.Black;
                }




                //try
                //{
                //    if (listEventData.Contains(new DateOnly(dateNow.Year, dateNow.Month, int.Parse(vivod))) ||
                //        listDateBrightDay.Contains(new DateOnly(dateNow.Year, dateNow.Month, int.Parse(vivod))) && CalendarCustomer.SelectedDates.Count >= 5)
                //    {
                //        dayButton.Background = Brushes.Red;
                //        dayButton.Foreground = Brushes.Black;
                //    }
                //    else
                //    {
                //        dayButton.Background = Brushes.LightGray;
                //        dayButton.Foreground = Brushes.Black;
                //    }
                //    if (listEventData.Contains(new DateOnly(dateNow.Year, dateNow.Month, int.Parse(vivod))) ||
                //        listDateBrightDay.Contains(new DateOnly(dateNow.Year, dateNow.Month, int.Parse(vivod))) && CalendarCustomer.SelectedDates.Count < 2)
                //    {
                //        dayButton.Background = Brushes.Green;
                //        dayButton.Foreground = Brushes.Black;
                //    }

                //    else
                //    {
                //        dayButton.Background = Brushes.LightGray;
                //        dayButton.Foreground = Brushes.Black;
                //    }
                //    if (listEventData.Contains(new DateOnly(dateNow.Year, dateNow.Month, int.Parse(vivod))) ||
                //        listDateBrightDay.Contains(new DateOnly(dateNow.Year, dateNow.Month, int.Parse(vivod))) && 
                //        CalendarCustomer.SelectedDates.Count >= 2 &&
                //        CalendarCustomer.SelectedDates.Count < 5)
                //    {
                //        dayButton.Background = Brushes.LightYellow;
                //        dayButton.Foreground = Brushes.Red;
                //    }
                //    else
                //    {
                //        dayButton.Background = Brushes.LightGray;
                //        dayButton.Foreground = Brushes.Black;
                //    }
                //}
                //catch
                //{
                //    dayButton.Background = Brushes.LightGray;
                //    dayButton.Foreground = Brushes.Black;
                //}
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

        // Загрузка дат для календаря по Ивентам
        listEventData = Helper.Base.EventsCalendars.Select(j => j.EventData).ToList();
        // Загрузка дат для календаря по ДР
        listDateBrightDay = Helper.Base.Employees.Select(j => j.BrightDay).ToList();

        // listDate = Helper.Base.

        // Загружаем данные из JSON
        var baseDirectory = AppContext.BaseDirectory;
        var jsonPath = Path.Combine(baseDirectory, "News", "news_response.json");
        var json = File.ReadAllText(jsonPath);
        
        // Преобразуем данные JSON в список Class1
        newsItems = JsonConvert.DeserializeObject<List<News_Jsons.Class1>>(json);

        // Собираем вводимое значение
        var Search_Text = (SearchText.Text ?? "").ToLower().Split(' ');

        // Поиск по пользователям
        employees = employees.Where(a => Search_Text.Any(news => a.Fio.ToLower().Contains(news.ToLower()) || 
                                                                 a.WorkPhone.ToLower().Contains(news.ToLower()) ||
                                                                 a.CorporateEmail.ToLower().Contains(news.ToLower()) ||
                                                                 a.JobTitleNavigation.Name.ToLower().Contains(news.ToLower())
                                                                 )).ToList();
        // Поиск по событиям
        eventsCalendars = eventsCalendars.Where(b => Search_Text.Any(news => b.Name.ToLower().Contains(news.ToLower()) ||
                                                                             b.EventType.ToLower().Contains(news.ToLower()) ||
                                                                             b.ResponsiblePerson.Fio.ToLower().Contains(news.ToLower())
                                                                             )).ToList();
        // Поиск по новостям
        newsItems = newsItems.Where(g => Search_Text.Any(news => g.title.ToLower().Contains(news.ToLower()) || 
                                                                 g.description.ToLower().Contains(news.ToLower())
                                                                 )).ToList();

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