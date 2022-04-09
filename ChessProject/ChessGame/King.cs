using ChessProject.Board;
using ChessProject.Board.Enums;


namespace ChessProject.ChessGame
{
    //class for configuration of the "King" piece, heir class of the chess piece class
    internal class King : ChessPiece
    {
        //constructor
        public King(BoardGame boardGame, PieceColor pieceColor) : base(pieceColor, boardGame)
        {
        }
        //method to print the letter related to the piece
        public override string ToString()
        {
            return "K";
        }
        // class helper method to check if movement is possible
        private bool CanMove(Position position)
        {
            ChessPiece chessPiece = Board.PiecePosition(position);
            return chessPiece == null || chessPiece.Color != Color;
        }
        //method to check the possible moves of the chess piece
        public override bool[,] PossibleMoves()
        {
            bool[,] result = new bool[Board.Line, Board.Column];

            Position positionKing = new Position(0, 0);
            //Up 
            positionKing.SetValues(Position.Line - 1, Position.Column);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            //NorthEast
            positionKing.SetValues(Position.Line - 1, Position.Column + 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true; ;
            }
            //Right
            positionKing.SetValues(Position.Line, Position.Column + 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true; ;
            }
            //SouthEast
            positionKing.SetValues(Position.Line + 1, Position.Column + 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            //Down
            positionKing.SetValues(Position.Line + 1, Position.Column);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            //SouthWest
            positionKing.SetValues(Position.Line + 1, Position.Column - 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            //Left 
            positionKing.SetValues(Position.Line, Position.Column - 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            //NorthWest
            positionKing.SetValues(Position.Line - 1, Position.Column - 1);
            if (Board.ValidPosition(positionKing) && CanMove(positionKing))
            {
                result[positionKing.Line, positionKing.Column] = true;
            }
            return result;
        }
    }
}
