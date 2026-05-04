namespace OOP_Labo01.ViewModels;

/// <summary>
/// ViewModel главного окна: заголовок и при необходимости общие настройки.
/// Содержимое вкладок вынесено в отдельные UserControl + свои ViewModel.
/// </summary>
public sealed class MainViewModel : ViewModelBase
{
    private string _windowTitle = "ЛР1 — Привязки данных WPF (MVVM, без NuGet)";

    /// <summary>
    /// Заголовок окна (демонстрация привязки к окну).
    /// </summary>
    public string WindowTitle
    {
        get => _windowTitle;
        set => SetProperty(ref _windowTitle, value);
    }
}
