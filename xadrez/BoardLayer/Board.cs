using System;
namespace xadrez.BoardLayer
{
	public class Board
	{
		public int Rows { get; set; }
		public int Columns { get; set; }
		private Piece[,] Pieces;

        public Board(int rows, int columns)
		{
			Rows = rows;
			Columns = columns;
			Pieces = new Piece[rows, columns];
        }

		public Piece GetPiece(Position position)
		{
			return Pieces[position.Row, position.Column];
		}

        public Piece GetPiece(int row, int column)
        {
            return Pieces[row, column];
        }

        public void AddPieceToPosition(Piece piece, Position position)
		{
			ValidatePosition(position);
			Pieces[position.Row, position.Column] = piece;
			piece.Position = position;
		}

        public Piece RemovePieceFromPosition(Position position)
        {
			Piece p = Pieces[position.Row, position.Column];
			if (p == null) return null;
            Pieces[position.Row, position.Column] = null;
			p.Position = null;

			return p;
        }

        public bool IsThereAPiece(Position pos)
		{
            if (!CheckPositionIsInsideBounds(pos))
            {
                string msg = $"The position [{pos.Row},{pos.Column}] is outside the boundaries of the board.";
                throw new BoardException(msg);
            }

            return GetPiece(pos) != null;
		}

        public bool CheckPositionIsInsideBounds(Position pos)
		{
			return pos.Row < Rows &&
				pos.Row >= 0 &&
				pos.Column < Columns &&
				pos.Column >= 0;
		}

		public bool ValidatePosition(Position pos)
		{
			if(!CheckPositionIsInsideBounds(pos))
			{
				string msg = $"The position [{pos.Row},{pos.Column}] is outside the boundaries of the board.";
				throw new BoardException(msg);
			}
            if (IsThereAPiece(pos))
            {
                string msg = $"The position [{pos.Row},{pos.Column}] is already occupied by another piece.";
                throw new BoardException(msg);
            }

			return true;
        }
	}
}

