using ChessProject.Board.Exceptions;
namespace ChessProject.Board
{ //Board class
    internal class BoardGame
    {   //attributes
        public int Line { get; set; }
        public int Column { get; set; }
        private ChessPiece[,] chessPiece;

        //constructor
        public BoardGame(int line, int column)
        {
            Line = line;
            Column = column;
            chessPiece = new ChessPiece[Line, Column];
        }
        //method to start board size
        public ChessPiece BoardSize(int line, int column)
        {
            return chessPiece[line, column];
        }
        //method to return piece position
        public ChessPiece PiecePosition(Position position)
        {
            return chessPiece[position.Line, position.Column];
        }
        //method to return if the board position is empty
        public bool ThereIsPiece(Position position)
        {
            ValidatePosition(position);
            return PiecePosition(position) != null;
        }
        // method to add pieces to the board
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

        //method to remove pieces to the board
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
        //method to validate the position of the piece within the size of the board
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
        //method to return an exception if the position is invalid
        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new BoardException("Invalid Position!!!");
            }
        }

    }
}
