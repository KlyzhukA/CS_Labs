using System.Text;

namespace CS_Lab3
{
    public class TextProcessor
    {
        public static void PrintByWordsCount(Text text)
        {
            Console.WriteLine("предлодения по счету");
            text.Sentences.Sort();
            foreach(Sentence sentence in text.Sentences)
            {
                Console.WriteLine(sentence.Value);
            }
        }
    }
}
