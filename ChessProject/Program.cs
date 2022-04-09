using ChessProject.Board;
using ChessProject.Board.Enums;
using ChessProject.ChessGame;


namespace ChessProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            BoardGame position;

            position = new BoardGame(8, 8);

            position.AddPieceInBoard(new Rook(position, PieceColor.Black), new Position(0, 0));
            position.AddPieceInBoard(new Rook(position, PieceColor.Black), new Position(1, 3));
            position.AddPieceInBoard(new King(position, PieceColor.Black), new Position(2, 4));

            Screen.PrintBoard(position);

            Console.ReadLine();
        }
    }
}