using ChessProject.Board;
using ChessProject.Board.Enums;


namespace ChessProject.ChessGame
{
    //class for configuration of the "King" piece, heir class of the chess piece class
    internal class King : ChessPiece
    {   //attribute for the King to have access to the game and perform special moves
        private ChessGameConfig Config;
        //constructor
        public King(BoardGame boardGame, PieceColor pieceColor, ChessGameConfig config) : base(pieceColor, boardGame)
        {
            Config = config;
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

        private bool RookTestCastle(Position position)
        {
            ChessPiece rook = Board.PiecePosition(position);
            if (rook != null && rook is Rook && rook.Color == Color && rook.NumberOfMoves == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
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

            //special move Castling
            if (NumberOfMoves == 0 && !Config.Check)
            {
                Position rookPosition = new Position(Position.Line, Position.Column + 3);

                if (RookTestCastle(rookPosition))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1); 
                    Position p2 = new Position(Position.Line, Position.Column + 2);

                    if (Board.PiecePosition(p1) == null && Board.PiecePosition(p2) == null)
                    {
                        result[Position.Line, Position.Column + 2] = true;
                    }
                }

                Position rookPosition2 = new Position(Position.Line, Position.Column - 4);

                if (RookTestCastle(rookPosition2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);

                    if (Board.PiecePosition(p1) == null && Board.PiecePosition(p2) == null && Board.PiecePosition(p3) == null)
                    {
                        result[Position.Line, Position.Column - 2] = true;
                    }
                }


            }

            return result;
        }
    }
}