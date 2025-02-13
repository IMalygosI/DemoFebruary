using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Linq;
using TTTTTTTTT2.Models;

namespace TTTTTTTTT2;

public partial class RedactAndDobav : Window
{
    Employee employee1;

    List<StructuralSeparation> structuralSeparations = new List<StructuralSeparation>();

    List<JobTitle> jobTitles  = new List<JobTitle>();

    List<Employee> employeesAssistAnsSup = new List<Employee>();

    public RedactAndDobav()
    {
        InitializeComponent();
        ListBoxLoang();
        employee1 = new Employee();
    }
    public RedactAndDobav(string dobav, Employee employee)
    {
        InitializeComponent();
        employee1 = employee;
        Title = dobav;
        Save.IsVisible = true;
        RedAndDob.DataContext = employee1;

        ListBoxLoang();
    }
    public RedactAndDobav(string dobav)
    {
        InitializeComponent();
        employee1 = new Employee();
        ListBoxLoang();
        Title = dobav;
    }

    public void ListBoxLoang() 
    {
        if (employee1.Id != 0)
        {
            structuralSeparations = Helper.Base.StructuralSeparations.ToList();
            jobTitles = Helper.Base.JobTitles.ToList();

            Structural_Separation_ComboBox.ItemsSource = structuralSeparations.OrderByDescending(x => x.Id == employee1.StructuralSeparation);
            Job_Title_ComboBox.ItemsSource = jobTitles.OrderByDescending(x => x.Id == employee1.JobTitle);

            Structural_Separation_ComboBox.SelectedIndex = 0;
            Job_Title_ComboBox.SelectedIndex = 0;
        }
        else
        {
            structuralSeparations = Helper.Base.StructuralSeparations.ToList();
            jobTitles = Helper.Base.JobTitles.ToList();

            structuralSeparations.Add(new StructuralSeparation() { Name = "Выбрать структуру" });
            jobTitles.Add(new JobTitle() { Name = "Выбрать работу" });

            Structural_Separation_ComboBox.ItemsSource = structuralSeparations.OrderByDescending(x => x.Name == "Выбрать структуру");
            Job_Title_ComboBox.ItemsSource = jobTitles.OrderByDescending(x => x.Name == "Выбрать работу");

            Structural_Separation_ComboBox.SelectedIndex = 0;
            Job_Title_ComboBox.SelectedIndex = 0;
        }
    }

    private void Button_Click_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }
    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}