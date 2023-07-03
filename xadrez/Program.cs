using xadrez;
using xadrez.BoardLayer;
using xadrez.ChessLayer;


ChessMatch chessMatch = new ChessMatch();

while (true)
{
    try
    {
        Screen.Clear();
        Screen.PrintMatch(chessMatch);

        Console.Write("Source: ");
        ChessPosition source = Screen.ConvertInputToChessPosition(Console.ReadLine());

        chessMatch.validateSourcePosition(source.ToPosition());

        Screen.Clear();
        Screen.PrintBoard(chessMatch.GetPieces(), chessMatch.GetPossibleMoves(source));

        Console.Write("Target: ");
        ChessPosition target = Screen.ConvertInputToChessPosition(Console.ReadLine());

        chessMatch.validateTargetPosition(source.ToPosition(), target.ToPosition());

        ChessPiece? capturedPiece = chessMatch.MovePiece(source, target);

        if (capturedPiece != null)
        {
            chessMatch.GetCapturedPieces().Add(capturedPiece);
            chessMatch.GetPiecesOnTheBoard().Remove(capturedPiece);
        }

        bool isCheck = chessMatch.TestCheck(chessMatch.GetOpponent());
        chessMatch.isCheck = isCheck;

        if (isCheck) {
            bool isCheckMate = chessMatch.TestCheckMate(chessMatch.GetOpponent());
            chessMatch.isCheckMate = isCheckMate;
        }

        chessMatch.PassToNextTurn();
    }
    catch (ChessException ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.ReadLine();
    }
}
