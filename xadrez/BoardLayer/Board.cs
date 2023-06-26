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

		public void AddPiece(Piece piece, Position position)
		{
			ValidatePosition(position);
			Pieces[position.Row, position.Column] = piece;
		}

		public bool IsPositionOccupied(Position pos)
		{
			return GetPiece(pos) != null;
		}

		public bool CheckPositionIsInsideBounds(Position pos)
		{
			return pos.Row < Rows &&
				pos.Row >= 0 &&
				pos.Column < Columns &&
				pos.Column >= 0;
		}

		public void ValidatePosition(Position pos)
		{
			if(!CheckPositionIsInsideBounds(pos))
			{
				string msg = $"The position [{pos.Row},{pos.Column}] is outside the boundaries of the board.";
				throw new BoardException(msg);
			}
            if (IsPositionOccupied(pos))
            {
                string msg = $"The position [{pos.Row},{pos.Column}] is already occupied by another part.";
                throw new BoardException(msg);
            }
        }
	}
}

