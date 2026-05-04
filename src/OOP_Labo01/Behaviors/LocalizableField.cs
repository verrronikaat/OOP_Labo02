using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using OOP_Labo01.Services;

namespace OOP_Labo01.Behaviors;

/// <summary>
/// Подсказки (ToolTip) всегда следуют языку. Текст поля синхронизируется с ресурсом по ключу,
/// пока пользователь его не менял — после правки смена языка содержимое не перезаписывается.
/// </summary>
public static class LocalizableField
{
    private static readonly ConditionalWeakTable<TextBox, FieldState> States = new();

    public static readonly DependencyProperty TextResourceKeyProperty = DependencyProperty.RegisterAttached(
        "TextResourceKey",
        typeof(string),
        typeof(LocalizableField),
        new PropertyMetadata(null, OnKeysChanged));

    public static readonly DependencyProperty HintResourceKeyProperty = DependencyProperty.RegisterAttached(
        "HintResourceKey",
        typeof(string),
        typeof(LocalizableField),
        new PropertyMetadata(null, OnKeysChanged));

    public static string? GetTextResourceKey(DependencyObject d) => (string?)d.GetValue(TextResourceKeyProperty);

    public static void SetTextResourceKey(DependencyObject d, string? v) => d.SetValue(TextResourceKeyProperty, v);

    public static string? GetHintResourceKey(DependencyObject d) => (string?)d.GetValue(HintResourceKeyProperty);

    public static void SetHintResourceKey(DependencyObject d, string? v) => d.SetValue(HintResourceKeyProperty, v);

    private static void OnKeysChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not TextBox tb)
            return;

        RoutedEventHandler? loaded = null;
        loaded = (_, _) =>
        {
            tb.Loaded -= loaded;
            var st = States.GetValue(tb, _ => new FieldState(tb));
            st.TextKey = GetTextResourceKey(tb);
            st.HintKey = GetHintResourceKey(tb);
            LocalizationBroker.Refreshed += st.OnRefresh;
            tb.Unloaded += st.OnUnloaded;
            tb.TextChanged += st.OnTextChanged;
            st.Apply();
        };
        tb.Loaded += loaded;
    }

    private sealed class FieldState
    {
        private readonly TextBox _tb;
        private bool _suppress;
        private bool _dirty;

        public FieldState(TextBox tb) => _tb = tb;

        public string? TextKey { get; set; }
        public string? HintKey { get; set; }

        public void OnUnloaded(object sender, RoutedEventArgs e)
        {
            LocalizationBroker.Refreshed -= OnRefresh;
            _tb.Unloaded -= OnUnloaded;
            _tb.TextChanged -= OnTextChanged;
        }

        public void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (_suppress)
                return;

            _dirty = true;
        }

        public void OnRefresh(object? sender, EventArgs e) => Apply();

        public void Apply()
        {
            if (HintKey is not null)
                _tb.ToolTip = LocalizationBroker.Instance.GetByKey(HintKey);

            if (TextKey is null)
                return;

            if (_dirty)
                return;

            var text = LocalizationBroker.Instance.GetByKey(TextKey);
            _suppress = true;
            try
            {
                _tb.Text = text;
            }
            finally
            {
                _suppress = false;
            }
        }
    }
}
