using System.Globalization;
using OOP_Labo01.Commands;
using OOP_Labo01.Services;

namespace OOP_Labo01.ViewModels;

/// <summary>
/// Вкладка OneTime: стартовые строки из ресурсов; формат смены FrozenLabel — тоже из ресурса.
/// </summary>
public sealed class OneTimeTabViewModel : ViewModelBase
{
    private string _frozenLabel;
    private string _editableVmField;

    public OneTimeTabViewModel()
    {
        _frozenLabel = AppServices.Localization.GetString(nameof(LocalizationBroker.OneTimeFrozenInitial));
        _editableVmField = AppServices.Localization.GetString(nameof(LocalizationBroker.OneTimeEditableHint));
        BumpFrozenCommand = new RelayCommand(() =>
        {
            var fmt = AppServices.Localization.GetString(nameof(LocalizationBroker.OneTimeBumpFormat));
            FrozenLabel = string.Format(CultureInfo.CurrentCulture, fmt, DateTime.Now);
        });
    }

    public string FrozenLabel
    {
        get => _frozenLabel;
        set => SetProperty(ref _frozenLabel, value);
    }

    public string EditableVmField
    {
        get => _editableVmField;
        set => SetProperty(ref _editableVmField, value);
    }

    public RelayCommand BumpFrozenCommand { get; }
}
