using System;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public class Rook : ChessPiece
	{

		public Rook(Board board, Color color) : base(board, color)
		{
		}

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] GetPossibleMoves()
        {
            bool[,] mat = new bool[Board.Rows, Board.Columns];

            Position p = new Position(Position.Row - 1, Position.Column);
            while (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;

                p.SetValues(p.Row - 1, p.Column);
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p = new Position(Position.Row + 1, Position.Column);
            while (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;

                p.SetValues(p.Row + 1, p.Column);
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p = new Position(Position.Row, Position.Column - 1);
            while (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;

                p.SetValues(p.Row, p.Column - 1);
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p = new Position(Position.Row, Position.Column + 1);
            while (Board.CheckPositionIsInsideBounds(p) && !Board.IsThereAPiece(p))
            {
                mat[p.Row, p.Column] = true;

                p.SetValues(p.Row, p.Column + 1);
            }
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            return mat;
        }
    }
}

