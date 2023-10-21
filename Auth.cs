namespace Logoalkolator;

public class Auth
{
    static bool isAuth = false;
    static public bool tryAuth()
    {
        if (tryLogin())
        {
            if (Logalkolator())
            {
                isAuth = true;
            }
        }
        return isAuth;
    }
    static bool tryLogin()
    {
        bool attemptLogin = false;
        return attemptLogin;
    }

    static bool Logalkolator()
    {
        bool sober = false;
        Random random = new Random();
        Console.Write("Próba trzeźwości! Podaj poprawny wynik:");
        // Calc.expressionToList();
        // Calc.ConvertToRPN();
        // Calc.CalculateRPN();
        return sober;
    }
}