using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);
            
            var possibleMoves = new List<Square>();

            if (Player == Player.White)
            {
                if (PreviousPosition == null)
                    possibleMoves.Add(new Square(currentPosition.Row - 2, currentPosition.Col));
                possibleMoves.Add(new Square(currentPosition.Row - 1, currentPosition.Col));
            }
            else if (Player == Player.Black)
            {
                if (PreviousPosition == null)
                    possibleMoves.Add(new Square(currentPosition.Row + 2, currentPosition.Col));
                possibleMoves.Add(new Square(currentPosition.Row + 1, currentPosition.Col));
            }

            return possibleMoves;
        }
    }
}