using System;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public abstract class ChessPiece : Piece
	{
		public ChessPiece(Board board, Color color) : base(board, color)
		{
        }

        protected void MarkOpponentPieceAsPossibleMoveIfExists(Position p, bool[,] mat)
        {
            if (Board.CheckPositionIsInsideBounds(p) && Board.IsThereAPiece(p)
                && Board.GetPiece(p).Color != Color)
            {
                mat[p.Row, p.Column] = true;
            }
        }
    }
}

