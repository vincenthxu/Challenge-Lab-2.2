using System.Text;

namespace Challenge_Lab_2._2
{
    internal class Program
    {
        static private int attempts = 0;
        static Dictionary<string, string> db = new()
        {
            { "admin", "admin" },
            { "root", "root" },
            { "user", "password" },
        };
        static void Main(string[] args)
        {
            String? user = null;
            String? pass = null;
            while(attempts < 3)
            {
                while (user == null)
                {
                    Console.Write("username: ");
                    user = Console.ReadLine();
                }

                Console.Write("password: ");

                StringBuilder userPasswordInput = new StringBuilder();
                ConsoleKeyInfo consoleKeyInfo;
                bool getUserPassword = true;
                while(getUserPassword)
                {
                    consoleKeyInfo = Console.ReadKey(true);
                    if (consoleKeyInfo.KeyChar != 13)
                    {
                        userPasswordInput.Append(consoleKeyInfo.KeyChar);
                    }
                    else
                    {
                        getUserPassword = false;
                    }
                }

                pass = userPasswordInput.ToString();

                Console.Clear();

                if (db.ContainsKey(user) && db[user] == pass)
                {
                    Console.WriteLine("Login successful");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid password");
                    user = null;
                    pass = null;
                    attempts++;
                }
            }
            if (attempts == 3)
            {
                Console.WriteLine("Too many invalid attempts");
            }
        }
    }
}
