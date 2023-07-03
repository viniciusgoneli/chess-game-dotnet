using System;
using System.Net.NetworkInformation;
using xadrez.BoardLayer;

namespace xadrez.ChessLayer
{
	public class ChessMatch
	{
        public Color CurrentPlayer { get; private set; }
        public int Turns { get; private set; }
        private List<Piece> CapturedPieces;
        private List<Piece> PiecesOnTheBoard;
        public bool isCheck { get; set; }
        public bool isCheckMate { get; set; }

        private Board Board;

		public ChessMatch()
		{
			Board = new Board(8, 8);
            CurrentPlayer = Color.White;
            Turns = 0;
            CapturedPieces = new List<Piece>();
            PiecesOnTheBoard = new List<Piece>();
            isCheck = false;
            isCheckMate = false;
            PerformInitialSetup();
        }

        public List<ChessPiece> GetCapturedPieces() {
            List<ChessPiece> capturedChessPieces = new List<ChessPiece>();
            foreach(Piece p in CapturedPieces) {
                ChessPiece? chessPiece = p as ChessPiece;
                if(chessPiece != null) {
                    capturedChessPieces.Add(chessPiece);
                }
            }

            return capturedChessPieces;
        }

        public List<ChessPiece> GetPiecesOnTheBoard()
        {
            List<ChessPiece> chessPiecesOnTheBoard = new List<ChessPiece>();
            foreach (Piece p in PiecesOnTheBoard)
            {
                ChessPiece? chessPiece = p as ChessPiece;
                if (chessPiece != null)
                {
                    chessPiecesOnTheBoard.Add(chessPiece);
                }
            }

            return chessPiecesOnTheBoard;
        }

        public void validateSourcePosition(Position position)
        {
            if (!Board.IsThereAPiece(position))
            {
                throw new ChessException("There is no piece on source position");
            }
            if (CurrentPlayer != Board.GetPiece(position).Color)
            {
                throw new ChessException("The chosen piece is not yours.");
            }
            if (!Board.GetPiece(position).IsThereAnyPossibleMovement())
            {
                throw new ChessException("There is no possible moves for the chosen piece");
            }
        }

        public void validateTargetPosition(Position source, Position target)
        {
            if (!Board.GetPiece(source).CheckIsPossibleMoveToPosition(target))
            {
                throw new ChessException("This piece can't move to chosen position.");
            }
        }

        public ChessPiece? MovePiece(ChessPosition source, ChessPosition target)
        {
            return MovePiece(source.ToPosition(), target.ToPosition());
        }

        private ChessPiece? MovePiece(Position source, Position target)
        {
            Piece p = Board.RemovePieceFromPosition(source);
            Piece capturedPiece = Board.RemovePieceFromPosition(target);

            Board.AddPieceToPosition(p, target);

            if (TestCheck(CurrentPlayer))
            {
                UndoMove(source, target, capturedPiece);
                throw new ChessException("You can't put youself in CHECK!");
            }

            p.MovesCount += 1;

            return capturedPiece as ChessPiece;
        }

        private void UndoMove(Position source, Position target, Piece? capturedPiece)
        {
            Piece p = Board.RemovePieceFromPosition(target);
            Board.AddPieceToPosition(p, source);

            p.MovesCount--;

            if (capturedPiece != null)
            {
                Board.AddPieceToPosition(capturedPiece, target);
                PiecesOnTheBoard.Add(capturedPiece);
                CapturedPieces.Remove(capturedPiece);
            }
        }

        public ChessPiece[,] GetPieces()
        {
            ChessPiece[,] chessPieces = new ChessPiece[Board.Rows, Board.Columns];
            for(int i = 0; i < Board.Rows; i++)
            {
                for(int j = 0; j < Board.Columns; j++)
                {
                    chessPieces[i, j] = (ChessPiece) Board.GetPiece(new Position(i, j));
                }
            }

            return chessPieces;
        }

