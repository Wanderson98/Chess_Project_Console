using ChessProject.Board;
using ChessProject.Board.Exceptions;
using ChessProject.Board.Enums;

namespace ChessProject.ChessGame
{
    internal class ChessGameConfig
    {
        public BoardGame Board { get; private set; }
        public int Turn { get; private set; }
        public PieceColor CurrentPlayer { get; private set; }
        public bool GameOver { get; private set; }

        public ChessGameConfig()
        {
            Board = new BoardGame(8, 8);
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
        public void MakePlay(Position originalPosition, Position destinationPosition)
        {
            ExecuteMovement(originalPosition, destinationPosition);
            Turn++;
            ChangePlayer();
        }
        private void ChangePlayer()
        {
            if (CurrentPlayer == PieceColor.White)
            {
                CurrentPlayer = PieceColor.Black;
            }
            else
            {
                CurrentPlayer = PieceColor.White;
            }
        }

        public void ValidOriginalPosition(Position position)
        {
            if(Board.PiecePosition(position) == null)
            {
                throw new BoardException("There is no piece in the chosen origin position!!!"); 
            }
            if(CurrentPlayer != Board.PiecePosition(position).Color)
            {
                throw new BoardException("The chosen piece is not yours!!!");
            }
            if (!Board.PiecePosition(position).ThereIsPossibleMoves())
            {
                throw new BoardException("There are no possible moves for the chosen piece!!!"); 
            }
        }

        public void ValidDestinationPosition(Position originalPosition, Position destinationPosition)
        {
            if (!Board.PiecePosition(originalPosition).CanMoveTo(destinationPosition))
            {
                throw new BoardException("Destination position invalid!!!");
            }
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
