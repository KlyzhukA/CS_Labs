using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace CS_Lab3
{
    public class Text
    {
        public List<Sentence> Sentences { get; set; } = new List<Sentence>();
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
    }
}
