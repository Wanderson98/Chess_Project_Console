using ChessProject.Board;
using ChessProject.Board.Enums;

namespace ChessProject.ChessGame
{   //class for configuration of the "Bishop" piece, heir class of the chess piece class
    internal class Bishop : ChessPiece
    {
        

        //constructor
        public Bishop(BoardGame board, PieceColor color): base(color, board)
        {

        }
        //method to print the letter related to the piece
        public override string ToString()
        {
            return "B";
        }
        // class helper method to check if movement is possible
        private bool CanMove(Position position)
        {
            ChessPiece chessPiece = Board.PiecePosition(position);
            return chessPiece == null || chessPiece.Color != Color;
        }
        //method to check the possible moves of the chess piece
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
