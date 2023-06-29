using System;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public class Pawn : ChessPiece
	{

		public Pawn(Board board, Color color) : base(board, color)
		{
		}

        public override string ToString()
        {
            return "P";
        }
    }
}

