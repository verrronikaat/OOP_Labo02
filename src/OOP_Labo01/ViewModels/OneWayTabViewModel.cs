using OOP_Labo01.Commands;

namespace OOP_Labo01.ViewModels;

/// <summary>
/// Вкладка OneWay: только источник → цель (например, только отображение статуса).
/// </summary>
public sealed class OneWayTabViewModel : ViewModelBase
{
    private string _status = "Готово";
    private bool _isBusy;

    public OneWayTabViewModel()
    {
        RefreshStatusCommand = new RelayCommand(() =>
        {
            Status = IsBusy ? "Ожидание…" : "Готово";
            IsBusy = !IsBusy;
        });
    }

    /// <summary>Статус только для чтения в UI (меняется из VM).</summary>
    public string Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public RelayCommand RefreshStatusCommand { get; }
}
