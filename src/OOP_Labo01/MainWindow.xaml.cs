using System.Windows;
using OOP_Labo01.ViewModels;

namespace OOP_Labo01;

/// <summary>
/// Главное окно: только назначение DataContext — логика во ViewModel.
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}
