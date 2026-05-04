using System.Windows.Controls;
using OOP_Labo01.ViewModels;

namespace OOP_Labo01.Views;

/// <summary>
/// Вкладка 1: демонстрация привязки в режиме Default.
/// </summary>
public partial class DefaultBindingTabView : UserControl
{
    public DefaultBindingTabView()
    {
        InitializeComponent();
        DataContext = new DefaultBindingTabViewModel();
    }
}
