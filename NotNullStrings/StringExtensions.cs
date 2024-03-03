// ReSharper disable UnusedMember.Global

namespace NotNullStrings;

public static class StringExtensions
{
    /// <summary>
    ///     Joins an enumerable into a string by calling ToString on each of then
    /// </summary>
    /// <remarks> The default separator is a comma</remarks>
    public static string JoinString<T>(this IEnumerable<T> items, string separator = ",")
        => string.Join(separator, items);


    /// <summary>
    ///     Joins an enumerable into a string by calling function  on each of then
    /// </summary>
    public static string JoinString<T>(this IEnumerable<T> items, string separator, Func<T, string> converter)
        => string.Join(separator, items.Select(converter));

    /// <summary>
    ///     Joins a set of things into a single string by calling ToString and separating with newlines
    /// </summary>
    public static string JoinAsLines<T>(this IEnumerable<T> items) => items.JoinString(Environment.NewLine);

    /// <summary>
    ///     Splits string into array of non-empty tokens separated by any of the characters in separationChars
    /// </summary>
    public static string[] Tokenize(this string? input, string separationCharacters)
    {
        return input == null
            ? []
            : input.Split(separationCharacters.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim())
                .Where(t => t.Length != 0)
                .ToArray();
    }

    /// <summary>
    ///     Tokenizes all strings in input into a single array by splitting at any of separationCharacters
    /// </summary>
    public static string[] Tokenize(this IEnumerable<string> input, string separationCharacters)
        => input.SelectMany(s => s.Tokenize(separationCharacters)).ToArray();

    /// <summary>
    ///     Splits string into array of non-empty tokens separated by space
    /// </summary>
    public static string[] Tokenize(this string input) => input.Tokenize(" \t");

    public static bool IsBlank(this string s) => string.IsNullOrWhiteSpace(s);
    public static bool IsNotBlank(this string s) => !s.IsBlank();

    /// <summary>
    ///     Replaces the string with an alternative value if the original is blank
    /// </summary>
    public static string OrWhenBlank(this string s, string fallback)
        => s.IsBlank()
            ? fallback
            : s;


    public static string NullToEmpty(this string? s)
        => s ?? string.Empty;
}