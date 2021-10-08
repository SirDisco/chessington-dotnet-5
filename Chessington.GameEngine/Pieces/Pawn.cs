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
            var possibleMoves = new List<Square>();
            
            possibleMoves.Add(new Square(3, 0));
            possibleMoves.Add(new Square(5, 0));
            
            return possibleMoves;
        }
    }
}