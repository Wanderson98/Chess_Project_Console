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
    }
}
