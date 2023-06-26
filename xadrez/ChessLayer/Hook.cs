using System;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public class Hook : Piece
	{

		public Hook(Board board, Color color) : base(board, color)
		{
		}

        public override string ToString()
        {
            return "H";
        }
    }
}

