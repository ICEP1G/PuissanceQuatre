

namespace PuissanceQuatre.Models
{
    public class PowerStack
    {
        public PowerStack()
        {
            Stack = new();
        }

        public Stack<Token> Stack { get; set; }
        public int Capacity { get; private set; } = 6;

        public bool PushToken(Token token)
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
