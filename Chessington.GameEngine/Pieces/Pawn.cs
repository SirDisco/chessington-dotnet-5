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
            
            var possibleMoves = new List<Square>();

            // Simple Movement
            Square oneSquareInFront;
            Square twoSquaresInFront;

            Square diagonallyRight;
            Square diagonallyLeft;

            if (Player == Player.White)
            {
                oneSquareInFront = new Square(currentPosition.Row - 1, currentPosition.Col);
                twoSquaresInFront = new Square(currentPosition.Row - 2, currentPosition.Col);

                diagonallyLeft = new Square(currentPosition.Row - 1, currentPosition.Col - 1);
                diagonallyRight = new Square(currentPosition.Row - 1, currentPosition.Col + 1);
            }
            else
            {
                oneSquareInFront = new Square(currentPosition.Row + 1, currentPosition.Col);
                twoSquaresInFront = new Square(currentPosition.Row + 2, currentPosition.Col);
                
                diagonallyLeft = new Square(currentPosition.Row + 1, currentPosition.Col - 1);
                diagonallyRight = new Square(currentPosition.Row + 1, currentPosition.Col + 1);
            }

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
            if (board.GetPiece(diagonallyRight) != null && board.GetPiece(diagonallyLeft).Player == oppositeColour)
                possibleMoves.Add(diagonallyRight);

            return possibleMoves;
        }
    }
}