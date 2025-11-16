using System.Xml.Serialization;

namespace CS_Lab3
{
    [Serializable]
    public class Punctuation : Token
    {
        public Punctuation(string str)
        {
            Value = str;
        }
        [XmlIgnore]
        public bool IsEndingPunctuation
        {
            get { return Value == "." || Value == "!" || Value == "?" || Value == "..."; }
        }
        public Punctuation() { }
    }
}
