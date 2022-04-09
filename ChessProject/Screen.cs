using ChessProject.Board;
using ChessProject.Board.Enums;

namespace ChessProject
{
    internal class Screen
    {
        public static void PrintBoard(BoardGame board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < board.Column; j++)
                {   if(board.PiecePosition(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                else
                    {
                        PrintPiece(board.PiecePosition(i, j));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintPiece(ChessPiece chessPiece)
        {
            if(chessPiece.Color == PieceColor.White)
            {
                Console.Write(chessPiece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(chessPiece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
