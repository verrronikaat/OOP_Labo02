using System.Globalization;
using System.Windows;

namespace OOP_Labo01.Services;

/// <summary>
/// Локализация через словари ResourceDictionary (XAML), подменяемые в MergedDictionaries приложения.
/// </summary>
public sealed class XamlDictionaryLocalizationProvider : ILocalizationProvider
{
    private CultureInfo _culture = CultureInfo.GetCultureInfo("ru-RU");

    public CultureInfo CurrentCulture => _culture;

    public event EventHandler? CultureChanged;

    public string GetString(string key)
    {
        if (Application.Current is null)
            return key;

        return Application.Current.TryFindResource(key) as string ?? key;
    }

    public void SetCulture(CultureInfo culture)
    {
        _culture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
        ApplyDictionary(culture);
        CultureChanged?.Invoke(this, EventArgs.Empty);
    }

    private static void ApplyDictionary(CultureInfo culture)
    {
        var app = Application.Current ?? throw new InvalidOperationException("Application not started.");
        var merged = app.Resources.MergedDictionaries;

        for (var i = merged.Count - 1; i >= 0; i--)
        {
            var src = merged[i].Source;
            if (src is not null && src.ToString().Contains("UiStrings.", StringComparison.OrdinalIgnoreCase))
                merged.RemoveAt(i);
        }

        var tag = culture.TwoLetterISOLanguageName.StartsWith("en", StringComparison.OrdinalIgnoreCase)
            ? "en"
            : "ru";

        merged.Add(new ResourceDictionary
        {
            Source = new Uri($"pack://application:,,,/Resources/UiStrings.{tag}.xaml", UriKind.Absolute),
        });
    }
}
