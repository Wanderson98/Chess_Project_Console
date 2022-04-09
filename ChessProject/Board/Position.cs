
namespace ChessProject.Board
{//class to manage the positions of chess pieces
    internal class Position
    {   //attributes
        public int Line { get; set; }
        public int Column { get; set; }
        //constructor
        public Position(int line, int column)
        {
            Line = line;
            Column = column;
        }
        //method to set row and column values ​​in chess pieces move setup
        public void SetValues(int line, int column)
        {
            Line = line;
            Column = column;
        }
        //method to print position
        public override string ToString()
        {
            return Line + ", " + Column; ;
        }
    }
}
