using System;
namespace xadrez.BoardLayer
{
	public abstract class Piece
	{
		public Position? Position { get; set; }
		public Color Color { get; protected set; }
		public Board Board { get; protected set; }
        public int MovesCount { get; set; }

        public Piece(Board board, Color color)
		{
			Position = null;
			Board = board;
			Color = color;
			MovesCount = 0;
		}

		public abstract bool[,] GetPossibleMoves();

		public bool GetPossibleMove()
		{
			return GetPossibleMoves()[Position.Row, Position.Column];
		}

    }
}

