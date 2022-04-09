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
          
            try
            {
                BoardGame position;

                position = new BoardGame(8, 8);

                position.AddPieceInBoard(new Rook(position, PieceColor.Black), new Position(0, 0));
                position.AddPieceInBoard(new Rook(position, PieceColor.Black), new Position(1, 3));
                position.AddPieceInBoard(new King(position, PieceColor.Black), new Position(0, 2));
                
                position.AddPieceInBoard(new Rook(position, PieceColor.White), new Position(3, 5));
                position.AddPieceInBoard(new Rook(position, PieceColor.White), new Position(7, 7));
                position.AddPieceInBoard(new King(position, PieceColor.White), new Position(4, 4));

                Screen.PrintBoard(position);

                Console.ReadLine();
            }
            catch (BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
          

       
           
        }
    }
}