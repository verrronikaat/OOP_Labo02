using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace OOP_Labo01.Services;

/// <summary>
/// Обёртка над <see cref="ILocalizationProvider"/> для привязок WPF (INotifyPropertyChanged).
/// </summary>
public sealed class LocalizationBroker : INotifyPropertyChanged
{
    private readonly ILocalizationProvider _provider;

    private LocalizationBroker(ILocalizationProvider provider)
    {
        _provider = provider;
        provider.CultureChanged += (_, _) => Refresh();
    }

    public static LocalizationBroker Instance { get; private set; } = null!;

    public static void Initialize(ILocalizationProvider provider)
    {
        Instance = new LocalizationBroker(provider);
    }

    public ILocalizationProvider Provider => _provider;

    public string GetByKey(string key) => _provider.GetString(key);

    public static event EventHandler? Refreshed;

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? name = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public void Refresh()
    {
        foreach (var p in GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            if (p.PropertyType == typeof(string))
                OnPropertyChanged(p.Name);
        }

        Refreshed?.Invoke(this, EventArgs.Empty);
    }

    public string WindowTitle => _provider.GetString(nameof(WindowTitle));
    public string TabDefault => _provider.GetString(nameof(TabDefault));
    public string TabTwoWay => _provider.GetString(nameof(TabTwoWay));
    public string TabOneTime => _provider.GetString(nameof(TabOneTime));
    public string TabOneWay => _provider.GetString(nameof(TabOneWay));
    public string TabTriggers => _provider.GetString(nameof(TabTriggers));
    public string LanguagePrompt => _provider.GetString(nameof(LanguagePrompt));
    public string AboutMenu => _provider.GetString(nameof(AboutMenu));
    public string AboutTitle => _provider.GetString(nameof(AboutTitle));
    public string AboutBody => _provider.GetString(nameof(AboutBody));
    public string DefaultSectionTitle => _provider.GetString(nameof(DefaultSectionTitle));
    public string DefaultSectionSubtitle => _provider.GetString(nameof(DefaultSectionSubtitle));
    public string DefaultGroupDirectHeader => _provider.GetString(nameof(DefaultGroupDirectHeader));
    public string DefaultDirectDescription => _provider.GetString(nameof(DefaultDirectDescription));
    public string DefaultTwoBoxesDescription => _provider.GetString(nameof(DefaultTwoBoxesDescription));
    public string DefaultLeftBoxText => _provider.GetString(nameof(DefaultLeftBoxText));
    public string DefaultLeftBoxHint => _provider.GetString(nameof(DefaultLeftBoxHint));
    public string DefaultLeftMirrorHint => _provider.GetString(nameof(DefaultLeftMirrorHint));
    public string DefaultGroupVmHeader => _provider.GetString(nameof(DefaultGroupVmHeader));
    public string DefaultVmDescription => _provider.GetString(nameof(DefaultVmDescription));
    public string DefaultDemoTextInitial => _provider.GetString(nameof(DefaultDemoTextInitial));
    public string DefaultCaptionText => _provider.GetString(nameof(DefaultCaptionText));
    public string TwoWaySectionTitle => _provider.GetString(nameof(TwoWaySectionTitle));
    public string TwoWayGroupDirectHeader => _provider.GetString(nameof(TwoWayGroupDirectHeader));
    public string TwoWayDirectDescription => _provider.GetString(nameof(TwoWayDirectDescription));
    public string TwoWaySourceText => _provider.GetString(nameof(TwoWaySourceText));
    public string TwoWaySourceHint => _provider.GetString(nameof(TwoWaySourceHint));
    public string TwoWaySliderCaptionPrefix => _provider.GetString(nameof(TwoWaySliderCaptionPrefix));
    public string TwoWayGroupVmHeader => _provider.GetString(nameof(TwoWayGroupVmHeader));
    public string TwoWayVmDescription => _provider.GetString(nameof(TwoWayVmDescription));
    public string TwoWayUserNameInitial => _provider.GetString(nameof(TwoWayUserNameInitial));
    public string TwoWayVolumeCaptionPrefix => _provider.GetString(nameof(TwoWayVolumeCaptionPrefix));
    public string OneTimeSectionTitle => _provider.GetString(nameof(OneTimeSectionTitle));
    public string OneTimeGroupDirectHeader => _provider.GetString(nameof(OneTimeGroupDirectHeader));
    public string OneTimeDirectDescription => _provider.GetString(nameof(OneTimeDirectDescription));
    public string OneTimeSeedText => _provider.GetString(nameof(OneTimeSeedText));
    public string OneTimeSeedHint => _provider.GetString(nameof(OneTimeSeedHint));
    public string OneTimeGroupVmHeader => _provider.GetString(nameof(OneTimeGroupVmHeader));
    public string OneTimeVmDescription => _provider.GetString(nameof(OneTimeVmDescription));
    public string OneTimeFrozenInitial => _provider.GetString(nameof(OneTimeFrozenInitial));
    public string OneTimeEditableHint => _provider.GetString(nameof(OneTimeEditableHint));
    public string OneTimeChangeFrozenButton => _provider.GetString(nameof(OneTimeChangeFrozenButton));
    public string OneTimeBumpFormat => _provider.GetString(nameof(OneTimeBumpFormat));
    public string OneWaySectionTitle => _provider.GetString(nameof(OneWaySectionTitle));
    public string OneWayGroupDirectHeader => _provider.GetString(nameof(OneWayGroupDirectHeader));
    public string OneWayDirectDescription => _provider.GetString(nameof(OneWayDirectDescription));
    public string OneWayValuePrefix => _provider.GetString(nameof(OneWayValuePrefix));
    public string OneWayMirrorCheckbox => _provider.GetString(nameof(OneWayMirrorCheckbox));
    public string OneWayGroupVmHeader => _provider.GetString(nameof(OneWayGroupVmHeader));
    public string OneWayVmDescription => _provider.GetString(nameof(OneWayVmDescription));
    public string OneWayBusyCheckbox => _provider.GetString(nameof(OneWayBusyCheckbox));
    public string OneWayRefreshButton => _provider.GetString(nameof(OneWayRefreshButton));
    public string TriggersSectionTitle => _provider.GetString(nameof(TriggersSectionTitle));
    public string TriggersDataDescription => _provider.GetString(nameof(TriggersDataDescription));
    public string TriggersToggleAlert => _provider.GetString(nameof(TriggersToggleAlert));
    public string TriggersHoverDescription => _provider.GetString(nameof(TriggersHoverDescription));
    public string TriggersAnimateButton => _provider.GetString(nameof(TriggersAnimateButton));
    public string TriggersClickPrefix => _provider.GetString(nameof(TriggersClickPrefix));
    public string StatusReady => _provider.GetString(nameof(StatusReady));
    public string StatusWaiting => _provider.GetString(nameof(StatusWaiting));
    public string LangRussian => _provider.GetString(nameof(LangRussian));
    public string LangEnglish => _provider.GetString(nameof(LangEnglish));
}
