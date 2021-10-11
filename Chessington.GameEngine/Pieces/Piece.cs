using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        protected Piece(Player player)
        {
            Player = player;
            OppositeColour = (Player == Player.Black) ? Player.White : Player.Black;
        }

        public Player Player { get; private set; }
        public Player OppositeColour { get; private set; }
        public Square? PreviousPosition = null;

        public abstract int PieceValue { get; protected set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            PreviousPosition = currentSquare;
            board.MovePiece(currentSquare, newSquare);
        }
    }
}