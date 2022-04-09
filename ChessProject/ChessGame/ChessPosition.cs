using ChessProject.Board;

namespace ChessProject.ChessGame
{   //method to create a chess board
    internal class ChessPosition
    {
        //attributes
        public char Column { get; set; }
        public int Line { get; set; }
        //constructor
        public ChessPosition(char column, int line)
        {
            Column = column;
            Line = line;
        }
        //method to convert chessboard coordinates to related positions in matrix
        public Position ToPosition()
        {
            return new Position(8 - Line, Column - 'a'); 
        }
        //method to print chessboard dice
        public override string ToString()
        {
            return "" + Column + Line;
        }
    }
}
