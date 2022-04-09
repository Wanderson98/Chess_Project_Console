﻿using ChessProject.Board.Enums;

namespace ChessProject.Board
{
    internal class ChessPiece
    {
        public Position Position { get; set; }
        public PieceColor Color { get; protected set; }
        public int NumberOfMoves { get; protected set; }
        public BoardGame Board { get; protected set; }

        public ChessPiece(Position position, PieceColor color, BoardGame board)
        {
            Position = position;
            Color = color;
            Board = board;
            NumberOfMoves = 0;
        }
    }
}