        public bool[,] GetPossibleMoves(ChessPosition source)
        {
            Piece p = Board.GetPiece(source.ToPosition());

            return p.GetPossibleMoves();
        }

        public void PassToNextTurn()
        {
            Turns++;
            CurrentPlayer = GetOpponent();
        }

        public Color GetOpponent()
        {
            return CurrentPlayer == Color.White ? Color.Black : Color.White;
        }

        public bool TestCheck(Color color)
        {
            King? king = GetKingByColor(color);

            if (king == null)
            {
                throw new ChessException("King not found on the board.");
            }

            List<Piece> opponentPieces = PiecesOnTheBoard.FindAll(p => p.Color != CurrentPlayer);

            for(int i = 0; i < Board.Rows; i++) {
                for(int j = 0; j < Board.Columns; j++) {
                    Piece p = Board.GetPiece(i, j);
                    if(p != null) {
                        bool isPossibleMove = p.CheckIsPossibleMoveToPosition(king.Position);
                        if (isPossibleMove) return true;
                    }
                }
            }

            return false;
        }

        private King? GetKingByColor(Color color)
        {
            foreach (Piece p in PiecesOnTheBoard)
            {
                if (p.Color == color && p is King)
                {
                    return p as King;
                }
            }

            return null;
        }

        public bool TestCheckMate(Color color)
        {
            King? opponentKing = GetKingByColor(color);

            if (opponentKing == null)
            {
                throw new ChessException("King not found on the board.");
            }

            bool[,] kingPossibleMoves = opponentKing.GetPossibleMoves();

            Position source = opponentKing.Position;
            Position target = new Position(0, 0);
            for(int i = 0; i < Board.Rows; i++) {
                for (int j = 0; j < Board.Columns; j++) {
                    if (kingPossibleMoves[i, j]) {
                        target.SetValues(i, j);
                        Piece? capturedPiece = MovePiece(source, target);
                        bool check = TestCheck(color);
                        UndoMove(source, target, capturedPiece);
                        if (!check) return false;
                    }
                }
            }

            return true;
        }

        private void PerformInitialSetup()
		{
            AddPiecesToTheirInitialPosition();
		}

        private void AddPiecesToTheirInitialPosition()
		{
			PopulateRow(8, Color.Black);
            PopulateRow(1, Color.White);

            for (int i = 0; i < Board.Columns; i++)
			{
                int aLetterCode = 97;
                char letter = Convert.ToChar(aLetterCode + i);

                Piece blackPawn = new Pawn(Board, Color.Black);
                Piece whitePawn = new Pawn(Board, Color.White);

                //Board.AddPieceToPosition(blackPawn, new ChessPosition(letter, 7)
                //    .ToPosition());

                Board.AddPieceToPosition(whitePawn, new ChessPosition(letter, 2)
                    .ToPosition());

                PiecesOnTheBoard.Add(whitePawn);
                PiecesOnTheBoard.Add(blackPawn);
            }
        }

		private void PopulateRow(int chessRow, Color color)
		{
            PlaceNewPiece(new Rook(Board, color), new ChessPosition('a', chessRow));
            PlaceNewPiece(new Knight(Board, color), new ChessPosition('b', chessRow));
            PlaceNewPiece(new Bishop(Board, color), new ChessPosition('c', chessRow));
            PlaceNewPiece(new King(Board, color), new ChessPosition('d', chessRow));
            PlaceNewPiece(new Queen(Board, color), new ChessPosition('e', chessRow));
            PlaceNewPiece(new Bishop(Board, color), new ChessPosition('f', chessRow));
            PlaceNewPiece(new Knight(Board, color), new ChessPosition('g', chessRow));
            PlaceNewPiece(new Rook(Board, color), new ChessPosition('h', chessRow));
        }

        private void PlaceNewPiece(ChessPiece piece, ChessPosition position)
        {
            Board.AddPieceToPosition(piece, position.ToPosition());
            PiecesOnTheBoard.Add(piece);
        }
    }
}

