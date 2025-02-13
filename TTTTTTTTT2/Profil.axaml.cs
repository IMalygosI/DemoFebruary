using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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



    }




}