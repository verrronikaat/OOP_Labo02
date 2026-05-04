using System.Windows.Controls;
using OOP_Labo01.ViewModels;

namespace OOP_Labo01.Views;

/// <summary>
/// Вкладка 3: одноразовая привязка (OneTime).
/// </summary>
public partial class OneTimeTabView : UserControl
{
    public OneTimeTabView()
    {
        InitializeComponent();
        DataContext = new OneTimeTabViewModel();
    }
}
