namespace syntactic_analyzer;

/// <summary>
/// Статический класс, предоставляющий методы для вычисления арифметических выражений в постфиксной записи.
/// </summary>
public static class Evaluator
{
    /// <summary>
    /// Выполняет вычисление арифметического выражения, представленного в виде списка токенов в постфиксной записи.
    /// </summary>
    /// <param name="postfixTokens">Список токенов в постфиксной записи.</param>
    /// <returns>Результат вычисления арифметического выражения.</returns>
    public static double Evaluate(List<Token> postfixTokens)
    {
        Stack<Token> evalStack = new Stack<Token>();

        foreach (Token curToken in postfixTokens)
        {
            if (curToken.Type == TokenType.Number)
            {
                evalStack.Push(curToken);
            }
            else if (curToken.Type == TokenType.Operator)
            {
                char operatorSymbol = (char)curToken.Value;
                Token number2 = evalStack.Pop();
                Token number1 = evalStack.Pop();
                double result = OperatorUtil.GetOperator(operatorSymbol).Operation
                    .Invoke((double)number1.Value, (double)number2.Value);
                evalStack.Push(new Token(result, TokenType.Number));
            }
        }

        if (evalStack.Count != 1)
        {
            throw new Exception("Недопустимое выражение");
        }

        return (double)evalStack.Pop().Value;
    }
}