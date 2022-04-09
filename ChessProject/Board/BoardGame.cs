using ChessProject.Board.Exceptions;
namespace ChessProject.Board
{
    internal class BoardGame
    {
        public int Line { get; set; }
        public int Column { get; set; }
        private ChessPiece[,] piece;
        public BoardGame(int line, int column)
        {
            Line = line;
            Column = column;
            piece = new ChessPiece[Line, Column];
        }

        public ChessPiece PiecePosition(int line, int column)
        {
            return piece[line, column];
        }

        public ChessPiece PiecePosition(Position position)
        {
            return piece[position.Line, position.Column];
        }

        public bool ThereIsPiece(Position position)
        {
            ValidatePosition(position);
            return PiecePosition(position) != null;
        }

        public void AddPieceInBoard(ChessPiece piece, Position position)
        {
            if (ThereIsPiece(position))
            {
                throw new BoardException("There is already a piece in this position!!!");
            }
            else
            {
                this.piece[position.Line, position.Column] = piece;
                piece.Position = position;
            }

        }

        public bool ValidPosition(Position position)
        {
            if (position.Line < 0 || position.Line >= Line || position.Column < 0 || position.Column >= Column)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Position!!!");
            }
        }

    }
}
