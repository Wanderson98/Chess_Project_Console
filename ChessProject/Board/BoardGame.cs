using ChessProject.Board.Exceptions;
namespace ChessProject.Board
{
    internal class BoardGame
    {
        public int Line { get; set; }
        public int Column { get; set; }
        private ChessPiece[,] chessPiece;
        public BoardGame(int line, int column)
        {
            Line = line;
            Column = column;
            chessPiece = new ChessPiece[Line, Column];
        }

        public ChessPiece PiecePosition(int line, int column)
        {
            return chessPiece[line, column];
        }

        public ChessPiece PiecePosition(Position position)
        {
            return chessPiece[position.Line, position.Column];
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
                chessPiece[position.Line, position.Column] = piece;
                piece.Position = position;
            }

        }
        
        public ChessPiece RemovePiece(Position position)
        {
            if(PiecePosition(position) == null)
            {
                return null;
            }
            else
            {
                ChessPiece piece = PiecePosition(position);
                piece.Position = null;
                chessPiece[position.Line, position.Column] = null;
                return piece;
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
