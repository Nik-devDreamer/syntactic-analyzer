namespace syntactic_analyzer;

/// <summary>
/// Класс, представляющий калькулятор для вычисления арифметических выражений.
/// </summary>
public class Calculator
{
    /// <summary>
    /// Метод для вычисления значения арифметического выражения.
    /// </summary>
    /// <param name="expression">Арифметическое выражение в виде строки.</param>
    /// <returns>Результат вычисления арифметического выражения.</returns>
    public double EvaluateExpression(string? expression)
    {
        // Разбиваем арифметическое выражение на токены
        List<Token> tokens = Tokenizer.Tokenize(expression);
        
        // Преобразуем полученные токены в постфиксную запись
        List<Token> postfixTokens = Tokenizer.TransformToPostFix(tokens);
        
        // Вычисляем значение арифметического выражения в постфиксной записи
        return Evaluator.Evaluate(postfixTokens);
    }
}