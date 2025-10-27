namespace CS_Lab3
{
    public class Punctuation : Token
    {
        public Punctuation(string str)
        {
            Value = str;
        }
        public bool IsEndingPunctuation
        {
            get { return Value == "." || Value == "!" || Value == "?" || Value == "..."; }
        }
    }
}
