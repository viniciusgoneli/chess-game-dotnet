using xadrez;
using xadrez.BoardLayer;
using xadrez.ChessLayer;

Board board = new Board(12, 12);

board.AddPiece(new King(board, Color.White), new Position(1, 4));
board.AddPiece(new Hook(board, Color.Black), new Position(4, 9));
board.AddPiece(new King(board, Color.White), new Position(7, 3));

Screen.PrintBoard(board);

Console.ReadLine();