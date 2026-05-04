using OOP_Labo01.Models;

namespace OOP_Labo01.ViewModels;

/// <summary>
/// Вкладка «режим Default»: значение по умолчанию для Mode зависит от свойства (у TextBox — обычно TwoWay).
/// </summary>
public sealed class DefaultBindingTabViewModel : ViewModelBase
{
    private string _demoText = "Текст из ViewModel";
    private readonly DemoMessage _caption = new("Подпись через модель");

    public DefaultBindingTabViewModel()
    {
        // Демонстрация: модель можно отобразить через вложенное свойство в привязке.
    }

    /// <summary>Строка для привязки без явного Mode (режим по умолчанию для свойства).</summary>
    public string DemoText
    {
        get => _demoText;
        set => SetProperty(ref _demoText, value);
    }

    /// <summary>Модель для примера Path=Caption.Text.</summary>
    public DemoMessage Caption => _caption;
}
