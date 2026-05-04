using OOP_Labo01.Services;

namespace OOP_Labo01.ViewModels;

/// <summary>
/// Вкладка «режим Default»: DemoText подтягивает локализованный шаблон, пока пользователь не менял поле.
/// </summary>
public sealed class DefaultBindingTabViewModel : ViewModelBase
{
    private string _demoText;
    private bool _demoDirty;

    public DefaultBindingTabViewModel()
    {
        _demoText = AppServices.Localization.GetString(nameof(LocalizationBroker.DefaultDemoTextInitial));
        LocalizationBroker.Refreshed += OnLanguageRefreshed;
    }

    private void OnLanguageRefreshed(object? sender, EventArgs e)
    {
        if (_demoDirty)
            return;

        _demoText = AppServices.Localization.GetString(nameof(LocalizationBroker.DefaultDemoTextInitial));
        OnPropertyChanged(nameof(DemoText));
    }

    public string DemoText
    {
        get => _demoText;
        set
        {
            if (SetProperty(ref _demoText, value))
                _demoDirty = true;
        }
    }
}
