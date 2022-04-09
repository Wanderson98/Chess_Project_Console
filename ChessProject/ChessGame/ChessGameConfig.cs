using ChessProject.Board;
using ChessProject.Board.Enums;

namespace ChessProject.ChessGame
{
    internal class ChessGameConfig
    {
        public BoardGame Board { get; private set; }
        private int Turn;
        private PieceColor CurrentPlayer;
        public bool GameOver { get; private set; }

        public ChessGameConfig()
        {
            Board = new BoardGame(8,8);
            Turn = 1;
            CurrentPlayer = PieceColor.White;
            GameOver = false;
            AddPiecesInGame();
        }

        public void ExecuteMovement(Position originalPosition, Position destinationPosition)
        {
            ChessPiece chessPiece = Board.RemovePiece(originalPosition);
            chessPiece.IncrementNumberOfMoves();
            ChessPiece CapturePiece = Board.RemovePiece(destinationPosition);
            Board.AddPieceInBoard(chessPiece, destinationPosition);
        }

        private void AddPiecesInGame()
        {
            Board.AddPieceInBoard(new Rook(Board, PieceColor.White), new ChessPosition('c', 1).ToPosition());
            Board.AddPieceInBoard(new Rook(Board, PieceColor.White), new ChessPosition('c', 2).ToPosition());
            Board.AddPieceInBoard(new Rook(Board, PieceColor.White), new ChessPosition('d', 2).ToPosition());
            Board.AddPieceInBoard(new Rook(Board, PieceColor.White), new ChessPosition('e', 2).ToPosition());
            Board.AddPieceInBoard(new Rook(Board, PieceColor.White), new ChessPosition('e', 1).ToPosition());
            Board.AddPieceInBoard(new King(Board, PieceColor.White), new ChessPosition('d', 1).ToPosition());

            Board.AddPieceInBoard(new Rook(Board, PieceColor.Black), new ChessPosition('c', 7).ToPosition());
            Board.AddPieceInBoard(new Rook(Board, PieceColor.Black), new ChessPosition('c', 8).ToPosition());
            Board.AddPieceInBoard(new Rook(Board, PieceColor.Black), new ChessPosition('d', 7).ToPosition());
            Board.AddPieceInBoard(new Rook(Board, PieceColor.Black), new ChessPosition('e', 7).ToPosition());
            Board.AddPieceInBoard(new Rook(Board, PieceColor.Black), new ChessPosition('e', 8).ToPosition());
            Board.AddPieceInBoard(new King(Board, PieceColor.Black), new ChessPosition('d', 8).ToPosition());

        }
    }
}
