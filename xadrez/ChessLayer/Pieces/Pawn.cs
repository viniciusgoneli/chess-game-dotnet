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

        public override bool[,] GetPossibleMoves()
        {
            Position p = new Position(0, 0);

            bool[,] mat = new bool[Board.Rows, Board.Columns];

            int dir = Color == Color.White ? 1 : -1;

            p.SetValues(Position.Row - 1 * dir, Position.Column);
            if (Board.CheckPositionIsInsideBounds(p) && !Board.IsPositionOccupied(p))
            {
                mat[p.Row, p.Column] = true;

                p.SetValues(p.Row - 1 * dir, p.Column);
                if(MovesCount == 0 && !Board.IsPositionOccupied(p))
                {
                    mat[p.Row, p.Column] = true;
                }
            }

            p.SetValues(Position.Row - 1 * dir, Position.Column + 1);
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            p.SetValues(Position.Row - 1 * dir, Position.Column - 1);
            MarkOpponentPieceAsPossibleMoveIfExists(p, mat);

            return mat;
        }
    }
}

