using CS_Lab2;

class Program
{
    public static void Main(string[] args)
    {
        string output = "C:\\Users\\klyzh\\source\\repos\\CS_Lab1\\CS_Lab2\\Files\\PursuitLog.txt";
        string input = "";
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
        Game game = new Game(input,output);
        game.Run();
    }
}