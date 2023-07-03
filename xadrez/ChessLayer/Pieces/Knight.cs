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

        public override bool[,] GetPossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position p = new Position(0, 0);

            // Top
            p.SetValues(Position.Row - 2, Position.Column - 1);
            if(Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p.SetValues(Position.Row - 2, Position.Column + 1);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);
            // ------------------------------------------------------------------- //

            // Right
            p.SetValues(Position.Row - 1, Position.Column + 2);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p.SetValues(Position.Row + 1, Position.Column + 2);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);
            // ------------------------------------------------------------------- //

            // Down
            p.SetValues(Position.Row + 2, Position.Column - 1);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p.SetValues(Position.Row + 2, Position.Column + 1);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);
            // ------------------------------------------------------------------- //

            // Left
            p.SetValues(Position.Row + 1, Position.Column - 2);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p.SetValues(Position.Row - 1, Position.Column - 2);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);
            // ------------------------------------------------------------------- //

            return mat;
        }
    }
}

