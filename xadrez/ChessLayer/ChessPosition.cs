using System;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public class ChessPosition
	{
        public char Column { get; set; }
        public int Row { get; set; }

		public ChessPosition(char column, int row)
		{
			Column = column;
            Row = row;
        }

        public Position ToPosition(Board board)
		{
			return new Position(board.Rows - Row, Column - 'a');
		}
	}
}

