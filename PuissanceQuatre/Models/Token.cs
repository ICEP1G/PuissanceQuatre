using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuissanceQuatre.Models
{
    public class Token
    {
        public Token(TokenColor color)
        {
            Color = color;
        }

        public int index { get; private set; }
        public TokenColor Color { get; set; }

        public void SetIndex(int index)
        {
            this.index = index;
        }

    }

    public enum TokenColor
    {
        Yellow = 1,
        Red = 2,
    }
}
