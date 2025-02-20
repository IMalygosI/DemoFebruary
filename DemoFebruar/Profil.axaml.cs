using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoFebruar.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DemoFebruar;


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

        Helper.Base.Employees.Include(p => p.StructuralSeparationNavigation)
                             .Include(p => p.JobTitleNavigation)
                             .Include(a => a.AssistantId)
                             .Include(k => k.SupervisorId)
                             .Select(a => a.Id == employee1.StructuralSeparation);

    }

    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    private void Button_Click_Redact(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Profill.IsVisible = false;
        RedactProfil.IsVisible = true;

    }
}