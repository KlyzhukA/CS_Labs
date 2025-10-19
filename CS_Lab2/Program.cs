using CS_Lab2;

class Program
{
   static public (int,char) Test1(string str)
    {
        int count = 0;
        char currentChar = ' ';
        //asdsdDFDsdfds
        foreach(char c in str)
        {
            if (char.IsAsciiLetterUpper(c))
            {
                currentChar = c;
                break;
            }
        }
        foreach (char b in str)
        {
            if (b == currentChar)
            {
                count++;
            }
        }
        return (count, currentChar);
    }
    public static void Main(string[] args)
    {
        NewPlayer tom = new NewPlayer(10, "Tom");
        NewPlayer bob = new NewPlayer(10, "Bob");
        NewPlayer alex = new NewPlayer(10, "Alex");
        NewPlayer[] players = { bob, alex, tom };
        Array.Sort(players);
        foreach(NewPlayer a in players)
        {
            Console.WriteLine(a.name);
        }
        (int, char) cortezhTest;
        cortezhTest = Test1("asdasdGfGGGHI");
        string output = "C:\\Users\\klyzh\\source\\repos\\CS_Lab1\\CS_Lab2\\Files\\PursuitLog.txt";
        string input = "";
        try
        {
            Console.WriteLine("Выберите файл:\n" +
                "1 1.ChaseData\n" +
                "2 2.ChaseData\n" +
                "3 3.ChaseData");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    input = "C:\\Users\\klyzh\\source\\repos\\CS_Lab1\\CS_Lab2\\Files\\1.ChaseData.txt";
                    break;
                case 2:
                    input = "C:\\Users\\klyzh\\source\\repos\\CS_Lab1\\CS_Lab2\\Files\\2.ChaseData.txt";
                    break;
                case 3:
                    input = "C:\\Users\\klyzh\\source\\repos\\CS_Lab1\\CS_Lab2\\Files\\3.ChaseData.txt";
                    break;

            }
            Game game = new Game(input, output);
            game.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}