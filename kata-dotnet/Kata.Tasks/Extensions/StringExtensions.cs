namespace Kata.Tasks.Extensions;

/// <summary>
/// Методы расширения для String
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Первая буква - заглавная
    /// </summary>
    /// <param name="s">Строка</param>
    /// <code>
    /// string str = "string";
    /// string strFirstCharToUpper = str.FirstCharToUpper(); // "String"
    /// </code>
    /// <returns>Строка с заглавной буквы</returns>
    public static string FirstCharToUpper(this string s)
        => string.IsNullOrEmpty(s) ? string.Empty : $"{char.ToUpper(s[0])}{s[1..]}";
}
