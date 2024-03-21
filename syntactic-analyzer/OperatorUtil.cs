namespace syntactic_analyzer;

/// <summary>
/// Статический класс, предоставляющий утилиты для работы с операторами.
/// </summary>
public static class OperatorUtil
{
    private static readonly Dictionary<char, Operator> Operators = new Dictionary<char, Operator>
    {
        { '+', new Operator('+', Operator.Associativity.Left, (a, b) => a + b) },
        { '-', new Operator('-', Operator.Associativity.Left, (a, b) => a - b) },
        { '*', new Operator('*', Operator.Associativity.Left, (a, b) => a * b) },
        { '/', new Operator('/', Operator.Associativity.Left, (a, b) => a / b) },
        { '%', new Operator('%', Operator.Associativity.Left, (a, b) => a % b) },
        { '^', new Operator('^', Operator.Associativity.Right, Math.Pow) }
    };

    /// <summary>
    /// Метод для получения оператора по его символу.
    /// </summary>
    /// <param name="symbol">Символ оператора.</param>
    /// <returns>Объект оператора, соответствующий указанному символу.</returns>
    public static Operator GetOperator(char symbol)
    {
        if (Operators.ContainsKey(symbol))
            return Operators[symbol];
        throw new Exception("Оператор не найден: " + symbol);
    }

    /// <summary>
    /// Метод для определения, имеет ли оператор op1 больший приоритет, чем оператор op2.
    /// </summary>
    /// <param name="op1">Символ первого оператора.</param>
    /// <param name="op2">Символ второго оператора.</param>
    /// <returns>True, если оператор op1 имеет больший приоритет, иначе false.</returns>
    public static bool HasGreaterPrecedence(char op1, char op2)
    {
        return GetOperator(op1).OperatorAssociativity == Operator.Associativity.Left && GetOperator(op1).Symbol != '^'
            && GetOperator(op1).OperatorAssociativity != Operator.Associativity.Left;
    }

    /// <summary>
    /// Метод для определения, имеет ли оператор op1 равный приоритет с оператором op2.
    /// </summary>
    /// <param name="op1">Символ первого оператора.</param>
    /// <param name="op2">Символ второго оператора.</param>
    /// <returns>True, если операторы имеют равный приоритет, иначе false.</returns>
    public static bool HasEqualPrecedence(char op1, char op2)
    {
        return GetOperator(op1).OperatorAssociativity == Operator.Associativity.Left && GetOperator(op1).Symbol == '^'
            && GetOperator(op1).OperatorAssociativity != Operator.Associativity.Left;
    }
}