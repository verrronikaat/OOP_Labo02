using System.Windows.Controls;
using OOP_Labo01.ViewModels;

namespace OOP_Labo01.Views;

/// <summary>
/// Вкладка 5: триггеры в стилях (DataTrigger, Trigger, EventTrigger).
/// </summary>
public partial class TriggersTabView : UserControl
{
    public TriggersTabView()
    {
        InitializeComponent();
        DataContext = new TriggersTabViewModel();
    }
}
