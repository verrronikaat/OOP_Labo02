namespace OOP_Labo01;

/// <summary>
/// Точка доступа к сервисам приложения (лабораторная: локализация без DI-контейнера).
/// </summary>
public static class AppServices
{
    public static Services.ILocalizationProvider Localization { get; internal set; } = null!;
}
