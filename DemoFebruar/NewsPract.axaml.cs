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

    // ���� �������
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
    /// �������� ��� ������� � ���������
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
                            // �� ���������
                            dayButton.Background = Brushes.LightGray;
                            dayButton.Foreground = Brushes.Black;
                        }
                    }
                    else
                    {
                        // �� ���������
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
    /// �������� ������
    /// </summary>
    public void Loang()
    {
        // �������� ������
        employees = Helper.Base.Employees.Include(a => a.JobTitleNavigation).ToList();
        eventsCalendars = Helper.Base.EventsCalendars.Include(g => g.ResponsiblePerson).ToList();

        // �������� ��� ��� ��������� �� �������
        listEventData = Helper.Base.EventsCalendars.Select(j => j.EventData).ToList();
        // �������� ��� ��� ��������� �� ��
        listDateBrightDay = Helper.Base.Employees.Select(j => j.BrightDay).ToList();

        // listDate = Helper.Base.

        // ��������� ������ �� JSON
        var baseDirectory = AppContext.BaseDirectory;
        var jsonPath = Path.Combine(baseDirectory, "News", "news_response.json");
        var json = File.ReadAllText(jsonPath);
        
        // ����������� ������ JSON � ������ Class1
        newsItems = JsonConvert.DeserializeObject<List<News_Jsons.Class1>>(json);

        // �������� �������� ��������
        var Search_Text = (SearchText.Text ?? "").ToLower().Split(' ');

        // ����� �� �������������
        employees = employees.Where(a => Search_Text.Any(news => a.Fio.ToLower().Contains(news.ToLower()) || 
                                                                 a.WorkPhone.ToLower().Contains(news.ToLower()) ||
                                                                 a.CorporateEmail.ToLower().Contains(news.ToLower()) ||
                                                                 a.JobTitleNavigation.Name.ToLower().Contains(news.ToLower())
                                                                 )).ToList();
        // ����� �� ��������
        eventsCalendars = eventsCalendars.Where(b => Search_Text.Any(news => b.Name.ToLower().Contains(news.ToLower()) ||
                                                                             b.EventType.ToLower().Contains(news.ToLower()) ||
                                                                             b.ResponsiblePerson.Fio.ToLower().Contains(news.ToLower())
                                                                             )).ToList();
        // ����� �� ��������
        newsItems = newsItems.Where(g => Search_Text.Any(news => g.title.ToLower().Contains(news.ToLower()) || 
                                                                 g.description.ToLower().Contains(news.ToLower())
                                                                 )).ToList();

        // �������� �����������
        Listbox_Employee.ItemsSource = employees;
        // �������� ��������
        Listbox_News.ItemsSource = newsItems;
        //�������� �������
        ListBox_Sob.ItemsSource = eventsCalendars;
    }

    /// <summary>
    /// �������� �� ���� � ����������
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => Loang();

    /// <summary>
    /// ����� � ���� ������
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