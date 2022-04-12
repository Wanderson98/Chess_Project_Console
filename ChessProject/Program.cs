using ChessProject.Board;
using ChessProject.Board.Exceptions;
using ChessProject.Board.Enums;
using ChessProject.ChessGame;


namespace ChessProject
{
    class Program
    {
        //main program method
       static void Main(string[] args)
        {


            ChessGameConfig chessGame = new ChessGameConfig();

            while (!chessGame.GameOver)
            {
                try
                {
                    Screen.PrintGame(chessGame);
                    Console.Write("\nEnter the original position: ");
                    Position originalPosition = Screen.ReadChessPosition().ToPosition();
                    chessGame.ValidOriginalPosition(originalPosition);

                    bool[,] possiblePositions = chessGame.Board.PiecePosition(originalPosition).PossibleMoves();

                    Console.Clear();
                    Screen.PrintBoard(chessGame.Board, possiblePositions);

                    Console.Write("\nEnter the destination position: ");
                    Position destinationPosition = Screen.ReadChessPosition().ToPosition();
                    chessGame.ValidDestinationPosition(originalPosition, destinationPosition);


                    chessGame.MakePlay(originalPosition, destinationPosition);
                }
                catch (BoardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("unexpected error " + e.Message);
                }

            }
            Console.Clear();
            Screen.PrintGame(chessGame);

        }
    }
}