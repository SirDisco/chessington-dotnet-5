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
            var oppositeColour = (Player == Player.Black) ? Player.White : Player.Black;

            var direction = (Player == Player.Black) ? 1 : -1;
            
            var possibleMoves = new List<Square>();

            // Simple Movement
            Square oneSquareInFront;
            Square twoSquaresInFront;

            Square diagonallyRight;
            Square diagonallyLeft;
            
            // Get movement squares
            oneSquareInFront = new Square(currentPosition.Row + direction, currentPosition.Col);
            twoSquaresInFront = new Square(currentPosition.Row + 2 * direction, currentPosition.Col);

            diagonallyLeft = new Square(currentPosition.Row + direction, currentPosition.Col - 1);
            diagonallyRight = new Square(currentPosition.Row + direction, currentPosition.Col + 1);
            
            // Check for blocking pieces
            if (board.GetPiece(oneSquareInFront) == null)
            {
                possibleMoves.Add(oneSquareInFront);
                
                if (PreviousPosition == null)
                    possibleMoves.Add(twoSquaresInFront);
            }
            
            // Remove positions where a piece already resides
            possibleMoves.RemoveAll((s => board.GetPiece(s) != null));
            
            // Pawns taking diagonally
            if (board.GetPiece(diagonallyLeft) != null && board.GetPiece(diagonallyLeft).Player == oppositeColour)
                possibleMoves.Add(diagonallyLeft);
            if (board.GetPiece(diagonallyRight) != null && board.GetPiece(diagonallyRight).Player == oppositeColour)
                possibleMoves.Add(diagonallyRight);

            return possibleMoves;
        }
    }
}