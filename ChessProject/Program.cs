using ChessProject.Board;

namespace ChessProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            Position position;

            position = new Position(2, 3);

            Console.WriteLine(position);

            Console.ReadLine();
        }
    }
}