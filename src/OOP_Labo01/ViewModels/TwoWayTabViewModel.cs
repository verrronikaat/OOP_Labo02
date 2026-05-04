namespace OOP_Labo01.ViewModels;

/// <summary>
/// Вкладка TwoWay: изменения в UI синхронизируются с источником и наоборот.
/// </summary>
public sealed class TwoWayTabViewModel : ViewModelBase
{
    private string _userName = "Студент";
    private double _volume = 40;

    public string UserName
    {
        get => _userName;
        set => SetProperty(ref _userName, value);
    }

    /// <summary>Громкость 0..100 для Slider (TwoWay).</summary>
    public double Volume
    {
        get => _volume;
        set => SetProperty(ref _volume, value);
    }
}
