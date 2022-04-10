using ChessProject.Board;
using ChessProject.ChessGame;
using ChessProject.Board.Enums;

namespace ChessProject
{// class to the print screen the game 
    internal class Screen
    {
        //main method to show the game
        public static void PrintGame(ChessGameConfig chessGame)
        {
            Console.Clear();
            Screen.PrintBoard(chessGame.Board);
            PrintCapturedPieces(chessGame);
            SubtitlePtBR();
            Console.WriteLine("\nTurn: " + chessGame.Turn);
            if (!chessGame.GameOver)
            {
                Console.WriteLine("Waiting for play: " + chessGame.CurrentPlayer);
                if (chessGame.Check)
                {
                    Console.WriteLine("YOU ARE CHECK !!!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE !!!"); 
                Console.WriteLine("WINNER : " + chessGame.CurrentPlayer);
                Console.ReadLine();
            }

        }
        //main method to print the captured pieces
        public static void PrintCapturedPieces(ChessGameConfig chessGame)
        {
            Console.WriteLine("\nCaptured Pieces: ");
            Console.Write("White:");
            PrintSetCapturedPiece(chessGame.CapturedPieces(PieceColor.White));
            Console.Write("\nBlack:");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSetCapturedPiece(chessGame.CapturedPieces(PieceColor.Black));
            Console.ForegroundColor = aux;

        }
        //subtitle method for Portuguese - Brazil
        public static void SubtitlePtBR()
        {
            Console.WriteLine("\nSubtitle - Legenda");
            Console.WriteLine("P = Pawn = Peão");
            Console.WriteLine("R = Rook = Torre");
            Console.WriteLine("N = Knight = Cavalo");
            Console.WriteLine("B = Bishop = Bispo");
            Console.WriteLine("Q = Queen = Rainha");
            Console.WriteLine("K = King = Rei");
        }
        //method to traverse set and show captured pieces
        public static void PrintSetCapturedPiece(HashSet<ChessPiece> setPieces)
        {
            Console.Write("[");
            foreach (ChessPiece piece in setPieces)
            {
                Console.Write(piece + ", ");
            }
            Console.Write("]");
        }

        //method to print board
        public static void PrintBoard(BoardGame board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    PrintPiece(board.BoardSize(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        //overriden method to print board
        public static void PrintBoard(BoardGame board, bool[,] possiblePossitions)
        {
            ConsoleColor originalColor = Console.BackgroundColor;
            ConsoleColor newColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Line; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    if (possiblePossitions[i, j])
                    {
                        Console.BackgroundColor = newColor;
                    }
                    else
                    {
                        Console.BackgroundColor = originalColor;
                    }
                    PrintPiece(board.BoardSize(i, j));
                    Console.BackgroundColor = originalColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalColor;
        }

        //method to read piece position
        public static ChessPosition ReadChessPosition()
        {
            string readChessPosition = Console.ReadLine();
            char column = readChessPosition[0];
            int line = int.Parse(readChessPosition.Substring(1));
            return new ChessPosition(column, line);
        }
        // method to print chess pieces in board
        public static void PrintPiece(ChessPiece chessPiece)
        {

            if (chessPiece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (chessPiece.Color == PieceColor.White)
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
                Console.Write(" ");
            }
        }


    }
}
