using ChessProject.Board;
using ChessProject.Board.Enums;


namespace ChessProject.ChessGame
{
    internal class Rook : ChessPiece
    {
        public Rook(BoardGame boardGame, PieceColor pieceColor) : base(pieceColor, boardGame)
        {
        }

        public override string ToString()
        {
            return "R";
        }
        private bool CanMove(Position position)
        {
            ChessPiece chessPiece = Board.PiecePosition(position);
            return chessPiece == null || chessPiece.Color != Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] result = new bool[Board.Line, Board.Column];

            Position positionRook = new Position(0, 0);
            //Up 
            positionRook.SetValues(Position.Line - 1, Position.Column);
            while(Board.ValidPosition(positionRook) && CanMove(positionRook))
            {
                result[positionRook.Line, positionRook.Column] = true;
                if(Board.PiecePosition(positionRook) != null && Board.PiecePosition(positionRook).Color != Color)
                {
                    break;
                }
                positionRook.Line = positionRook.Line - 1;
            }

            //Right
            positionRook.SetValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(positionRook) && CanMove(positionRook))
            {
                result[positionRook.Line, positionRook.Column] = true;
                if (Board.PiecePosition(positionRook) != null && Board.PiecePosition(positionRook).Color != Color)
                {
                    break;
                }
                positionRook.Column = positionRook.Column + 1;
            }

            //Down
            positionRook.SetValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(positionRook) && CanMove(positionRook))
            {
                result[positionRook.Line, positionRook.Column] = true;
                if (Board.PiecePosition(positionRook) != null && Board.PiecePosition(positionRook).Color != Color)
                {
                    break;
                }
                positionRook.Line = positionRook.Line + 1;
            }

            //Left 
            positionRook.SetValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(positionRook) && CanMove(positionRook))
            {
                result[positionRook.Line, positionRook.Column] = true;
                if (Board.PiecePosition(positionRook) != null && Board.PiecePosition(positionRook).Color != Color)
                {
                    break;
                }
                positionRook.Column = positionRook.Column - 1;
            }

            return result;
        }

    }
}
