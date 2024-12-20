using PuissanceQuatre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuissanceQuatre
{
    public class PowerStack
    {
        public PowerStack() 
        {
            Stack = new();
        }

        public Stack<Token> Stack { get; set; }
        public int Capacity { get; private set; } = 7;

        public bool Push(Token token)
        {
            if (Stack.Count < Capacity)
            {
                Stack.Push(token);
                token.SetIndex(Stack.Count);

                return true;
            }

            return false;
        }



    }

}
