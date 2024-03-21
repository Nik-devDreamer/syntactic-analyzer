namespace syntactic_analyzer;

/// <summary>
/// Класс, предоставляющий символы для анализа арифметических выражений.
/// </summary>
public class Symbols
{
    private static readonly HashSet<char> Grouping = new HashSet<char>(new char[] { '(', ')' });
    private static readonly HashSet<char> BiOperators = new HashSet<char>(new char[] { '+', '-', '*', ':', '/', '^', '%' });
    public static readonly HashSet<char> Parts = new HashSet<char>(Grouping.Union(BiOperators));
}