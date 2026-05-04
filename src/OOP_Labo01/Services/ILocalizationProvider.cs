using System.Globalization;

namespace OOP_Labo01.Services;

/// <summary>
/// Поставщик строк для смены языка без перезапуска приложения.
/// </summary>
public interface ILocalizationProvider
{
    CultureInfo CurrentCulture { get; }

    string GetString(string key);

    void SetCulture(CultureInfo culture);

    event EventHandler? CultureChanged;
}
