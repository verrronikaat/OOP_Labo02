using System.Globalization;
using System.Resources;
using OOP_Labo01.Localization;

namespace OOP_Labo01.Services;

/// <summary>
/// Локализация через RESX во внешней сборке <c>OOP_Labo01.Localization</c>.
/// </summary>
public sealed class ExternalLibraryLocalizationProvider : ILocalizationProvider
{
    private static readonly ResourceManager Rm = new(
        "OOP_Labo01.Localization.Properties.LibraryStrings",
        typeof(LocalizationAnchor).Assembly);

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
