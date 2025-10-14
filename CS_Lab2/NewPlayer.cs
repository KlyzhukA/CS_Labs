using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lab2
{
    public class NewPlayer : Player ,IComparable
    {
        int cout_item;
        public NewPlayer(int cout_item, string name) : base(name) 
        {
            this.cout_item = cout_item;
        }
        public int CompareTo(object? o)
        {
            if(o is NewPlayer newplayer)
            {
                return name.CompareTo(newplayer.name);
            }
            else
            {
                throw new Exception("объект не NewPlayer");
            }
        }
    }
}
