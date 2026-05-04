using OOP_Labo01.Services;

namespace OOP_Labo01.ViewModels;

/// <summary>
/// Вкладка TwoWay: UserName локализуется до первой правки пользователем.
/// </summary>
public sealed class TwoWayTabViewModel : ViewModelBase
{
    private string _userName;
    private bool _userDirty;
    private double _volume = 40;

    public TwoWayTabViewModel()
    {
        _userName = AppServices.Localization.GetString(nameof(LocalizationBroker.TwoWayUserNameInitial));
        LocalizationBroker.Refreshed += OnLanguageRefreshed;
    }

    private void OnLanguageRefreshed(object? sender, EventArgs e)
    {
        if (_userDirty)
            return;

        _userName = AppServices.Localization.GetString(nameof(LocalizationBroker.TwoWayUserNameInitial));
        OnPropertyChanged(nameof(UserName));
    }

    public string UserName
    {
        get => _userName;
        set
        {
            if (SetProperty(ref _userName, value))
                _userDirty = true;
        }
    }

    public double Volume
    {
        get => _volume;
        set => SetProperty(ref _volume, value);
    }
}
