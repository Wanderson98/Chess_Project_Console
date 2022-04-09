using ChessProject.Board;
using ChessProject.Board.Enums;

namespace ChessProject.ChessGame
{
    internal class Bishop : ChessPiece
    {
        public Bishop(BoardGame board, PieceColor color): base(color, board)
        {

        }

        public override string ToString()
        {
            return "B";
        }

        private bool CanMove(Position position)
        {
            ChessPiece chessPiece = Board.PiecePosition(position);
            return chessPiece == null || chessPiece.Color != Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] result = new bool[Board.Line, Board.Column];

            Position positionBishop = new Position(0, 0);
            //NorthWest
            positionBishop.SetValues(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(positionBishop) && CanMove(positionBishop))
            {
                result[positionBishop.Line, positionBishop.Column] = true;
                if (Board.PiecePosition(positionBishop) != null && Board.PiecePosition(positionBishop).Color != Color)
                {
                    break;
                }
                positionBishop.SetValues(positionBishop.Line - 1, positionBishop.Column - 1);
            }

            //NorthEast
            positionBishop.SetValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(positionBishop) && CanMove(positionBishop))
            {
                result[positionBishop.Line, positionBishop.Column] = true;
                if (Board.PiecePosition(positionBishop) != null && Board.PiecePosition(positionBishop).Color != Color)
                {
                    break;
                }
                positionBishop.SetValues(positionBishop.Line - 1, positionBishop.Column + 1); 
            }

            //SouthEast
            positionBishop.SetValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(positionBishop) && CanMove(positionBishop))
            {
                result[positionBishop.Line, positionBishop.Column] = true;
                if (Board.PiecePosition(positionBishop) != null && Board.PiecePosition(positionBishop).Color != Color)
                {
                    break;
                }
                positionBishop.SetValues(positionBishop.Line + 1, positionBishop.Column + 1);
            }

            //SouthWest
            positionBishop.SetValues(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(positionBishop) && CanMove(positionBishop))
            {
                result[positionBishop.Line, positionBishop.Column] = true;
                if (Board.PiecePosition(positionBishop) != null && Board.PiecePosition(positionBishop).Color != Color)
                {
                    break;
                }
                positionBishop.SetValues(positionBishop.Line + 1, positionBishop.Column - 1); ;
            }

            return result;
        }
    }
}
