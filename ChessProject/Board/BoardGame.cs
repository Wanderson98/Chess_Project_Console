
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

        public void AddPieceInBoard(ChessPiece piece, Position position)
        {
            this.piece[position.Line, position.Column] = piece;
            piece.Position = position;
        }
    }
}
