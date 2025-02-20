using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoFebruar.Models;
using System.Collections.Generic;
using System.Linq;

namespace DemoFebruar;


public partial class RedactAndDobav : Window
{
    Employee employee1;

    List<StructuralSeparation> structuralSeparations = new List<StructuralSeparation>();

    List<JobTitle> jobTitles = new List<JobTitle>();

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




        Save.IsVisible = true;
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
        if (employee1.Id != 0)
        {
            if (Job_Title_ComboBox.SelectedItem is JobTitle job)
            {
                employee1.JobTitle = job.Id;
            }
            if (Structural_Separation_ComboBox.SelectedItem is StructuralSeparation structural)
            {
                employee1.StructuralSeparation = structural.Id;
            }


            if (Structural_Separation_ComboBox.SelectedItem is Employee employeeST)
            {
                employee1.SupervisorId = employeeST.Id;
            }
            if (Assistant_ID_ComboBox.SelectedItem is Employee employeeAS)
            {
                employee1.AssistantId = employeeAS.Id;
            }

            Helper.Base.Employees.Update(employee1);
        }
        else
        {
            employee1.Fio = FIO.Text;




            Helper.Base.Employees.Add(employee1);
        }

        /*
        if (employee1.Fio != )
        {
            Helper.Base.SaveChanges();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        else 
        {
            string Warning = "Ошибка! Введите ФИО!";
            Error error = new Error(Warning);
            error.ShowDialog(this);
            Close();
        }
        */
    }
    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }
}