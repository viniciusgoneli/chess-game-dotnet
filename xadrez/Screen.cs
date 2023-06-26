using System;
using xadrez.BoardLayer;

namespace xadrez
{
	public class Screen
	{
		public static void PrintBoard(Board board) {
			for(int i=0; i < board.Rows; i++) {
				for(int j=0;j<board.Columns; j++) {
					Piece p = board.GetPiece(i, j); 
					if(p == null)
					{
						Console.Write("- ");
					}
					else
					{
						Console.Write(p + " ");
					}
				}
				Console.WriteLine();
			}
		}
	}
}

