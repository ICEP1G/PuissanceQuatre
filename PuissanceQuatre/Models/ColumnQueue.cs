

namespace PuissanceQuatre.Models
{
    public class ColumnQueue
    {
        public ColumnQueue()
        {
            Column = new();
        }

        public Queue<Token> Column { get; set; }
        public int Capacity { get; private set; } = 6;

        public bool PushToken(Token token)
        {
            if (Column.Count < Capacity)
            {
                Column.Enqueue(token);
                token.SetIndex(Column.Count - 1);

                return true;
            }

            return false;
        }

    }

}
