namespace syntactic_analyzer;

/// <summary>
/// Класс представляет токен арифметического выражения.
/// </summary>
public class Token
{
    public object Value { get; }
    public TokenType Type { get; }

    public Token(object value, TokenType type)
    {
        Value = value;
        Type = type;
    }

    /// <summary>
    /// Переопределение метода ToString() для представления токена в виде строки.
    /// </summary>
    /// <returns>Строковое представление токена.</returns>
    public override string? ToString()
    {
        return Value.ToString();
    }
}