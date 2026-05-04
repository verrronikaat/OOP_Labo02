namespace OOP_Labo01.Models;

/// <summary>
/// Простая модель-сообщение (пример слоя Model для отчёта и демонстрации разделения).
/// </summary>
public sealed class DemoMessage
{
    public DemoMessage(string text) => Text = text;

    /// <summary>Текст сообщения.</summary>
    public string Text { get; set; }
}
