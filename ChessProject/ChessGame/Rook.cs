using ChessProject.Board;
using ChessProject.Board.Enums;


namespace ChessProject.ChessGame
{   //class for configuration of the "Rook" piece, heir class of the chess piece class
    internal class Rook : ChessPiece
    {   //constructor
        public Rook(BoardGame boardGame, PieceColor pieceColor) : base(pieceColor, boardGame)
        {
        }
        //method to print the letter related to the piece
        public override string ToString()
        {
            return "R";
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

            Position positionRook = new Position(0, 0);
            //Up 
            positionRook.SetValues(Position.Line - 1, Position.Column);
            while(Board.ValidPosition(positionRook) && CanMove(positionRook))
            {
                result[positionRook.Line, positionRook.Column] = true;
                if(Board.PiecePosition(positionRook) != null && Board.PiecePosition(positionRook).Color != Color)
                {
                    break;
                }
                positionRook.Line = positionRook.Line - 1;
            }

            //Right
            positionRook.SetValues(Position.Line, Position.Column + 1);
            while (Board.ValidPosition(positionRook) && CanMove(positionRook))
            {
                result[positionRook.Line, positionRook.Column] = true;
                if (Board.PiecePosition(positionRook) != null && Board.PiecePosition(positionRook).Color != Color)
                {
                    break;
                }
                positionRook.Column = positionRook.Column + 1;
            }

            //Down
            positionRook.SetValues(Position.Line + 1, Position.Column);
            while (Board.ValidPosition(positionRook) && CanMove(positionRook))
            {
                result[positionRook.Line, positionRook.Column] = true;
                if (Board.PiecePosition(positionRook) != null && Board.PiecePosition(positionRook).Color != Color)
                {
                    break;
                }
                positionRook.Line = positionRook.Line + 1;
            }

            //Left 
            positionRook.SetValues(Position.Line, Position.Column - 1);
            while (Board.ValidPosition(positionRook) && CanMove(positionRook))
            {
                result[positionRook.Line, positionRook.Column] = true;
                if (Board.PiecePosition(positionRook) != null && Board.PiecePosition(positionRook).Color != Color)
                {
                    break;
                }
                positionRook.Column = positionRook.Column - 1;
            }

            return result;
        }

    }
}
