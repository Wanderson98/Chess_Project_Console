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
                ChessGameConfig chessGame = new ChessGameConfig();

                while (!chessGame.GameOver)
                {
                    Console.Clear();
                    Screen.PrintBoard(chessGame.Board);

                    Console.Write("\nEnter the original position: "  );
                    Position originalPosition = Screen.ReadChessPosition().ToPosition();
                    Console.Write("Enter the destination position: ");
                    Position destinationPosition = Screen.ReadChessPosition().ToPosition();

                    chessGame.ExecuteMovement(originalPosition, destinationPosition);
                }

                
            
            }
            catch (BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
          

       
           
        }
    }
}