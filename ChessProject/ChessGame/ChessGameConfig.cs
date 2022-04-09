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

        private HashSet<ChessPiece> chessPieces;
        private HashSet<ChessPiece> piecesCaptured;

        public ChessGameConfig()
        {
            Board = new BoardGame(8, 8);
            Turn = 1;
            CurrentPlayer = PieceColor.White;
            GameOver = false;
            chessPieces = new HashSet<ChessPiece>();
            piecesCaptured = new HashSet<ChessPiece>();
            AddPiecesInGame();
        }

        public void ExecuteMovement(Position originalPosition, Position destinationPosition)
        {
            ChessPiece chessPiece = Board.RemovePiece(originalPosition);
            chessPiece.IncrementNumberOfMoves();
            ChessPiece CapturePiece = Board.RemovePiece(destinationPosition);
            Board.AddPieceInBoard(chessPiece, destinationPosition);
            if(CapturePiece != null)
            {
                piecesCaptured.Add(CapturePiece);
            }
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
            if (Board.PiecePosition(position) == null)
            {
                throw new BoardException("There is no piece in the chosen origin position!!!");
            }
            if (CurrentPlayer != Board.PiecePosition(position).Color)
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

        public HashSet<ChessPiece> CapturedPieces(PieceColor color)
        {
            HashSet<ChessPiece> aux = new HashSet<ChessPiece>();
            foreach (ChessPiece x in piecesCaptured)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<ChessPiece> PiecesInGame(PieceColor color)
        {
            HashSet<ChessPiece> aux = new HashSet<ChessPiece>();
            foreach (ChessPiece x in chessPieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        public void AddNewPiece(char column, int line, ChessPiece piece)
        {
            Board.AddPieceInBoard(piece, new ChessPosition(column, line).ToPosition());
            chessPieces.Add(piece);
        }
        private void AddPiecesInGame()
        {
            AddNewPiece('c', 1, new Rook(Board, PieceColor.White));
            AddNewPiece('c', 2, new Rook(Board, PieceColor.White));
            AddNewPiece('d', 2, new Rook(Board, PieceColor.White));
            AddNewPiece('e', 2, new Rook(Board, PieceColor.White));
            AddNewPiece('e', 1, new Rook(Board, PieceColor.White));
            AddNewPiece('d', 1, new King(Board, PieceColor.White));

            AddNewPiece('c', 7, new Rook(Board, PieceColor.Black));
            AddNewPiece('c', 8, new Rook(Board, PieceColor.Black));
            AddNewPiece('d', 7, new Rook(Board, PieceColor.Black));
            AddNewPiece('e', 7, new Rook(Board, PieceColor.Black));
            AddNewPiece('e', 8, new Rook(Board, PieceColor.Black));
            AddNewPiece('d', 8, new King(Board, PieceColor.Black));


        }
    }
}
