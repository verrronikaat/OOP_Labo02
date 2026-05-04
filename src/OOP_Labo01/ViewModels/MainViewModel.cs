using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using OOP_Labo01.Commands;
using OOP_Labo01.Services;

namespace OOP_Labo01.ViewModels;

/// <summary>
/// Главное окно: язык, команда «О программе» (MessageBox из ресурсов).
/// </summary>
public sealed class MainViewModel : ViewModelBase
{
    private string _uiCultureTag = "ru-RU";

    public MainViewModel()
    {
        Languages = new ObservableCollection<CultureItem>
        {
            new("ru-RU"),
            new("en-US"),
        };

        AboutCommand = new RelayCommand(_ =>
        {
            MessageBox.Show(
                LocalizationBroker.Instance.AboutBody,
                LocalizationBroker.Instance.AboutTitle,
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        });
    }

    public ObservableCollection<CultureItem> Languages { get; }

    /// <summary>Тег культуры для ComboBox (ru-RU / en-US).</summary>
    public string UiCultureTag
    {
        get => _uiCultureTag;
        set
        {
            if (!SetProperty(ref _uiCultureTag, value))
                return;

            AppServices.Localization.SetCulture(CultureInfo.GetCultureInfo(value));
        }
    }

    public RelayCommand AboutCommand { get; }
}
