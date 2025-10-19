using CS_Lab3;

class Program
{
    private static void Main(string[] args)
    {
        string testText = "Программирование - это искусство создания инструкций для компьютера с помощью" +
            " специальных языков. В C# каждая программа должна содержать как минимум один класс" +
            " с методом Main, который является точкой входа в приложение." +
            " Объектно-ориентированное программирование позволяет создавать модульные программы" +
            " и повторно использовать код через механизмы наследования и полиморфизма.";
        Text text = TextParser.Parse(testText);
        foreach(Sentence sentence in text.Sentences)
        {
            Console.WriteLine(sentence.Value);
            foreach(Token token in sentence.Tokens)
            {
                Console.WriteLine(token.Value);
            }
        }
    }
}