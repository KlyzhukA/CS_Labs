using System.Xml.Serialization;

namespace CS_Lab3
{
    [Serializable]
    [XmlInclude(typeof(Word))]
    [XmlInclude(typeof(Punctuation))]
    public abstract class Token
    {
        [XmlText]
        public string Value { get; set; }
    }
}
