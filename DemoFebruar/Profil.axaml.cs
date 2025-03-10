using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using DemoFebruar.Context;
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
    List<Division> divisionss = new List<Division>();

    /// <summary>
    /// Создание нового Employee
    /// </summary>
    public Profil()
    {
        InitializeComponent();
        employee1 = new Employee();
        Uvolit.IsVisible = false;
        Otmena.IsVisible = false;
        Profill.IsVisible = false;
        RedactProfil.IsVisible = true;

        Loang_ComboBox();
    }

    /// <summary>
    /// Открытие профиля с возможность редактирования
    /// </summary>
    /// <param name="employee"></param>
    public Profil(Employee employee)
    {
        InitializeComponent();
        employee1 = employee;

        prof.DataContext = employee1;

        Helper.Base.Employees.Include(p => p.JobTitleNavigation)
                             .Include(a => a.IdOtdels)
                             .Include(a => a.AssistantId)
                             .Include(k => k.SupervisorId);

        BrightDayBox.SelectedDate = new DateTimeOffset(employee1.BrightDay.Year, employee1.BrightDay.Month, employee1.BrightDay.Day, 0, 0, 0, new TimeSpan());

        Loang_ComboBox();
    }

    /// <summary>
    /// Загрузка данных во все комбобоксы
    /// </summary>
    public void Loang_ComboBox()
    {
        if (employee1.Id != 0)
        {
            cabinets = Helper.Base.Cabinets.ToList();
            Cabinetss.ItemsSource = cabinets.OrderByDescending(g => g.Id == employee1.Cabinet);
            Cabinetss.SelectedIndex = 0;

            divisionss = Helper.Base.Divisions.ToList();
            structuralseparationS.ItemsSource = divisionss.OrderByDescending(g => g.Id == employee1.Id);
            structuralseparationS.SelectedIndex = 0;

            jobTitl = Helper.Base.JobTitles.ToList();
            Jobs.ItemsSource = jobTitl.OrderByDescending(g => g.Id == employee1.JobTitle);
            Jobs.SelectedIndex = 0;
        }
        else
        {
            cabinets = Helper.Base.Cabinets.ToList();
            cabinets.Add(new Cabinet() { Cabinet1 = "Выбрать кабинет" });
            Cabinetss.ItemsSource = cabinets.OrderByDescending(g => g.Cabinet1 == "Выбрать кабинет");
            Cabinetss.SelectedIndex = 0;

            divisionss = Helper.Base.Divisions.ToList();
            divisionss.Add(new Division() { Name = "Выбрать подразделение" });
            structuralseparationS.ItemsSource = divisionss.OrderByDescending(g => g.Name == "Выбрать подразделение");
            structuralseparationS.SelectedIndex = 0;

            jobTitl = Helper.Base.JobTitles.ToList();
            jobTitl.Add(new JobTitle() { Name = "Выбрать работу" });
            Jobs.ItemsSource = jobTitl.OrderByDescending(g => g.Name == "Выбрать работу");
            Jobs.SelectedIndex = 0;
        }

    }

    /// <summary>
    /// Выход из профиля
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click_Out(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    /// <summary>
    /// Редактирование профиля
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click_Redact(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Profill.IsVisible = false;
        RedactProfil.IsVisible = true;

    }

    /// <summary>
    /// Сохранение данных
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click_Save(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (employee1.Id != 0)
        {
            if (Cabinetss.SelectedItem is Cabinet CABINET)
            {
                employee1.Cabinet = CABINET.Id;
            }
            if (structuralseparationS.SelectedItem is Division DIVISIONS)
            {
                employee1.Id = DIVISIONS.Id;
            }
            if (Jobs.SelectedItem is JobTitle JOBS)
            {
                employee1.JobTitle = JOBS.Id;
            }

            employee1.BrightDay = new DateOnly(BrightDayBox.SelectedDate.Value.Year, BrightDayBox.SelectedDate.Value.Month, BrightDayBox.SelectedDate.Value.Day);


            using (var context = new DimaBaseContext())
            {
                employee1.IdOtdels.Clear();
                context.SaveChanges();
            }

            employee1.IdOtdels.Add(structuralseparationS.SelectedItem as Division);


            Helper.Base.Employees.Update(employee1);
        }
        else
        {
            employee1.Fio = FIO.Text;
            employee1.WorkPhone = phoneMaskedTextBox.Text;
            employee1.CorporateEmail = corporateEmail.Text;

            employee1.Cabinet = Cabinetss.SelectedIndex;

            employee1.IdOtdels.Add(structuralseparationS.SelectedItem as Division);

            employee1.JobTitle = Jobs.SelectedIndex;

            employee1.BrightDay = new DateOnly(BrightDayBox.SelectedDate.Value.Year, BrightDayBox.SelectedDate.Value.Month, BrightDayBox.SelectedDate.Value.Day);

            Helper.Base.Employees.Add(employee1);
        }

        if (employee1.Fio != null)
        {
            if (employee1.IdOtdels != null)
            {
                if (employee1.JobTitle != null && employee1.JobTitle != 0)
                {
                    if (employee1.WorkPhone != null)
                    {
                        if (employee1.Cabinet != null && employee1.Cabinet != 0)
                        {
                            if (employee1.BrightDay != null)
                            {
                                using (var context = new DimaBaseContext())
                                {
                                    context.SaveChanges();
                                }

                                Profill.IsVisible = true;
                                RedactProfil.IsVisible = false;
                            }
                            else
                            {
                                string warning = "Ошибка! Введите день рождения!";
                                Error error = new Error(warning);
                                error.ShowDialog(this);
                            }
                        }
                        else
                        {
                            string warning = "Ошибка! Выберите кабинет!";
                            Error error = new Error(warning);
                            error.ShowDialog(this);
                        }
                    }
                    else
                    {
                        string warning = "Ошибка! Введите телефон!";
                        Error error = new Error(warning);
                        error.ShowDialog(this);
                    }
                }
                else
                {
                    string warning = "Ошибка! Выберите работу!";
                    Error error = new Error(warning);
                    error.ShowDialog(this);
                }
            }
            else
            {
                string warning = "Ошибка! Выберите Структуру!";
                Error error = new Error(warning);
                error.ShowDialog(this);
            }
        }
        else
        {
            string warning = "Ошибка! Введите ФИО!";
            Error error = new Error(warning);
            error.ShowDialog(this);
        }

        prof.DataContext = null;
        prof.DataContext = employee1;

    }

    /// <summary>
    /// Увольнение Employee
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click_Udlit(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        Helper.Base.Employees.Remove(employee1);
        Helper.Base.SaveChanges();

        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        Close();
    }

    /// <summary>
    /// Отмена действий
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click_Otmen(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Profill.IsVisible = true;
        RedactProfil.IsVisible = false;
    }
}