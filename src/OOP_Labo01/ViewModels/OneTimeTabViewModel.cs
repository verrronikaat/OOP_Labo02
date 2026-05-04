using OOP_Labo01.Commands;

namespace OOP_Labo01.ViewModels;

/// <summary>
/// Вкладка OneTime: значение передаётся из источника к цели один раз (при первом отображении/смене контекста).
/// </summary>
public sealed class OneTimeTabViewModel : ViewModelBase
{
    private string _frozenLabel = "Стартовое значение для OneTime";
    private string _editableVmField = "Можно менять в VM кнопкой — OneTime-поле не обновится само";

    public OneTimeTabViewModel()
    {
        BumpFrozenCommand = new RelayCommand(() =>
        {
            FrozenLabel = $"Новое значение из VM ({DateTime.Now:HH:mm:ss})";
        });
    }

    /// <summary>Подпись с привязкой OneTime (не «следует» за дальнейшими изменениями свойства так же, как TwoWay).</summary>
    public string FrozenLabel
    {
        get => _frozenLabel;
        set => SetProperty(ref _frozenLabel, value);
    }

    /// <summary>Вспомогательное поле для пояснения в интерфейсе.</summary>
    public string EditableVmField
    {
        get => _editableVmField;
        set => SetProperty(ref _editableVmField, value);
    }

    /// <summary>Команда: меняет свойство в VM, чтобы увидеть, что OneTime не обновляет цель повторно.</summary>
    public RelayCommand BumpFrozenCommand { get; }
}
