using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OOP_Labo01.ViewModels;

/// <summary>
/// Базовый класс ViewModel: уведомление UI об изменении свойств (интерфейс INotifyPropertyChanged).
/// </summary>
public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Вызвать событие изменения свойства (для обновления привязок OneWay/TwoWay).
    /// </summary>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    /// <summary>
    /// Установить поле и при необходимости уведомить об изменении.
    /// </summary>
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}
