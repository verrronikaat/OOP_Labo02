using OOP_Labo01.Commands;
using OOP_Labo01.Services;

namespace OOP_Labo01.ViewModels;

/// <summary>
/// Вкладка OneWay: статусы берутся из строковых ресурсов при смене языка.
/// </summary>
public sealed class OneWayTabViewModel : ViewModelBase
{
    private string _status = "";
    private bool _isBusy;

    public OneWayTabViewModel()
    {
        RefreshStatusCommand = new RelayCommand(_ => IsBusy = !IsBusy);
        LocalizationBroker.Refreshed += (_, _) => ApplyStatusText();
        ApplyStatusText();
    }

    private void ApplyStatusText()
    {
        Status = IsBusy
            ? AppServices.Localization.GetString(nameof(LocalizationBroker.StatusWaiting))
            : AppServices.Localization.GetString(nameof(LocalizationBroker.StatusReady));
    }

    public string Status
    {
        get => _status;
        set => SetProperty(ref _status, value);
    }

    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (SetProperty(ref _isBusy, value))
                ApplyStatusText();
        }
    }

    public RelayCommand RefreshStatusCommand { get; }
}
