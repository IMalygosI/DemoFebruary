using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoFebruar.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DemoFebruar;

public partial class NewsPract : Window
{
    List<Employee> employees = new List<Employee>();
    List<News_Jsons.Class1> newsItems = new List<News_Jsons.Class1>();

    public NewsPract()
    {
        InitializeComponent();
        Loang();
    }

    /// <summary>
    /// Загрузка данных
    /// </summary>
    public void Loang()
    {
        employees = Helper.Base.Employees.Include(a => a.JobTitleNavigation).ToList();

        // Загружаем данные из JSON
        var baseDirectory = AppContext.BaseDirectory;
        var jsonPath = Path.Combine(baseDirectory, "News", "news_response.json");
        var json = File.ReadAllText(jsonPath);
        // Преобразуем данные JSON в список Class1
        newsItems = JsonConvert.DeserializeObject<List<News_Jsons.Class1>>(json);





        // Загрузка сотрудников
        Listbox_Employee.ItemsSource = employees;
        // Загрузка новостей
        Listbox_News.ItemsSource = newsItems;
    }


    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => Loang();
    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Navigation navigation = new Navigation();
        navigation.Show();
        Close();
    }
}