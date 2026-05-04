using OOP_Labo01.Commands;

namespace OOP_Labo01.ViewModels;

/// <summary>
/// Вкладка с триггерами: свойства для DataTrigger и счётчик для демонстрации EventTrigger/анимации.
/// </summary>
public sealed class TriggersTabViewModel : ViewModelBase
{
    private bool _isAlert;
    private int _clickCount;

    public TriggersTabViewModel()
    {
        ToggleAlertCommand = new RelayCommand(() => IsAlert = !IsAlert);
        IncrementCommand = new RelayCommand(() => ClickCount++);
    }

    /// <summary>Флаг для DataTrigger (например, «тревожный» стиль).</summary>
    public bool IsAlert
    {
        get => _isAlert;
        set => SetProperty(ref _isAlert, value);
    }

    public int ClickCount
    {
        get => _clickCount;
        set => SetProperty(ref _clickCount, value);
    }

    public RelayCommand ToggleAlertCommand { get; }
    public RelayCommand IncrementCommand { get; }
}
