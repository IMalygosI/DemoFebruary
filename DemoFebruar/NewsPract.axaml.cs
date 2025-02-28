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
    /// �������� ������
    /// </summary>
    public void Loang() 
    {
        employees = Helper.Base.Employees.Include(a => a.JobTitleNavigation).ToList();
        // ��������� ������ �� JSON
        var json = File.ReadAllText("News/news_response.json");
        // ����������� ������ JSON � ������ Class1
        newsItems = JsonConvert.DeserializeObject<List<News_Jsons.Class1>>(json);





        // �������� �����������
        Listbox_Employee.ItemsSource = employees;
        // �������� ��������
        Listbox_News.ItemsSource = newsItems;
    }


    private void TextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e) => Loang();
}