using ChessProject.Board;

namespace ChessProject
{
    internal class Screen
    {
        public static void PrintBoard(BoardGame board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                for (int j = 0; j < board.Column; j++)
                {   if(board.PiecePosition(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                else
                    {
                        Console.Write(board.PiecePosition(i, j) + " ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
