using Avalonia.Controls;
using DemoFebruar.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemoFebruar
{
    public partial class MainWindow : Window
    {
        private List<Employee> employees;    // ��������������� ����������
        private int VariantDep = 0;
        private int Deportament = 0;

        public MainWindow()
        {
            InitializeComponent();
            LoadEmployees(); // ��������� ����������� ��� �������
        }

        /// <summary>
        /// �������� � ���������� ������ (���������� � �����)
        /// </summary>
        private void LoadEmployees()
        {
            employees = Helper.Base.Employees.Include(a => a.JobTitleNavigation)
                                             .Include(a => a.IdOtdels)
                                             .Include(a => a.CabinetNavigation).ToList();

            if (Deportament == 0)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = false;
                ApparatUpravlenDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = false;
                AdministrativeDepartament.IsVisible = false;
                VseDepartament.IsVisible = true;

                // ���������� ���� �����������
                employees = employees.ToList();
            }
            else if (Deportament == 1)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = false;
                ApparatUpravlenDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = false;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = true; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x=>x.Id == VariantDep)).ToList();  

                }
            }
            else if (Deportament == 2)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = true;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = false; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x => x.Id == VariantDep)).ToList();


                }
            }
            else if (Deportament == 3)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = false;
                ApparatUpravlenDepartament.IsVisible = true;
                AcademicDorogiDepartament.IsVisible = false;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = false; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x => x.Id == VariantDep)).ToList();


                }
            }
            else if (Deportament == 4)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = true;
                ApparatUpravlenDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = false;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = false; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x => x.Id == VariantDep)).ToList();


                }
            }
            else if (Deportament == 5)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = true;
                CommunicatorDepartament.IsVisible = false;
                ApparatUpravlenDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = false;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = false; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x => x.Id == VariantDep)).ToList();


                }
            }
            else if (Deportament == 6)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = true;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = false;
                ApparatUpravlenDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = false;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = false; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x => x.Id == VariantDep)).ToList();

                }
            }
            else if (Deportament == 7)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = true;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = false;
                ApparatUpravlenDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = false;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = false; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x => x.Id == VariantDep)).ToList();

                }
            }
            else if (Deportament == 8)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = true;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = false;
                ApparatUpravlenDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = false;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = false; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x => x.Id == VariantDep)).ToList();

                }
            }
            else if (Deportament == 9)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = true;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = false;
                ApparatUpravlenDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = false;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = false; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x => x.Id == VariantDep)).ToList();

                }
            }
            else if (Deportament == 10)
            {
                UpravlenFinansamiDepartament.IsVisible = true;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = false;
                ApparatUpravlenDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = false;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = false; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x => x.Id == VariantDep)).ToList();

                }
            }
            else if (Deportament == 11)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = false;
                KaznaDepartament.IsVisible = true;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = false;
                ApparatUpravlenDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = false;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = false; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x => x.Id == VariantDep)).ToList();

                }
            }
            else if (Deportament == 12)
            {
                UpravlenFinansamiDepartament.IsVisible = false;
                UpravObespDepartament.IsVisible = true;
                KaznaDepartament.IsVisible = false;
                AnaliticDepartament.IsVisible = false;
                WorkPromDepartament.IsVisible = false;
                WorkPersonalDepartament.IsVisible = false;
                CorrporatDepartament.IsVisible = false;
                MarcetingDepartament.IsVisible = false;
                CommunicatorDepartament.IsVisible = false;
                ApparatUpravlenDepartament.IsVisible = false;
                AcademicDorogiDepartament.IsVisible = false;
                VseDepartament.IsVisible = false; // ��� ���� �����������
                AdministrativeDepartament.IsVisible = false; // ��� ����������� �� ������ �������������.

                if (VariantDep != 0)
                {

                    employees = employees.Where(x => x.IdOtdels.Any(x => x.Id == VariantDep)).ToList();

                }
            }

            ListBox_Personal.ItemsSource = employees;
        }

        /// <summary>
        /// ���������� ����������� �� �������������
        /// </summary>
        private void Button_Click_Department(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Button button && int.TryParse(button.Tag.ToString(), out int departmentId))
            {
                VariantDep = departmentId;
                LoadEmployees(); // ��������� ����������
            }
        }

        /// <summary>
        /// ��������� ����� ������ ������ ����� � ��� �����
        /// </summary>
        private void Button_Click_DepartmentSort(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (sender is Button button && int.TryParse(button.Tag.ToString(), out int departmentId))
            {
                Deportament = departmentId;
                LoadEmployees(); // ��������� ����������
            }
        }

        /// <summary>
        /// ����������
        /// </summary>
        private void Button_Click_Dob(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Profil redactAndDobav = new Profil();
            redactAndDobav.Show();
            Close();
        }

        /// <summary>
        /// �������� �������
        /// </summary>
        private void ListBox_DoubleTapped_Redact(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var vib = ListBox_Personal.SelectedItem as Employee;

            Profil profil = new Profil(vib);
            profil.Show();
            Close();
        }

        /// <summary>
        /// ����� � ���� ���������
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
}