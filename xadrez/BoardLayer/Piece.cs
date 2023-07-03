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

		public bool CheckIsPossibleMoveToPosition(Position position)
		{
			return GetPossibleMoves()[position.Row, position.Column];
		}

		public bool IsThereAnyPossibleMovement()
		{
			bool[,] possibleMoves = GetPossibleMoves();
			int length = Convert.ToInt32(Math.Sqrt(possibleMoves.Length));

			for(int i = 0; i < length; i++)
			{
				for(int j = 0; j < length; j++)
				{
					if (possibleMoves[i,j])
					{
						return true;
					}
				}
			}

			return false;
		}
    }
}

