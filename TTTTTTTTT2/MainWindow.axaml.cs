using Avalonia.Controls;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TTTTTTTTT2.Models;

namespace TTTTTTTTT2
{
    public partial class MainWindow : Window
    {
        List<Employee> employees = new List<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            Loang();
        }
        public void Loang() 
        {
            employees = Helper.Base.Employees.Include(a =>a.JobTitleNavigation).Include(a => a.StructuralSeparationNavigation).ToList();

            ListBox_Personal.ItemsSource = employees;
        }

        private void Button_Click_Dob(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            string dobav = "Добавление";
            RedactAndDobav redactAndDobav = new RedactAndDobav(dobav);
            redactAndDobav.Show();
            Close();
        }

        private void ListBox_DoubleTapped_Redact(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            var vib = ListBox_Personal.SelectedItem as Employee;
            
            Profil profil = new Profil(vib);
            profil.Show();
            Close();


            /*
            var vib = ListBox_Personal.SelectedItem as Employee;
            string dobav = "Редактирование";
            RedactAndDobav redactAndDobav = new RedactAndDobav(dobav, vib);
            redactAndDobav.Show();
            Close();*/
        }
    }
}