using ChessProject.Board;

namespace ChessProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            BoardGame position;

            position = new BoardGame(8, 8);

            Screen.PrintBoard(position);

            Console.ReadLine();
        }
    }
}