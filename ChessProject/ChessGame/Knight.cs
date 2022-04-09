using ChessProject.Board;
using ChessProject.Board.Enums;

namespace ChessProject.ChessGame
{
    internal class Knight : ChessPiece
    {
        public Knight(BoardGame board, PieceColor color) : base(color, board)
        {

        }

        public override string ToString()
        {
            return "N";
        }

        private bool CanMove(Position position)
        {
            ChessPiece chessPiece = Board.PiecePosition(position);
            return chessPiece == null || chessPiece.Color != Color;
        }

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
