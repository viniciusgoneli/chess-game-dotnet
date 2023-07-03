using System;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public class King : ChessPiece
	{
		public King(Board board, Color color) : base(board, color)
		{
		}

        public override string ToString()
        {
            return "K";
        }

        public override bool[,] GetPossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position p = new Position(Position.Row - 1, Position.Column);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p = new Position(Position.Row - 1, Position.Column + 1);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p = new Position(Position.Row, Position.Column + 1);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p = new Position(Position.Row + 1, Position.Column + 1);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p = new Position(Position.Row + 1, Position.Column);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p = new Position(Position.Row + 1, Position.Column - 1);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p = new Position(Position.Row, Position.Column - 1);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p = new Position(Position.Row - 1, Position.Column - 1);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            return mat;
        }
    }
}

