using OOP_Labo01.Services;

namespace OOP_Labo01.ViewModels;

/// <summary>
/// Пункт выбора языка: подпись обновляется при смене культуры (для ComboBox).
/// </summary>
public sealed class CultureItem : ViewModelBase
{
    public CultureItem(string tag)
    {
        Tag = tag;
        LocalizationBroker.Refreshed += (_, _) => OnPropertyChanged(nameof(Label));
    }

    public string Tag { get; }

    public string Label =>
        Tag.StartsWith("ru", StringComparison.OrdinalIgnoreCase)
            ? LocalizationBroker.Instance.LangRussian
            : LocalizationBroker.Instance.LangEnglish;
}
