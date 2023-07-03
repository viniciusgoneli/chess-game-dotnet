using System;
using System.Diagnostics.Metrics;
using xadrez.BoardLayer;
using xadrez.ChessLayer;

namespace xadrez
{
	public class Screen
	{
        public static void PrintMatch(ChessMatch chessMatch)
        {
			PrintBoard(chessMatch.GetPieces());
            PrintCapturedPieces(chessMatch.GetCapturedPieces());
            Console.WriteLine();
            Console.WriteLine($"Current player: {chessMatch.CurrentPlayer}");
            Console.WriteLine();
            if (chessMatch.isCheckMate) PrintCheckMate();
            else if (chessMatch.isCheck) PrintCheck();
            Console.WriteLine();
        }

        private static void PrintCapturedPieces(List<ChessPiece> capturedPieces)
        {
            List<ChessPiece> white = capturedPieces.FindAll(it => it.Color == Color.White);
            List<ChessPiece> black = capturedPieces.FindAll(it => it.Color == Color.Black);

            Console.Write("Captured Pieces by Player WHITE: [");
            Console.Write(String.Join(",", black));
            Console.Write("]\n");

            Console.Write("Captured Pieces by Player BLACK: [");
            Console.Write(String.Join(",", white));
            Console.Write("]\n");
        }

        private static void PrintCheckMate()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"CHECK MATE");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintCheck()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"CHECK");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintBoard(ChessPiece[,] chessPieces)
        {
            int length = Convert.ToInt32(Math.Sqrt(chessPieces.Length));

            for (int i = 0; i < length; i++)
            {
                Console.Write(length - i);
                for (int j = 0; j < length; j++)
                {
                    ChessPiece p = chessPieces[i, j];
                    if (p == null)
                    {
                        Console.Write(" -");
                    }
                    else
                    {
                        PrintPiece(p);
                    }
                }
                Console.WriteLine();
            }
            PrintBoardFooterLetters(length);
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void PrintPiece(ChessPiece p)
        {
            if (p.Color == Color.Black)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.Write(" " + p);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void PrintBoardFooterLetters(int columns)
        {
            Console.Write("  ");

            for (int i = 0; i < columns; i++)
            {
                int aLetterCode = 97;
                char letter = Convert.ToChar(aLetterCode + i);
                Console.Write(letter + " ");
            }
        }

        public static void Clear()
        {
            Console.Clear();
        }

        public static ChessPosition ConvertInputToChessPosition(string value)
        {
            char column = Convert.ToChar(value.Substring(0, 1));
            int row = Convert.ToInt32(value.Substring(1));

            return new ChessPosition(column, row);
        }

        public static void PrintBoard(ChessPiece[,] chessPieces, bool[,] possibleMoves)
        {
            int length = Convert.ToInt32(Math.Sqrt(chessPieces.Length));

            for (int i = 0; i < length; i++)
            {
                Console.Write(length - i);
                for (int j = 0; j < length; j++)
                {
                    ChessPiece p = chessPieces[i, j];
                    if (p == null)
                    {
                        if (possibleMoves[i,j])
                        {
                            PrintTraceWithBackgroundColor();
                        }
                        else
                        {
                            Console.Write(" -");
                        }
                    }
                    else
                    {
                        if (possibleMoves[i, j])
                        {
                            PrintPieceWithBackgroundColor(p);
                        }
                        else
                        {
                            PrintPiece(p);
                        }
                    }
                }
                Console.WriteLine();
            }
            PrintBoardFooterLetters(length);
            Console.WriteLine();
            Console.WriteLine();
        }

        private static void PrintPieceWithBackgroundColor(ChessPiece p)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Blue;

            PrintPiece(p);

            Console.BackgroundColor = defaultColor;
        }

        private static void PrintTraceWithBackgroundColor()
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write("-");
            Console.BackgroundColor = defaultColor;
        }
	}
}

