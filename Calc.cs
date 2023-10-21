namespace Logoalkolator;
class Calc
{
    public static void Calculator()
    { 
        Console.WriteLine("\t\tLogoalkolator: Kalkulator\nDozwolone znaki: liczby, nawiasy [(], [)], dodawania [+], odejmowania [-], dzielenia [/], mnożenia [*]\n\tUWAGA!\tKalkulator nie obsługuje liczb ujemnych [zamiast -5 napisz (5-10) albo (5-5*2)]\n\tUWAGA!\tPrzy ułamkach dziesiętnych użyj [,] albo [.] w zależności od systemu i regionu");
        while (!false)
        {
            Console.Write("Wprowadź wyrażenie (lub pusty aby zakończyć): ");
            string expression = Console.ReadLine()??"";
            expression = expression.Replace(" ", "");
            if (expression == "") break;
            try
            {
                List<string> clearExpression = expressionToList(expression);
                List<string> RPNExpression = ConvertToRPN(clearExpression);
                double result = CalculateRPN(RPNExpression);
                Console.WriteLine($"Wynik:\t{result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd:\t{ex.Message}");
            }
        }
    }
    public static List<string> expressionToList(string expression)
    {
        List<string> Tokens = new List<string>();
        if (IsOperator(Convert.ToString(expression[0])) || IsOperator(Convert.ToString(expression[^1])) ) throw new Exception("Obliczenie nie zaczyna/kończy się liczbą, nawiasem");
        for (int i = 0;i<expression.Length;i++)
        {
            if(expression[i] == '.' || expression[i] == ',')
            {
                string numb = Tokens[^1]+expression[i];
                int j = i+1;
                for (; j < expression.Length; j++)
                {
                    if (!IsDigit(Convert.ToString(expression[j]))) break;
                    else
                    {
                        numb += Convert.ToString(expression[j]);
                    }
                }
                i = j - 1;
                Tokens.RemoveAt(Tokens.Count-1);
                Tokens.Add(numb);
            }
            else
            if (IsBracket(Convert.ToString(expression[i])) || IsOperator(Convert.ToString(expression[i]))) Tokens.Add(Convert.ToString(expression[i]));
            else if (IsDigit(Convert.ToString(expression[i])))
            {
                string numb = "";
                int j = i;
                for (; j < expression.Length; j++)
                {
                    if (!IsDigit(Convert.ToString(expression[j]))) break;
                    else
                    {
                        numb += Convert.ToString(expression[j]);
                    }
                }
                i = j - 1;
                Tokens.Add(numb);
            }
            else throw new Exception("W obliczeniu występuje nieprawidłowy znak");
        }
        Console.Write("DEBUG:\t");
        foreach (var Token in Tokens)
        {
            Console.Write("["+Token+"] ");
        }
        Console.WriteLine();
        return Tokens;
    }
    public static List<string> ConvertToRPN(List<string> inputExpression)
    {
        List<string> output = new List<string>();
        Stack<string> operatorStack = new Stack<string>();

        foreach (string token in inputExpression)
        {
            if (IsNumeric(token)) output.Add(token);
            else if (IsOperator(token))
            {
                while (operatorStack.Count > 0 && IsOperator(operatorStack.Peek()) && GetPrecedence(token) <= GetPrecedence(operatorStack.Peek())) output.Add(operatorStack.Pop());
                operatorStack.Push(token);
            }
            else if (token == "(") operatorStack.Push(token);
            else if (token == ")")
            {
                while (operatorStack.Count > 0 && operatorStack.Peek() != "(") output.Add(operatorStack.Pop());
                operatorStack.Pop();
            }
        }
        while (operatorStack.Count > 0) output.Add(operatorStack.Pop());
        Console.Write("ONP:\t");
        foreach (var i in output)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine();
        return output;
    }
    public static double CalculateRPN(List<string> expression)
    {
        Stack<double> stack = new Stack<double>();

        foreach (string token in expression)
        {
            if (double.TryParse(token, out double operand)) stack.Push(operand);
            else
            {
                double operand2 = stack.Pop();
                double operand1 = stack.Pop();
                if (token == "+") stack.Push(operand1 + operand2);
                if (token == "-") stack.Push(operand1 - operand2);
                if (token == "*") stack.Push(operand1 * operand2);
                if (token == "/") stack.Push(operand1 / operand2);
            }
        }
        return stack.Pop();
    }
    static int GetPrecedence(string op)
    {
        if(op == "+" || op == "-") return 1;
        else if(op=="*" || op == "/") return 2;
        else return 0;
    }
    static bool IsNumeric(string str)
    { 
        return double.TryParse(str, out _);
    }
    static bool IsOperator(string token)
    {
        return token == "+" || token == "-" || token == "*" || token == "/";
    }
    static bool IsBracket(string token)
    {
        return token == ")" || token == "(";
    }
    static bool IsDigit(string token)
    {
        return token == "0" || 
               token == "1" || token == "2" || token == "3" ||
               token == "4" || token == "5" || token == "6" || 
               token == "7" || token == "8" || token == "9";
    }
}