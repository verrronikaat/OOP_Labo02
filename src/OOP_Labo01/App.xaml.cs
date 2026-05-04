using System.Globalization;
using System.Windows;
using OOP_Labo01.Services;

namespace OOP_Labo01;

/// <summary>
/// Точка входа WPF-приложения (лабораторная работа: привязки, MVVM, локализация).
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var provider = new ResxLocalizationProvider();
        AppServices.Localization = provider;
        LocalizationBroker.Initialize(provider);
        provider.SetCulture(CultureInfo.GetCultureInfo("ru-RU"));
        base.OnStartup(e);
    }
}
