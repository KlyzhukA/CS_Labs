using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace CS_Lab3
{
    [Serializable]
    [XmlRoot("text")]
    public class Text
    {
        [XmlElement("sentence")]
        public List<Sentence> Sentences { get; set; } = new List<Sentence>();
        [XmlIgnore]
        public string FullText { get; set; }
        [XmlIgnore]
        public new string Value
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var sentence in Sentences)
                {
                    sb.Append(sentence.Value+"\n");
                }
                return sb.ToString();
            }
        }
        public Text() { }
    }
}
