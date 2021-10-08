using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);

            var possibleMoves = new List<Square>();

            // Add vertical moves
            for (int pos = currentPosition.Row + 1; board.IsSquareInBoard(Square.At(pos, 0)); pos++)
            {
                possibleMoves.Add(Square.At(pos, currentPosition.Col));

                if (board.GetPiece(Square.At(pos, currentPosition.Col)) != null)
                    break;
            }
            
            for (int pos = currentPosition.Row - 1; board.IsSquareInBoard(Square.At(pos, 0)); pos--)
            {
                possibleMoves.Add(Square.At(pos, currentPosition.Col));

                if (board.GetPiece(Square.At(pos, currentPosition.Col)) != null)
                    break;
            }
            
            // Add horizontal moves
            for (int pos = currentPosition.Col + 1; board.IsSquareInBoard(Square.At(0, pos)); pos++)
            {
                possibleMoves.Add(Square.At(currentPosition.Row, pos));

                if (board.GetPiece(Square.At(currentPosition.Row, pos)) != null)
                    break;
            }
            
            for (int pos = currentPosition.Col - 1; board.IsSquareInBoard(Square.At(0, pos)); pos--)
            {
                possibleMoves.Add(Square.At(currentPosition.Row, pos));

                if (board.GetPiece(Square.At(currentPosition.Row, pos)) != null)
                    break;
            }

            // Remove moves that contain a friendly piece
            possibleMoves.RemoveAll(s => (board.GetPiece(s) != null) && (board.GetPiece(s).Player == Player));

            return possibleMoves;
        }
    }
}