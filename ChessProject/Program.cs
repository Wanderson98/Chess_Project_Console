using ChessProject.Board;
using ChessProject.Board.Exceptions;
using ChessProject.Board.Enums;
using ChessProject.ChessGame;


namespace ChessProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            /*
            try
            {
                BoardGame position;

                position = new BoardGame(8, 8);

                position.AddPieceInBoard(new Rook(position, PieceColor.Black), new Position(9, 0));
                position.AddPieceInBoard(new Rook(position, PieceColor.Black), new Position(1, 3));
                position.AddPieceInBoard(new King(position, PieceColor.Black), new Position(0, 0));

                Screen.PrintBoard(position);

                Console.ReadLine();
            }
            catch (BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
            */

            ChessPosition chessPosition = new ChessPosition('h', 1);
            Console.WriteLine(chessPosition);
            Console.WriteLine(chessPosition.ToPosition());
           
        }
    }
}