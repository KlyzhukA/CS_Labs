using System.Text.RegularExpressions;

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
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine("---------------------------------");
                sw.WriteLine("Предложения по кол-ву слов");
                foreach (Sentence sentence in sortedSentences)
                {
                    sw.WriteLine(sentence.Value);
                }
            }
            Console.WriteLine("Результат записан в task.txt");
        }
        public static void PrintBySentenceLength(Text text, string path)
        {
            var sortedSentences = new List<Sentence>(text.Sentences);
            foreach (Sentence s in sortedSentences)
            {
                s.ComparisonWay = Sentence.CompareBy.Char;
            }
            sortedSentences.Sort();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine("---------------------------------");
                sw.WriteLine("Предложения по кол-ву символов");
                foreach (Sentence sentence in sortedSentences)
                {
                    sw.WriteLine(sentence.Value);
                }
            }
            Console.WriteLine("Результат записан в task.txt");
        }
        public static List<Word> FindWordsInQuastions(Text text, int n)
        {
            List<Word> words = new List<Word>();
            foreach (Sentence s in text.Sentences)
            {
                if (s.IsQuastion)
                {
                    foreach (Token t in s.Tokens)
                    {
                        if (t is Word w && w.Value.Length == n)
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
                foreach (Word w in words)
                {
                    s.Tokens.Remove(w);
                }
            }
        }
        public static void ReplaceWords(Text text, int index, string str, int num)
        {
            foreach (Token t in text.Sentences[index - 1].Tokens)
            {
                if (t is Word w && w.Value.Length == num)
                {
                    w.Value = str;
                }
            }
        }
        public static void RemoveStopWords(Text text, string path)
        {
            List<string> stopwords = new List<string>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    stopwords.Add(line.Trim());
                }
            }
            foreach (Sentence s in text.Sentences)
            {
                List<Word> words = new List<Word>();
                foreach (Token t in s.Tokens)
                {
                    if (t is Word w && stopwords.Contains(w.Value))
                    {
                        words.Add(w);
                    }
                }
                foreach (Word w in words)
                {
                    s.Tokens.Remove(w);
                }
            }
        }
        public static void BuildConcordance(Text text, string path)
        {
            var concordance = new Dictionary<string, (int count, List<int> lines)>();
            string[] allLines = text.FullText.Split('\n');

            int lineNumber = 1;

            Regex phoneRegex = new Regex(
                @"(?:\+\d{1,3}[-.\s]?)?(?:\(?\d{1,4}\)?[-.\s]?)?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}",
                RegexOptions.Compiled
            );

            Regex dateRegex = new Regex(
                @"\b\d{1,2}[-./]\d{1,2}[-./]\d{2,4}\b|\b\d{4}[-./]\d{1,2}[-./]\d{1,2}\b",
                RegexOptions.Compiled
            );

            Regex emailRegex = new Regex(
                @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b", 
                RegexOptions.Compiled | RegexOptions.IgnoreCase
            );

            foreach (string line in allLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    lineNumber++;
                    continue;
                }

                var tokens = new List<string>();

                var matches = new List<Match>();

                matches.AddRange(phoneRegex.Matches(line).Cast<Match>());
                matches.AddRange(dateRegex.Matches(line).Cast<Match>());
                matches.AddRange(emailRegex.Matches(line).Cast<Match>());

                if (matches.Count > 0)
                {
                    matches.Sort((a, b) => a.Index.CompareTo(b.Index));

                    int lastIndex = 0;
                    foreach (var match in matches)
                    {
                        if (match.Index > lastIndex)
                        {
                            string beforeMatch = line.Substring(lastIndex, match.Index - lastIndex);
                            tokens.AddRange(SplitIntoWords(beforeMatch));
                        }

                        tokens.Add(match.Value);
                        lastIndex = match.Index + match.Length;
                    }

                    if (lastIndex < line.Length)
                    {
                        string afterMatch = line.Substring(lastIndex);
                        tokens.AddRange(SplitIntoWords(afterMatch));
                    }
                }
                else
                {
                    tokens.AddRange(SplitIntoWords(line));
                }

                var wordsInLine = new List<string>();

                foreach (string token in tokens)
                {
                    string cleanWord = token.Trim().ToLower();

                    if (string.IsNullOrEmpty(cleanWord)) continue;

                    if (!concordance.ContainsKey(cleanWord))
                    {
                        concordance[cleanWord] = (0, new List<int>());
                    }

                    (int count, List<int> lines) tuple = concordance[cleanWord];
                    concordance[cleanWord] = (tuple.count + 1, tuple.lines);

                    if (!wordsInLine.Contains(cleanWord))
                    {
                        concordance[cleanWord].lines.Add(lineNumber);
                        wordsInLine.Add(cleanWord);
                    }
                }

                lineNumber++;
            }

            var sortedKeys = new List<string>(concordance.Keys);
            sortedKeys.Sort();

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine("---------------------------------");
                sw.WriteLine("Конкорданс:");

                foreach (string word in sortedKeys)
                {
                    int totalCount = concordance[word].count;
                    List<int> lineNumbers = concordance[word].lines;

                    lineNumbers.Sort();

                    string lineNumbersStr = "";
                    foreach (int num in lineNumbers)
                    {
                        lineNumbersStr += num.ToString() + " ";
                    }

                    if (lineNumbersStr.Length > 0)
                        lineNumbersStr = lineNumbersStr.TrimEnd();

                    string formattedWord = word;
                    int dotsNeeded = 25 - word.Length;
                    for (int i = 0; i < dotsNeeded; i++)
                    {
                        formattedWord += ".";
                    }
                    sw.WriteLine($"{formattedWord}{totalCount}:{lineNumbersStr}");
                }
            }

            Console.WriteLine("Конкорданс построен и записан в task.txt");
        }
        private static List<string> SplitIntoWords(string text)
        {
            return text.Split(new[] { ' ', ',', '.', '!', '?', ';', ':', '(', ')', '[', ']', '{', '}', '"', '\'', '«', '»', '—', '-', '&', '\t', '\r' },
            StringSplitOptions.RemoveEmptyEntries).Where(w => !string.IsNullOrWhiteSpace(w)).ToList();
        }
    }
}
