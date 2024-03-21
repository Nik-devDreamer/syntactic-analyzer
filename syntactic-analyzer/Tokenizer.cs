namespace syntactic_analyzer;

/// <summary>
/// Статический класс, предоставляющий методы для токенизации арифметических выражений.
/// </summary>
public static class Tokenizer
{
    /// <summary>
    /// Метод для разделения арифметического выражения на токены.
    /// </summary>
    /// <param name="expression">Строковое представление арифметического выражения.</param>
    /// <returns>Список токенов, представляющих арифметическое выражение.</returns>
    public static List<Token> Tokenize(string? expression)
    {
        List<Token> tokens = new List<Token>();
        int position = 0;
        while (position < expression.Length)
        {
            char currentChar = expression[position];
            if (char.IsDigit(currentChar))
            {
                int start = position;
                while (position < expression.Length &&
                       (char.IsDigit(expression[position]) || expression[position] == '.'))
                {
                    position++;
                }

                string numberStr = expression.Substring(start, position - start);
                double number = double.Parse(numberStr);
                tokens.Add(new Token(number, TokenType.Number));
            }
            else if (Symbols.Parts.Contains(currentChar))
            {
                tokens.Add(new Token(currentChar, TokenType.Operator));
                position++;
            }
            else if (char.IsWhiteSpace(currentChar))
            {
                position++;
            }
            else
            {
                throw new Exception("Недопустимый символ: " + currentChar);
            }
        }

        return tokens;
    }

    /// <summary>
    /// Метод для преобразования списка токенов в постфиксную запись.
    /// </summary>
    /// <param name="tokens">Список токенов арифметического выражения.</param>
    /// <returns>Список токенов в постфиксной записи.</returns>
    public static List<Token> TransformToPostFix(List<Token> tokens)
    {
        Stack<Token> operators = new Stack<Token>();
        List<Token> postfixTokens = new List<Token>();

        foreach (Token curToken in tokens)
        {
            if (curToken.Type == TokenType.Number)
            {
                postfixTokens.Add(curToken);
            }
            else if (curToken.Type == TokenType.Operator)
            {
                char operatorSymbol = (char)curToken.Value;
                if (operatorSymbol == '(')
                {
                    operators.Push(curToken);
                }
                else if (operatorSymbol == ')')
                {
                    while (operators.Any() && (char)operators.Peek().Value != '(')
                    {
                        postfixTokens.Add(operators.Pop());
                    }

                    if (!operators.Any() || (char)operators.Peek().Value != '(')
                    {
                        throw new Exception("Несоответствие скобок");
                    }

                    operators.Pop();
                }
                else
                {
                    while (operators.Any() && (char)operators.Peek().Value != '(' &&
                           (OperatorUtil.HasGreaterPrecedence((char)operators.Peek().Value, operatorSymbol) ||
                            (OperatorUtil.HasEqualPrecedence((char)operators.Peek().Value, operatorSymbol) &&
                             OperatorUtil.GetOperator((char)operators.Peek().Value).OperatorAssociativity ==
                             Operator.Associativity.Left)))
                    {
                        postfixTokens.Add(operators.Pop());
                    }

                    operators.Push(curToken);
                }
            }
        }

        while (operators.Any())
        {
            if ((char)operators.Peek().Value == '(' || (char)operators.Peek().Value == ')')
            {
                throw new Exception("Несоответствие скобок");
            }

            postfixTokens.Add(operators.Pop());
        }

        return postfixTokens;
    }
}