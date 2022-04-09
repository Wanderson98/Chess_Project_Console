using ChessProject.Board;
using ChessProject.Board.Exceptions;
using ChessProject.Board.Enums;
//main class of the chess game, where the verification of rules, pieces, etc.
namespace ChessProject.ChessGame
{   
    internal class ChessGameConfig
    {   
        //attributes
        public BoardGame Board { get; private set; }
        public int Turn { get; private set; }
        public PieceColor CurrentPlayer { get; private set; }
        public bool GameOver { get; private set; }
        public bool Check { get; private set; }
        private HashSet<ChessPiece> chessPieces;
        private HashSet<ChessPiece> piecesCaptured;
        //constructor that start the game and the initial configuration 
        public ChessGameConfig()
        {
            Board = new BoardGame(8, 8);
            Turn = 1;
            CurrentPlayer = PieceColor.White;
            GameOver = false;
            Check = false;
            chessPieces = new HashSet<ChessPiece>();
            piecesCaptured = new HashSet<ChessPiece>();
            AddPiecesInGame();
        }
        //method to execute the movement of the pieces
        public ChessPiece ExecuteMovement(Position originalPosition, Position destinationPosition)
        {
            ChessPiece chessPiece = Board.RemovePiece(originalPosition);
            chessPiece.IncrementNumberOfMoves();
            ChessPiece CapturePiece = Board.RemovePiece(destinationPosition);
            Board.AddPieceInBoard(chessPiece, destinationPosition);
            if (CapturePiece != null)
            {
                piecesCaptured.Add(CapturePiece);
            }

            return CapturePiece;
        }
        // method to undo certain movement according to some situation and checkmate check
        public void UndoMove(Position originalPosition, Position destinationPosition, ChessPiece capturedPiece)
        {
            ChessPiece chessPiece = Board.RemovePiece(destinationPosition);
            chessPiece.DecrementNumberOfMoves();
            if (capturedPiece != null)
            {
                Board.AddPieceInBoard(capturedPiece, destinationPosition);
                piecesCaptured.Remove(capturedPiece);
            }
            Board.AddPieceInBoard(chessPiece, originalPosition);
        }
        //main method for executing check moves and checkmate and checkmate calls
        public void MakePlay(Position originalPosition, Position destinationPosition)
        {
            ChessPiece capturedPiece = ExecuteMovement(originalPosition, destinationPosition);
            if (ItIsInCheck(CurrentPlayer))
            {
                UndoMove(originalPosition, destinationPosition, capturedPiece);
                throw new BoardException("You can't put yourself in check!!!");
            }

            if (ItIsInCheck(Adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (TestCheckmate(Adversary(CurrentPlayer)))
            {
                GameOver = true;

            }
            else
            {
                Turn++;
                ChangePlayer();
            }
           
        }
        //method to change player turn
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
        //method to validate the initial position of the move
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
        //method to validate the destination position of the move
        public void ValidDestinationPosition(Position originalPosition, Position destinationPosition)
        {
            if (!Board.PiecePosition(originalPosition).CanMoveTo(destinationPosition))
            {
                throw new BoardException("Destination position invalid!!!");
            }
        }
        //method to check and store the captured pieces
        public HashSet<ChessPiece> CapturedPieces(PieceColor color)
        {
            HashSet<ChessPiece> aux = new HashSet<ChessPiece>();
            foreach (ChessPiece x in piecesCaptured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        //method to check and store the pieces in the game
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
        //method to check the opponent's color
        private PieceColor Adversary(PieceColor color)
        {
            if (color == PieceColor.White)
            {
                return PieceColor.Black;
            }
            else
            {
                return PieceColor.White;
            }
        }
        //method to check which piece is king
        private ChessPiece KingPiece(PieceColor color)
        {
            foreach (ChessPiece x in PiecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }
        //method to check if the player is in check
        public bool ItIsInCheck(PieceColor color)
        {
            ChessPiece king = KingPiece(color);

            if (king == null)
            {
                throw new BoardException("No have King in the Board, Game Over !!!");
                GameOver = true;
            }

            foreach (ChessPiece chessPiece in PiecesInGame(Adversary(color)))
            {
                bool[,] result = chessPiece.PossibleMoves();
                if (result[king.Position.Line, king.Position.Column])
                {
                    return true;
                }

            }
            return false;
        }
        //method to check if the player is in checkmate 
        public bool TestCheckmate(PieceColor color)
        {
            if (!ItIsInCheck(color))
            {
                return false;
            }

            foreach (ChessPiece aux in PiecesInGame(color))
            {
                bool[,] result = aux.PossibleMoves();
                for (int i = 0; i < Board.Line; i++)
                {
                    for (int j = 0; j < Board.Column; j++)
                    {
                        if (result[i, j])
                        {
                            Position origin = aux.Position;
                            Position destination = new Position(i, j);
                            ChessPiece capturedPiece = ExecuteMovement(origin, destination);
                            bool testCheck = ItIsInCheck(color);
                            UndoMove(origin, destination, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;


        }
        //method to add chess pieces
        public void AddNewPiece(char column, int line, ChessPiece piece)
        {
            Board.AddPieceInBoard(piece, new ChessPosition(column, line).ToPosition());
            chessPieces.Add(piece);

        }
        //method to add chess pieces to the board
        private void AddPiecesInGame()
        {
            AddNewPiece('a', 1, new Rook(Board, PieceColor.White));
            AddNewPiece('b', 1, new Knight(Board, PieceColor.White));
            AddNewPiece('c', 1, new Bishop(Board, PieceColor.White));
            AddNewPiece('d', 1, new Queen(Board, PieceColor.White));
            AddNewPiece('e', 1, new King(Board, PieceColor.White));
            AddNewPiece('f', 1, new Bishop(Board, PieceColor.White));
            AddNewPiece('g', 1, new Knight(Board, PieceColor.White));
            AddNewPiece('h', 1, new Rook(Board, PieceColor.White));
            AddNewPiece('a', 2, new Pawn(Board, PieceColor.White));
            AddNewPiece('b', 2, new Pawn(Board, PieceColor.White));
            AddNewPiece('c', 2, new Pawn(Board, PieceColor.White));
            AddNewPiece('d', 2, new Pawn(Board, PieceColor.White));
            AddNewPiece('e', 2, new Pawn(Board, PieceColor.White));
            AddNewPiece('f', 2, new Pawn(Board, PieceColor.White));
            AddNewPiece('g', 2, new Pawn(Board, PieceColor.White));
            AddNewPiece('h', 2, new Pawn(Board, PieceColor.White));

            AddNewPiece('a', 7, new Pawn(Board, PieceColor.Black));
            AddNewPiece('b', 7, new Pawn(Board, PieceColor.Black));
            AddNewPiece('c', 7, new Pawn(Board, PieceColor.Black));
            AddNewPiece('d', 7, new Pawn(Board, PieceColor.Black));
            AddNewPiece('e', 7, new Pawn(Board, PieceColor.Black));
            AddNewPiece('f', 7, new Pawn(Board, PieceColor.Black));
            AddNewPiece('g', 7, new Pawn(Board, PieceColor.Black));
            AddNewPiece('h', 7, new Pawn(Board, PieceColor.Black));
            AddNewPiece('a', 8, new Rook(Board, PieceColor.Black));
            AddNewPiece('b', 8, new Knight(Board, PieceColor.Black));
            AddNewPiece('c', 8, new Bishop(Board, PieceColor.Black));
            AddNewPiece('d', 8, new Queen(Board, PieceColor.Black));
            AddNewPiece('e', 8, new King(Board, PieceColor.Black));
            AddNewPiece('f', 8, new Bishop(Board, PieceColor.Black));
            AddNewPiece('g', 8, new Knight(Board, PieceColor.Black));
            AddNewPiece('h', 8, new Rook(Board, PieceColor.Black));


        }
    }
}
