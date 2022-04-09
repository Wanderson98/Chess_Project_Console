using ChessProject.Board;
using ChessProject.Board.Enums;


namespace ChessProject.ChessGame
{
    internal class King : ChessPiece
    {
        public King(BoardGame boardGame, PieceColor pieceColor) : base(pieceColor, boardGame)
        {
        }

        public override string ToString()
        {
            return "K";
        }
        private bool CanMove(Position position)
        {
            ChessPiece chessPiece = Board.PiecePosition(position);
            return chessPiece == null || chessPiece.Color != Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] result = new bool[Board.Line, Board.Column];

            Position positionKing = new Position(0, 0);
            //Up 
            positionKing.SetValues(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            //NorthEast
            positionKing.SetValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true; ;
            }
            //Right
            positionKing.SetValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true; ;
            }
            //SouthEast
            positionKing.SetValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            //Down
            positionKing.SetValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            //SouthWest
            positionKing.SetValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            //Left 
            positionKing.SetValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            //NorthWest
            positionKing.SetValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            return result;
        }
    }
}
