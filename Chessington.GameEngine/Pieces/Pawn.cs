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
                possibleMoves.Add(new Square(3, 0));
            else if (Player == Player.Black)
                possibleMoves.Add(new Square(5, 0));

            return possibleMoves;
        }
    }
}