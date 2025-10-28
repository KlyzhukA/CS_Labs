using System.Text;

namespace CS_Lab3
{
    public class TextProcessor
    {
        public static void PrintByWordsCount(Text text, string path)
        {
            var sortedSentences = new List<Sentence>(text.Sentences);
            foreach (Sentence s in sortedSentences)
            {
                s.ComparisonWay = Sentence.CompareBy.Word;
            }
            sortedSentences.Sort();
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("---------------------------------");
                sw.WriteLine("Предложения по кол-ву слов");
                foreach (Sentence sentence in sortedSentences)
                {
                    sw.WriteLine(sentence.Value);
                }
            }
        }
        public static void PrintBySentenceLength(Text text, string path)
        {
            var sortedSentences = new List<Sentence>(text.Sentences);
            foreach (Sentence s in sortedSentences)
            {
                s.ComparisonWay = Sentence.CompareBy.Char;
            }
            sortedSentences.Sort();
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("---------------------------------");
                sw.WriteLine("Предложения по кол-ву символов");
                foreach (Sentence sentence in sortedSentences)
                {
                    sw.WriteLine(sentence.Value);
                }
            }
        }
        public static List<Word> FindWordsInQuastions(Text text, int n)
        {
            List<Word> words = new List<Word>();
            foreach(Sentence s in text.Sentences)
            {
                if (s.IsQuastion)
                {
                    foreach(Token t in s.Tokens)
                    {
                        if(t is Word w && w.Value.Length == n)
                        {
                            if (!words.Contains(w))
                            {
                                words.Add(w);
                            }
                        }
                    }
                }
            }
            return words;
        }
        public static void DeleteWords(Text text, int n)
        {
            var consonants = new List<char> {
            'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ',
            'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z'
            };
            foreach (Sentence s in text.Sentences)
            {
                List<Word> words = new List<Word>();
                foreach (Token t in s.Tokens)
                {
                    if (t is Word w && w.Value.Length == n)
                    {
                        char first = char.ToLower(w.Value[0]);
                        if (consonants.Contains(first))
                        {
                            words.Add(w);
                        }
                    }
                }
                foreach(Word w in words)
                {
                    s.Tokens.Add(w);
                }
            }
        }
    }
}
