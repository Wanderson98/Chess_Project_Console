using ChessProject.Board;
using ChessProject.Board.Enums;


namespace ChessProject.ChessGame
{
    //class for configuration of the "Pawn" piece, heir class of the chess piece class
    internal class Pawn : ChessPiece
    {
        //attribute for the Pawn to have access to the game and perform special moves
        private ChessGameConfig Config;
        //constructor
        public Pawn(BoardGame boardGame, PieceColor pieceColor, ChessGameConfig config) : base(pieceColor, boardGame)
        {
            Config = config;
        }
        //method to print the letter related to the piece
        public override string ToString()
        {
            return "P";
        }
        // class helper method to check if movement is possible
        private bool ThereIsEnemy(Position position)
        {
            ChessPiece piece = Board.PiecePosition(position);
            return piece != null && piece.Color != Color;
        }

        private bool FreePosition(Position position)
        {
            return Board.PiecePosition(position) == null;
        }
        private bool CanMove(Position position)
        {
            ChessPiece chessPiece = Board.PiecePosition(position);
            return chessPiece == null || chessPiece.Color != Color;
        }
        //method to check the possible moves of the chess piece
        public override bool[,] PossibleMoves()
        {
            bool[,] result = new bool[Board.Line, Board.Column];

            Position positionPawn = new Position(0, 0);

            if (Color == PieceColor.White)
            {
                positionPawn.SetValues(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(positionPawn) && FreePosition(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line - 2, Position.Column);
                Position position2 = new Position(Position.Line - 1, Position.Column);
                if (Board.ValidPosition(position2) && FreePosition(position2) &&
                    Board.ValidPosition(positionPawn) && FreePosition(positionPawn) && NumberOfMoves == 0)
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line - 1, Position.Column - 1);
                if (Board.ValidPosition(positionPawn) && ThereIsEnemy(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line - 1, Position.Column + 1);
                if (Board.ValidPosition(positionPawn) && ThereIsEnemy(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }

                //Special move En Passant with White Pawn

                if (Position.Line == 3)
                {
                    Position leftPosition = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(leftPosition) && ThereIsEnemy(leftPosition) && Board.PiecePosition(leftPosition) == Config.PieceEnPassant)
                    {
                        result[leftPosition.Line - 1, leftPosition.Column] = true;
                    }

                    Position rightPosition = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(rightPosition) && ThereIsEnemy(rightPosition) && Board.PiecePosition(rightPosition) == Config.PieceEnPassant)
                    {
                        result[rightPosition.Line - 1, rightPosition.Column] = true;
                    }
                }
            }
            else
            {
                positionPawn.SetValues(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(positionPawn) && FreePosition(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line + 2, Position.Column);
                Position position2 = new Position(Position.Line + 1, Position.Column);
                if (Board.ValidPosition(position2) && FreePosition(position2) &&
                    Board.ValidPosition(positionPawn) && FreePosition(positionPawn) && NumberOfMoves == 0)
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line + 1, Position.Column - 1);
                if (Board.ValidPosition(positionPawn) && ThereIsEnemy(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                positionPawn.SetValues(Position.Line + 1, Position.Column + 1);
                if (Board.ValidPosition(positionPawn) && ThereIsEnemy(positionPawn))
                {
                    result[positionPawn.Line, positionPawn.Column] = true;
                }
                //Special move En Passant with Black Pawn
                if (Position.Line == 4)
                {
                    Position leftPosition = new Position(Position.Line, Position.Column - 1);
                    if (Board.ValidPosition(leftPosition) && ThereIsEnemy(leftPosition) && Board.PiecePosition(leftPosition) == Config.PieceEnPassant)
                    {
                        result[leftPosition.Line + 1, leftPosition.Column] = true;
                    }

                    Position rightPosition = new Position(Position.Line, Position.Column + 1);
                    if (Board.ValidPosition(rightPosition) && ThereIsEnemy(rightPosition) && Board.PiecePosition(rightPosition) == Config.PieceEnPassant)
                    {
                        result[rightPosition.Line + 1, rightPosition.Column] = true;
                    }
                }
            }
            return result;

        }
    }
}
