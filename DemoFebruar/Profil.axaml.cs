using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using DemoFebruar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DemoFebruar;


public partial class Profil : Window
{
    Employee employee1;
    List<Cabinet> cabinets = new List<Cabinet>();
    List<JobTitle> jobTitl = new List<JobTitle>();
    List<PotOtdel> potOtdel = new List<PotOtdel>();
    List<StructuralSeparation> structuralSeparation = new List<StructuralSeparation>();

    public Profil()
    {fafasdfa
        InitializeComponent();
        employee1 = new Employee();
        Uvolit.IsVisible = false;
        Profill.IsVisible = false;
        RedactProfil.IsVisible = true;

        Loang_ComboBox();
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


        BrightDayBox.SelectedDate = new DateTimeOffset(employee1.BrightDay.Year, employee1.BrightDay.Month, employee1.BrightDay.Day,0,0,0,new TimeSpan());

        Loang_ComboBox();
    }


    public void Loang_ComboBox()
    {
        if (employee1.Id != 0)
        {
            cabinets = Helper.Base.Cabinets.ToList();
            Cabinetss.ItemsSource = cabinets.OrderByDescending(g => g.Id == employee1.Cabinet);
            Cabinetss.SelectedIndex = 0;

            structuralSeparation = Helper.Base.StructuralSeparations.ToList();
            structuralseparationS.ItemsSource = structuralSeparation.OrderByDescending(g => g.Id == employee1.StructuralSeparation);
            structuralseparationS.SelectedIndex = 0;

            jobTitl = Helper.Base.JobTitles.ToList();
            Jobs.ItemsSource = jobTitl.OrderByDescending(g => g.Id == employee1.JobTitle);
            Jobs.SelectedIndex = 0;

            /*
            potOtdel = Helper.Base.PotOtdels.ToList();
            pototdel.ItemsSource = potOtdel.OrderByDescending(g => g.Id == employee1.StructuralSeparationNavigation.Divisions.Any(x => x.IdPototdelNavigation.Id));
            pototdel.SelectedIndex = 0;
            */

        }
        else
        {
            cabinets = Helper.Base.Cabinets.ToList();
            cabinets.Add(new Cabinet() { Cabinet1 = "������� �������" });
            Cabinetss.ItemsSource = cabinets.OrderByDescending(g => g.Cabinet1 == "������� �������");
            Cabinetss.SelectedIndex = 0;

            structuralSeparation = Helper.Base.StructuralSeparations.ToList();
            structuralSeparation.Add(new StructuralSeparation() { Name = "������� �������������" });
            structuralseparationS.ItemsSource = structuralSeparation.OrderByDescending(g => g.Name == "������� �������������");
            structuralseparationS.SelectedIndex = 0;

            jobTitl = Helper.Base.JobTitles.ToList();
            jobTitl.Add(new JobTitle() { Name = "������� ������" });
            Jobs.ItemsSource = jobTitl.OrderByDescending(g => g.Name == "������� ������");
            Jobs.SelectedIndex = 0;
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
        Profill.IsVisible = false;
        RedactProfil.IsVisible = true;

    }

    private void Button_Click_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (employee1.Id != 0)
        {
            if (Cabinetss.SelectedItem is Cabinet CABINET)
            {
                employee1.Cabinet = CABINET.Id;
            }
            if (structuralseparationS.SelectedItem is StructuralSeparation STRUCTUAL)
            {
                employee1.StructuralSeparation = STRUCTUAL.Id;
            }
            if (Jobs.SelectedItem is JobTitle JOBS)
            {
                employee1.JobTitle = JOBS.Id;
            }

            employee1.BrightDay = new DateOnly(BrightDayBox.SelectedDate.Value.Year, BrightDayBox.SelectedDate.Value.Month, BrightDayBox.SelectedDate.Value.Day);

            Helper.Base.Employees.Update(employee1);
        }
        else
        {
            employee1.Fio = FIO.Text;
            employee1.WorkPhone = phoneMaskedTextBox.Text;
            employee1.CorporateEmail = corporateEmail.Text;

            employee1.Cabinet = Cabinetss.SelectedIndex;
            employee1.StructuralSeparation = structuralseparationS.SelectedIndex;
            employee1.JobTitle = Jobs.SelectedIndex;

            employee1.BrightDay = new DateOnly(BrightDayBox.SelectedDate.Value.Year, BrightDayBox.SelectedDate.Value.Month, BrightDayBox.SelectedDate.Value.Day);

            Helper.Base.Employees.Add(employee1);
        }

        if (employee1.Fio != null)
        {
            if (employee1.StructuralSeparation != null & employee1.StructuralSeparation != 0)
            {
                if (employee1.JobTitle != null && employee1.JobTitle != 0)
                {
                    if (employee1.WorkPhone != null)
                    {
                        if (employee1.Cabinet != null && employee1.Cabinet != 0)
                        {
                            if (employee1.BrightDay != null)
                            {
                                Helper.Base.SaveChanges();
                                Profill.IsVisible = true;
                                RedactProfil.IsVisible = false;
                            }
                            else
                            {
                                string warning = "������! ������� ���� ��������!";
                                Error error = new Error(warning);
                                error.ShowDialog(this);
                            }
                        }
                        else
                        {
                            string warning = "������! �������� �������!";
                            Error error = new Error(warning);
                            error.ShowDialog(this);
                        }
                    }
                    else
                    {
                        string warning = "������! ������� �������!";
                        Error error = new Error(warning);
                        error.ShowDialog(this);
                    }
                }
                else
                {
                    string warning = "������! �������� ������!";
                    Error error = new Error(warning);
                    error.ShowDialog(this);
                }
            }
            else
            {
                string warning = "������! �������� ���������!";
                Error error = new Error(warning);
                error.ShowDialog(this);
            }
        }
        else
        {
            string warning = "������! ������� ���!";
            Error error = new Error(warning);
            error.ShowDialog(this);
        }

        prof.DataContext = null;
        prof.DataContext = employee1;

    }

    private void Button_Click_Udlit(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        


    }

    private void Button_Click_Otmen(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Profill.IsVisible = true;
        RedactProfil.IsVisible = false;
    }
}