using Avalonia.Controls;
using DemoFebruar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoFebruar
{
    public partial class MainWindow : Window
    {
        List<Employee> employees = new List<Employee>();
        int VariantDep = 0;
        int DopOtdel = 0;
        public MainWindow()
        {
            InitializeComponent();
            LoadEmployees();
        }

        /// <summary>
        /// �������� ������
        /// </summary>
        public void LoadEmployees()
        {
            // �������� ���� �����������
            employees = Helper.Base.Employees.Include(a => a.JobTitleNavigation)
                                             .Include(a => a.StructuralSeparationNavigation).ToList();

            if (DopOtdel == 0)
            {
                AdministrativeDepartament.IsVisible = false; //  ��� ����������� �� ������ �������������.
                VseDepartament.IsVisible = true; // ��� ���� �����������

                employees = Helper.Base.Employees.Include(a => a.JobTitleNavigation)
                                             .Include(a => a.StructuralSeparationNavigation).ToList();
            }
            if (DopOtdel == 1)
            {
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = true; //  ��� ����������� �� ������ �������������. 

                if (VariantDep == 1) 
                {
                    var element = employees.Where(e => e.StructuralSeparationNavigation.Divisions.Any(d => d.IdPototdel == VariantDep)).ToList();

                    //employees = employees.Select(g =>g.StructuralSeparation = element).ToList();

                }
                else if (VariantDep == 2)
                {
                    employees = employees.Where(e => e.StructuralSeparationNavigation.Divisions.Any(d => d.IdPototdel == VariantDep)).ToList();
                }
            }

            /*
            if (DopOtdel == 2)
            {
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = true; //  ��� ����������� �� ������ �������������. 

                if (VariantDep == 1)
                {
                    employees = employees.Where(e => e.StructuralSeparationNavigation.Divisions.Any(d => d.IdPototdel == VariantDep)).ToList();
                }
                else if (VariantDep == 2)
                {
                    employees = employees.Where(e => e.StructuralSeparationNavigation.Divisions.Any(d => d.IdPototdel == VariantDep)).ToList();
                }
            }
            */

            ListBox_Personal.ItemsSource = employees;
        }

        /// <summary>
        /// ���������� ����������� �� ������������� ! ��������� ���� ���������� ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Department(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Button button && int.TryParse(button.Tag.ToString(), out int departmentId))
            {
                VariantDep = departmentId;
                LoadEmployees(); // ��������� ����������� ��� ���������� ������
            }
        }

        /// <summary>
        /// ��������� ����� ������ ������ ����� � ��� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_DepartmentSort(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            VariantDep = 0;
            if (sender is Button button && int.TryParse(button.Tag.ToString(), out int departmentId))
            {
                DopOtdel = departmentId;
                LoadEmployees();
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_Dob(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            string dobav = "����������";
            RedactAndDobav redactAndDobav = new RedactAndDobav(dobav);
            redactAndDobav.Show();
            Close();
        }

        /// <summary>
        /// �������� �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_DoubleTapped_Redact(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var vib = ListBox_Personal.SelectedItem as Employee;

            Profil profil = new Profil(vib);
            profil.Show();
            Close();
        }

    }
}