using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject.Board.Exceptions
{   //Exception class to the board game
    internal class BoardException : Exception
    {
        public BoardException(string message) : base(message)
        {

        }
    }
}
