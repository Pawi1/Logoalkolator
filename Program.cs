namespace Logoalkolator;
class Program
{
    static void Main()
    {
        Console.Clear();
        if (Auth.tryAuth()) Calc.Calculator();
    }
}