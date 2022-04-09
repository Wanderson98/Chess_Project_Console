using ChessProject.Board.Enums;

namespace ChessProject.Board
{
    abstract class ChessPiece
    {
        public Position Position { get; set; }
        public PieceColor Color { get; protected set; }
        public int NumberOfMoves { get; protected set; }
        public BoardGame Board { get; protected set; }

        public ChessPiece(PieceColor color, BoardGame board)
        {
            Position = null;
            Color = color;
            Board = board;
            NumberOfMoves = 0;
        }

        public void IncrementNumberOfMoves()
        {
            NumberOfMoves++;
        }

        public bool ThereIsPossibleMoves()
        {
            bool[,] result = PossibleMoves();
            for (int i = 0; i < Board.Line; i++)
            {
                for (int j = 0; j < Board.Column; j++)
                {
                    if(result[i,j])
                    {
                      return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Line, position.Column];
        }

        public abstract bool[,] PossibleMoves(); 
    }
}
