using System;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public class Bishop : ChessPiece
	{

		public Bishop(Board board, Color color) : base(board, color)
		{
		}

        public override string ToString()
        {
            return "B";
        }
    }
}

