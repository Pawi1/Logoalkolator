namespace Logoalkolator;
class Program
{
    static void Main()
    {
        if (Auth.tryAuth()) Calc.Calculator();
    }
}