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
        bool attemptLogin = true;
        return attemptLogin;
    }

    static bool Logalkolator()
    {
        bool sober = false;
        Random random = new Random();
        Console.WriteLine("Próba trzeźwości! Oto zadanie:");
        string path = AppDomain.CurrentDomain.BaseDirectory;
        string exercise = "";
        using (StreamReader sr = File.OpenText(path+"examples.txt"))
        {
            int i = 0;
            List<string> Examp = new List<string>();
            while (sr.ReadLine() != null) {i++;Examp.Add(sr.ReadLine()??"");}
            exercise = Examp[random.Next(0, i)];
        }
        Console.Write(exercise+" = ");
        string userAnswer = Console.ReadLine() ?? "";
        string correctAnswer = Convert.ToString(Calc.CalculateRPN(Calc.ConvertToRPN(Calc.expressionToList(exercise))));
        Console.WriteLine($"\nPoprawna odpowiedź: {correctAnswer}\nTwoja odpowiedź: {userAnswer}");
        if(userAnswer == correctAnswer){Console.WriteLine("\nPrzyznano dostęp\n");sober = true;}
        else Console.WriteLine("Odmówiono dostępu\n");
        return sober;
    }
}