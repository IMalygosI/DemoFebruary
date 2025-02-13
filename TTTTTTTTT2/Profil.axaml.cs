using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TTTTTTTTT2.Models;

namespace TTTTTTTTT2;

public partial class Profil : Window
{
    Employee employee1;

    public Profil()
    {
        InitializeComponent();
    }
    public Profil(Employee employee)
    {
        InitializeComponent();
        employee1 = employee;

        prof.DataContext = employee1;

        Helper.Base.Employees.Include(p => p.StructuralSeparationNavigation).Include(p => p.JobTitleNavigation).Include(a => a.AssistantId).Include(k=>k.SupervisorId).Select(a => a.Id == employee1.StructuralSeparation);

        if (employee1.AssistantId == 0) 
        {
            Assistant.Text = "Отсутствует";
        }
        if (employee1.SupervisorId == 0)
        {
            Supervisor.Text = "Отсутствует";
        }

    }

    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void Button_Click_Redact(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string dobav = "Редактирование";
        RedactAndDobav redactAndDobav = new RedactAndDobav(dobav, employee1);
        redactAndDobav.Show();
        Close();
    }
}