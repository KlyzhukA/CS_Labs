using CS_Lab3;
using System.Text;

class Program
{
    private static void Main(string[] args)
    {
        string testText = "";
        string path = "C:\\Users\\Admin\\source\\repos\\KlyzhukA\\CS_Labs\\CS_Lab3\\Files\\task.txt";
        using (StreamReader sr = new StreamReader("C:\\Users\\Admin\\source\\repos\\KlyzhukA\\CS_Labs\\CS_Lab3\\Files\\Text.txt"))
        {
            testText = sr.ReadToEnd();
            Console.WriteLine(testText);
        }
        Text text = TextParser.Parse(testText);
        Console.WriteLine("Выберите пункт меню: \n" +
            "1. Вывести предложения в порядке возрастания количества слов в предложениях.\n" +
            "2. Вывести предложения в порядке возрастания длины предложения.\n" +
            "3. Во всех вопросительных предложениях текста найти слова заданной длины\n" +
            "4. Удалить из текста все слова заданной длины, начинающиеся с согласной буквы\n" +
            "5. В некотором предложении текста заменить слова заданной длины на указанную подстроку\n" +
            "6. Удалить стоп-слова\n" +
            "7. Текущий вид текста");
        int choice = Convert.ToInt32(Console.ReadLine());
        while (true) {
            switch (choice)
            {
                case 1:
                    TextProcessor.PrintByWordsCount(text, path);
                    break;
                case 2:
                    TextProcessor.PrintBySentenceLength(text, path);
                    break;
                case 3:
                    Console.WriteLine("Введите длину");
                    int n1 = Convert.ToInt32(Console.ReadLine());
                    TextProcessor.FindWordsInQuastions(text, n1);
                    break;
                case 4:
                    Console.WriteLine("Введите длину");
                    int n2 = Convert.ToInt32(Console.ReadLine());
                    TextProcessor.DeleteWords(text, n2);
                    break;
                case 5:
                    Console.WriteLine("Введите номер предложения");
                    int index = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите длину слова");
                    int n3 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите подстроку");
                    string str = Console.ReadLine();
                    TextProcessor.ReplaceWords(text, index, str, n3);
                    break;
                case 6:
                    Console.WriteLine("Выберите:\n" +
                        "1. Русские стоп-слова\n" +
                        "2. Английские стоп-слова");
                    int c = Convert.ToInt32(Console.ReadLine());
                    string p = "";
                    switch (c)
                    {
                        case 1:
                            p = "C:\\Users\\Admin\\source\\repos\\KlyzhukA\\CS_Labs\\CS_Lab3\\Files\\stopwords_ru.txt";
                            break;
                        case 2:
                            p = "C:\\Users\\Admin\\source\\repos\\KlyzhukA\\CS_Labs\\CS_Lab3\\Files\\stopwords_en.txt";
                            break;
                    }
                    TextProcessor.RemoveStopWords(text, p);
                    break;
                case 7:
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine("Текущий вид текста:\n" + text.Value);
                    }
                    Console.WriteLine("Результат записан в task.txt");
                    break;
                    case 8:
                    return;
            }
        }
    }
}