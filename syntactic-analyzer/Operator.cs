namespace syntactic_analyzer;

/// <summary>
/// Класс, представляющий оператор арифметического выражения.
/// </summary>
public class Operator
{
    public char Symbol { get; }
    public Associativity OperatorAssociativity { get; }
    public Func<double, double, double> Operation { get; }

    public Operator(char symbol, Associativity associativity, Func<double, double, double> operation)
    {
        Symbol = symbol;
        OperatorAssociativity = associativity;
        Operation = operation;
    }

    public enum Associativity
    {
        Left,
        Right
    }
}