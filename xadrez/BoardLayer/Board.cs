﻿using System;
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

		public Piece GetPiece(int row, int column)
		{
			return Pieces[row, column];
		}

		public void AddPiece(Piece piece, Position position)
		{
			Pieces[position.Row, position.Column] = piece;
		}
	}
}

