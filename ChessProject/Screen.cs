﻿using ChessProject.Board;
using ChessProject.ChessGame;
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
                {
                    PrintPiece(board.PiecePosition(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }
        public static void PrintBoard(BoardGame board, bool[,] possiblePossitions)
        {
            ConsoleColor originalColor = Console.BackgroundColor;
            ConsoleColor newColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Line; i++)
            {
                Console.Write((8 - i) + " ");
                for (int j = 0; j < board.Column; j++)
                {
                    if (possiblePossitions[i, j] == true)
                    {
                        Console.BackgroundColor = newColor;
                    }
                    else
                    {
                        Console.BackgroundColor = originalColor;
                    }
                    PrintPiece(board.PiecePosition(i, j));
                    Console.BackgroundColor = originalColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalColor;
        }
        public static ChessPosition ReadChessPosition()
        {
            string readChessPosition = Console.ReadLine();
            char column = readChessPosition[0];
            int line = int.Parse(readChessPosition.Substring(1));
            return new ChessPosition(column, line);
        }

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
