using System;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public class Knight : ChessPiece
	{

		public Knight(Board board, Color color) : base(board, color)
		{
		}

        public override string ToString()
        {
            return "N";
        }
    }
}

