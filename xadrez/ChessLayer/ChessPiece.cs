using System;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public abstract class ChessPiece : Piece
	{
		public ChessPiece(Board board, Color color) : base(board, color)
		{
		}
	}
}

