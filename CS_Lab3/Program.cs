using CS_Lab3;
using System.Text;

class Program
{
    private static void Main(string[] args)
    {
        string testText = "";
        using (StreamReader sr = new StreamReader("C:\\Users\\Admin\\source\\repos\\KlyzhukA\\CS_Labs\\CS_Lab3\\Files\\Text.txt", Encoding.UTF8))
        {
            testText = sr.ReadToEnd();
            Console.WriteLine(testText);
        }
        Text text = TextParser.Parse(testText);
        foreach(Sentence sentence in text.Sentences)
        {
            Console.WriteLine(sentence.Value);
            foreach(Token token in sentence.Tokens)
            {
                Console.WriteLine(token.Value);
            }
        }
        TextProcessor.PrintByWordsCount(text, "C:\\Users\\Admin\\source\\repos\\KlyzhukA\\CS_Labs\\CS_Lab3\\Files\\ByWords.txt");
        TextProcessor.PrintBySentenceLength(text, "C:\\Users\\Admin\\source\\repos\\KlyzhukA\\CS_Labs\\CS_Lab3\\Files\\ByChars.txt");
    }
}