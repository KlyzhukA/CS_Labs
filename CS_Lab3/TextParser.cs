using System.Text;

namespace CS_Lab3
{
    public static class TextParser
    {
        public static Text Parse(string input)
        {
            var text = new Text();
            var currentSentence = new Sentence();
            var currentWord = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsLetterOrDigit(c) || c == '-')
                {
                    currentWord.Append(c);
                }
                else if (char.IsWhiteSpace(c))
                {
                    if (currentWord.Length > 0)
                    {
                        currentSentence.Tokens.Add(new Word { Value = currentWord.ToString() });
                        currentWord.Clear();
                    }
                }
                else if (char.IsPunctuation(c))
                {
                    if (currentWord.Length > 0)
                    {
                        currentSentence.Tokens.Add(new Word { Value = currentWord.ToString() });
                        currentWord.Clear();
                    }

                    Punctuation punctuation = new Punctuation(c.ToString());
                    currentSentence.Tokens.Add(punctuation);

                    if (punctuation.IsEndingPunctuation)
                    {
                        if (currentSentence.Tokens.Count > 0)
                        {
                            text.Sentences.Add(currentSentence);
                        }
                        currentSentence = new Sentence();
                    }
                }
            }
            return text;
        }
    }
}
