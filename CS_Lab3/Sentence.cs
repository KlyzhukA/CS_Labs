using System.Text;

namespace CS_Lab3
{
    public class Sentence : Token, IComparable<Sentence>
    {
        public List<Token> Tokens { get; set; } = new List<Token>();
        public new string Value
        {
            get
            {
                var result = new StringBuilder();
                foreach (var token in Tokens)
                {
                    if (token is Word)
                    {
                        if (result.Length > 0 && !char.IsPunctuation(result[result.Length - 1]))
                            result.Append(' ');
                        result.Append(token.Value);
                    }
                    else
                    {
                        result.Append(token.Value);
                    }
                }
                return result.ToString();
            }
            set { }
        }
        public int WordCounter()
        {
            int counter = 0;
            foreach(var token in Tokens)
            {
                if (token is Word)
                {
                    counter++;
                }
            }
            return counter;
        }
        public int CompareTo(Sentence? sentence)
        {
            return WordCounter() - sentence.WordCounter();
        }
    }
}
