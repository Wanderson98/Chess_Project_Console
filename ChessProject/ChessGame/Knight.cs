using ChessProject.Board;
using ChessProject.Board.Enums;

namespace ChessProject.ChessGame
    //class for configuration of the "Knight" piece, heir class of the chess piece class    
{
    internal class Knight : ChessPiece
    {
        

        //constructor
        public Knight(BoardGame board, PieceColor color) : base(color, board)
        {

        }
        //method to print the letter related to the piece
        public override string ToString()
        {
            return "N";
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

            Position positionKnight = new Position(0, 0);

            positionKnight.SetValues(Position.Line - 1, Position.Column - 2);
            if (Board.ValidPosition(positionKnight) && CanMove(positionKnight))
            {
                result[positionKnight.Line, positionKnight.Column] = true;
            }
            positionKnight.SetValues(Position.Line - 2, Position.Column - 1);
            if (Board.ValidPosition(positionKnight) && CanMove(positionKnight))
            {
                result[positionKnight.Line, positionKnight.Column] = true;
            }
            positionKnight.SetValues(Position.Line - 2, Position.Column + 1);
            if (Board.ValidPosition(positionKnight) && CanMove(positionKnight))
            {
                result[positionKnight.Line, positionKnight.Column] = true;
            }
            positionKnight.SetValues(Position.Line - 1, Position.Column + 2);
            if (Board.ValidPosition(positionKnight) && CanMove(positionKnight))
            {
                result[positionKnight.Line, positionKnight.Column] = true;
            }
            positionKnight.SetValues(Position.Line + 1, Position.Column + 2);
            if (Board.ValidPosition(positionKnight) && CanMove(positionKnight))
            {
                result[positionKnight.Line, positionKnight.Column] = true;
            }
            positionKnight.SetValues(Position.Line + 2, Position.Column + 1);
            if (Board.ValidPosition(positionKnight) && CanMove(positionKnight))
            {
                result[positionKnight.Line, positionKnight.Column] = true;
            }
            positionKnight.SetValues(Position.Line + 2, Position.Column - 1);
            if (Board.ValidPosition(positionKnight) && CanMove(positionKnight))
            {
                result[positionKnight.Line, positionKnight.Column] = true;
            }
            positionKnight.SetValues(Position.Line + 1, Position.Column - 2);
            if (Board.ValidPosition(positionKnight) && CanMove(positionKnight))
            {
                result[positionKnight.Line, positionKnight.Column] = true;
            }

            return result;
        }
    }
}
