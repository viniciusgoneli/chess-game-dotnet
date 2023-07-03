using System;

namespace xadrez.BoardLayer
{
	public class Position
	{
		public int Row { get; set; }
		public int Column { get; set; }

        public Position(int row, int column)
		{
			Row = row;
			Column = column;
		}

        public override string ToString()
        {
			return $"{Row}, {Column}";
        }

		public void SetValues(Position position)
		{
			Row = position.Row;
			Column = position.Column;
		}

        public void SetValues(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}

