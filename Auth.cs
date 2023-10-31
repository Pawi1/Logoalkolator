using System.Globalization;
namespace Logoalkolator;
public class Auth
{
    static bool isAuth;
    static bool isSober;
    static bool isCorrectLogin;
    static string path = AppDomain.CurrentDomain.BaseDirectory;

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
        List<string> Users = new List<string>();
        List<string> Passwords = new List<string>();
        using (StreamReader sr = new StreamReader(path + "db.txt"))
        {
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine() ?? "";
                string[] Temp = s.Split(";");
                Users.Add(Temp[0]);
                Passwords.Add(Temp[1]);
            }
        }

        for (int j = 0; j < 10; j++)
        {
            Console.WriteLine("\tAutoryzacja");
            Console.Write("Login: ");
            string userLogin = Console.ReadLine() ?? "";
            Console.Write("Hasło: ");
            string userPassword = Console.ReadLine() ?? "";
            for (int i = 0; i < Users.Count; i++)
            {
                if (userLogin == Users[i] && userPassword == Passwords[i])
                {
                    Console.Write("Zostały podane poprawne dane, możesz się zalogować");
                    isCorrectLogin = true;
                    break;
                }
            }

            if (!isCorrectLogin) Console.Write($"Podanie dane są niepropawne, pozostało {10 - j - 1} prób ...");
            Thread.Sleep(2000);
            Console.Clear();
            if (isCorrectLogin) break;
        }

        return isCorrectLogin;
    }
    static bool Logalkolator()
    {
        for (int j = 0; j < 2; j++)
        {
            Random random = new Random();
            Console.WriteLine("\tPróba trzeźwości! Oto zadanie:");
            string exercise;
            using (StreamReader sr = new StreamReader(path + "examples.txt"))
            {
                int i = 0;
                List<string> Examp = new List<string>();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine() ?? "";
                    i++;
                    Examp.Add(line);
                }

                exercise = Examp[random.Next(0, i)];
            }
            Console.Write(exercise + " = ");
            string userAnswer = Console.ReadLine() ?? "";
            string correctAnswer =
                Convert.ToString(Calc.CalculateRPN(Calc.ConvertToRPN(Calc.expressionToList(exercise))),
                    CultureInfo.CurrentCulture);
            Console.WriteLine($"Poprawna odpowiedź: {correctAnswer}\nTwoja odpowiedź: {userAnswer}");
            if (userAnswer == correctAnswer)
            {
                Console.Write("Przyznano dostęp");
                isSober = true;
                Thread.Sleep(2000);
                Console.Clear();
                break;
            }
            else if (j == 0) Console.Write($"Odmówiono dostępu, masz jeszcze drugą szanse ...");
            else Console.Write($"Odmówiono dostępu, program wyłączy się ...");
            Thread.Sleep(2000);
            Console.Clear();
        }
            return isSober;
    } 
}