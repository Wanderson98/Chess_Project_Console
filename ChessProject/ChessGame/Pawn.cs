using ChessProject.Board;
using ChessProject.Board.Enums;


namespace ChessProject.ChessGame
{
    internal class Pawn : ChessPiece
    {
        public Pawn(BoardGame boardGame, PieceColor pieceColor) : base(pieceColor, boardGame)
        {
        }

        public override string ToString()
        {
            return "P";
        }
        private bool ThereIsEnemy(Position position)
        {
            ChessPiece piece = Board.PiecePosition(position);
            return piece != null && piece.Color != Color;
        }

        private bool FreePosition(Position position)
        {
            return Board.PiecePosition(position) == null;
        }
        private bool CanMove(Position position)
        {
            ChessPiece chessPiece = Board.PiecePosition(position);
            return chessPiece == null || chessPiece.Color != Color;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] result = new bool[Board.Line, Board.Column];

            Position positionPawn = new Position(0, 0);

            if (Color == PieceColor.White)
            {
                positionPawn.SetValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(positionPawn) && FreePosition(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line - 2, Position.Column);
                Position position2 = new Position(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(position2) && FreePosition(position2) && 
                    Board.ValidPosition(positionPawn) && FreePosition(positionPawn) && NumberOfMoves == 0)
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(positionPawn) && ThereIsEnemy(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(positionPawn) && ThereIsEnemy(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
            }
            else
            {
                positionPawn.SetValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(positionPawn) && FreePosition(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line + 2, Position.Column);
                Position position2 = new Position(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(position2) && FreePosition(position2) &&
                    Board.ValidPosition(positionPawn) && FreePosition(positionPawn) && NumberOfMoves == 0)
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(positionPawn) && ThereIsEnemy(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(positionPawn) && ThereIsEnemy(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
            }
            return result;

        }
    }
}
