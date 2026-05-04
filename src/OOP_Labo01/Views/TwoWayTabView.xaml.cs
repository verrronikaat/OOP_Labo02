using System.Windows.Controls;
using OOP_Labo01.ViewModels;

namespace OOP_Labo01.Views;

/// <summary>
/// Вкладка 2: двусторонняя привязка (TwoWay).
/// </summary>
public partial class TwoWayTabView : UserControl
{
    public TwoWayTabView()
    {
        InitializeComponent();
        DataContext = new TwoWayTabViewModel();
    }
}
