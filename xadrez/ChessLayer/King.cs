using System;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public class King : Piece
	{
		public King(Board board, Color color) : base(board, color)
		{
		}

        public override string ToString()
        {
            return "K";
        }
    }
}

