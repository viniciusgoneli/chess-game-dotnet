using xadrez;
using xadrez.BoardLayer;
using xadrez.ChessLayer;

try
{
    Board board = new Board(8, 8);

    var chessPosition = new ChessPosition('f', 6);

    Console.WriteLine(chessPosition.ToPosition(board));
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadLine();