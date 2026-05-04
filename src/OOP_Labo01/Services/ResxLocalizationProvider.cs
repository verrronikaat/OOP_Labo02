using System.Globalization;
using System.Resources;

namespace OOP_Labo01.Services;

/// <summary>
/// Локализация через встроенные RESX (нейтральный ru + спутник en).
/// </summary>
public sealed class ResxLocalizationProvider : ILocalizationProvider
{
    private static readonly ResourceManager Rm = new(
        "OOP_Labo01.Properties.Resources",
        typeof(ResxLocalizationProvider).Assembly);

    private CultureInfo _culture = CultureInfo.GetCultureInfo("ru-RU");

    public CultureInfo CurrentCulture => _culture;

    public event EventHandler? CultureChanged;

    public string GetString(string key)
    {
        var s = Rm.GetString(key, _culture);
        return string.IsNullOrEmpty(s) ? key : s;
    }

    public void SetCulture(CultureInfo culture)
    {
        _culture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        CultureChanged?.Invoke(this, EventArgs.Empty);
    }
}
