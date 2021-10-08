using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Windows.Input;

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

            Square oneSquareInFront;
            Square twoSquaresInFront;

            if (Player == Player.White)
            {
                oneSquareInFront = new Square(currentPosition.Row - 1, currentPosition.Col);
                twoSquaresInFront = new Square(currentPosition.Row - 2, currentPosition.Col);
            }
            else
            {
                oneSquareInFront = new Square(currentPosition.Row + 1, currentPosition.Col);
                twoSquaresInFront = new Square(currentPosition.Row + 2, currentPosition.Col);
            }

            if (board.GetPiece(oneSquareInFront) == null)
            {
                possibleMoves.Add(oneSquareInFront);
                
                if (PreviousPosition == null)
                    possibleMoves.Add(twoSquaresInFront);
            }

            // Remove positions where a piece already resides
            possibleMoves.RemoveAll((s => board.GetPiece(s) != null));

            return possibleMoves;
        }
    }
}