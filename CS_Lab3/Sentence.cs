using System.Text;
using System.Xml.Serialization;

namespace CS_Lab3
{
    
    [Serializable]
    [XmlRoot("sentence")]
    public class Sentence : IComparable<Sentence>
    {
        public enum CompareBy
        {
            Word,
            Char
        }
        [XmlIgnore]
        public CompareBy ComparisonWay = CompareBy.Word;       
        [XmlElement("word", Type = typeof(Word))]
        [XmlElement("punctuation", Type = typeof(Punctuation))]
        public List<Token> Tokens { get; set; } = new List<Token>();
        [XmlIgnore]
        public bool IsQuastion = false;
        [XmlIgnore]
        public string Value
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
            if (ComparisonWay == CompareBy.Word)
            {
                return WordCounter() - sentence.WordCounter();
            }
            else
            {
                return Value.Length - sentence.Value.Length;
            }
        }
        public Sentence() { }
    }
}
