using ChessProject.Board;
using ChessProject.Board.Enums;

namespace ChessProject.ChessGame
{//class for configuration of the "Queen" piece, heir class of the chess piece class
    internal class Queen : ChessPiece
    {
        
        //constructor
        public Queen(BoardGame boardGame, PieceColor pieceColor) : base(pieceColor, boardGame)
        {
        }
       
        //method to print the letter related to the piece
        public override string ToString()
        {
            return "Q";
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

            Position positionQueen = new Position(0, 0);

            // Left
            positionQueen.SetValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(positionQueen) && CanMove(positionQueen))
            {
                result[positionQueen.Line, positionQueen.Column] = true;
                if (Board.PiecePosition(positionQueen) != null && Board.PiecePosition(positionQueen).Color != Color)
                {
                    break;
                }
                positionQueen.SetValues(positionQueen.Line, positionQueen.Column - 1);
            }
            // Right
            positionQueen.SetValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(positionQueen) && CanMove(positionQueen))
            {
                result[positionQueen.Line, positionQueen.Column] = true;
                if (Board.PiecePosition(positionQueen) != null && Board.PiecePosition(positionQueen).Color != Color)
                {
                    break;
                }
                positionQueen.SetValues(positionQueen.Line, positionQueen.Column + 1);
            }
            // UP
            positionQueen.SetValues(Position.Line - 1, Position.Column);
            while (Board.ValidPosition(positionQueen) && CanMove(positionQueen))
            {
                result[positionQueen.Line, positionQueen.Column] = true;
                if (Board.PiecePosition(positionQueen) != null && Board.PiecePosition(positionQueen).Color != Color)
                {
                    break;
                }
                positionQueen.SetValues(positionQueen.Line - 1, positionQueen.Column);
            }
            // Down
            positionQueen.SetValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(positionQueen) && CanMove(positionQueen))
            {
                result[positionQueen.Line, positionQueen.Column] = true;
                if (Board.PiecePosition(positionQueen) != null && Board.PiecePosition(positionQueen).Color != Color)
                {
                    break;
                }
                positionQueen.SetValues(positionQueen.Line + 1, positionQueen.Column);
            }
            // NorthWest
            positionQueen.SetValues(Position.Line - 1, Position.Column - 1);
            while (Board.ValidPosition(positionQueen) && CanMove(positionQueen))
            {
                result[positionQueen.Line, positionQueen.Column] = true;
                if (Board.PiecePosition(positionQueen) != null && Board.PiecePosition(positionQueen).Color != Color)
                {
                    break;
                }
                positionQueen.SetValues(positionQueen.Line - 1, positionQueen.Column -1 );
            }
            // NorthEast
            positionQueen.SetValues(Position.Line - 1, Position.Column + 1);
            while (Board.ValidPosition(positionQueen) && CanMove(positionQueen))
            {
                result[positionQueen.Line, positionQueen.Column] = true;
                if (Board.PiecePosition(positionQueen) != null && Board.PiecePosition(positionQueen).Color != Color)
                {
                    break;
                }
                positionQueen.SetValues(positionQueen.Line - 1, positionQueen.Column + 1);
            }
            // SouthEast
            positionQueen.SetValues(Position.Line + 1, Position.Column + 1);
            while (Board.ValidPosition(positionQueen) && CanMove(positionQueen))
            {
                result[positionQueen.Line, positionQueen.Column] = true;
                if (Board.PiecePosition(positionQueen) != null && Board.PiecePosition(positionQueen).Color != Color)
                {
                    break;
                }
                positionQueen.SetValues(positionQueen.Line + 1, positionQueen.Column + 1);
            }
            // SouthWest
            positionQueen.SetValues(Position.Line + 1, Position.Column - 1);
            while (Board.ValidPosition(positionQueen) && CanMove(positionQueen))
            {
                result[positionQueen.Line, positionQueen.Column] = true;
                if (Board.PiecePosition(positionQueen) != null && Board.PiecePosition(positionQueen).Color != Color)
                {
                    break;
                }
                positionQueen.SetValues(positionQueen.Line + 1, positionQueen.Column - 1);
            }



            return result;
        }
    }
}
