using ChessProject.Board.Enums;

namespace ChessProject.Board
{ // Generic class for creating chess pieces
    abstract class ChessPiece
    {   //attributes
        public Position Position { get; set; }
        public PieceColor Color { get; protected set; }
        public int NumberOfMoves { get; protected set; }
        public BoardGame Board { get; protected set; }
        //constructor
        public ChessPiece(PieceColor color, BoardGame board)
        {
            Position = null;
            Color = color;
            Board = board;
            NumberOfMoves = 0;
        }
        //increment the number of moves 
        public void IncrementNumberOfMoves()
        {
            NumberOfMoves++;
        }
        //decrement the number of moves 
        public void DecrementNumberOfMoves()
        {
            NumberOfMoves--;
        }
        //method to check if a movement is possible to be performed 
        public bool ThereIsPossibleMoves()
        {
            bool[,] result = PossibleMoves();
            for (int i = 0; i < Board.Line; i++)
            {
                for (int j = 0; j < Board.Column; j++)
                {
                    if (result[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //method to check if it is possible to move piece
        public bool CanMoveTo(Position position)
        {
            return PossibleMoves()[position.Line, position.Column];
        }
       
        public abstract bool[,] PossibleMoves();
    }
}
