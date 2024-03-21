namespace syntactic_analyzer;

/// <summary>
/// Класс содержит точку входа в приложение.
/// </summary>
class Program
{
    /// <summary>
    /// Метод Main - точка входа в приложение.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    static void Main(string[] args)
    {
        Console.WriteLine("Введите арифметическое выражение:");
        string? expression = Console.ReadLine();

        try
        {
            var calculator = new Calculator();
            double result = calculator.EvaluateExpression(expression);
            Console.WriteLine("Результат: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        Console.WriteLine("Нажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}