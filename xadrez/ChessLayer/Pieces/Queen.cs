using System;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public class Queen : ChessPiece
	{

		public Queen(Board board, Color color) : base(board, color)
		{
		}

        public override string ToString()
        {
            return "Q";
        }
    }
}

