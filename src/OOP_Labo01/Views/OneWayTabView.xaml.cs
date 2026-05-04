using System.Windows.Controls;
using OOP_Labo01.ViewModels;

namespace OOP_Labo01.Views;

/// <summary>
/// Вкладка 4: односторонняя привязка (OneWay).
/// </summary>
public partial class OneWayTabView : UserControl
{
    public OneWayTabView()
    {
        InitializeComponent();
        DataContext = new OneWayTabViewModel();
    }
}
