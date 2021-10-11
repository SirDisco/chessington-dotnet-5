using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player)
        {
            _directions = new Tuple<int, int>[8];
            _directions[0] = new Tuple<int, int>(1, 1);
            _directions[1] = new Tuple<int, int>(1, -1);
            _directions[2] = new Tuple<int, int>(-1, 1);
            _directions[3] = new Tuple<int, int>(-1, -1);
            
            _directions[4] = new Tuple<int, int>(1, 0);
            _directions[5] = new Tuple<int, int>(-1, 0);
            _directions[6] = new Tuple<int, int>(0, 1);
            _directions[7] = new Tuple<int, int>(0, -1);
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);

            var possibleMoves = new List<Square>();

            foreach (var direction in _directions)
            {
                var row = currentPosition.Row + direction.Item1;
                var col = currentPosition.Col + direction.Item2;

                var square = Square.At(row, col);
                possibleMoves.Add(square);
            }

            // Remove moves that contain a friendly piece
            possibleMoves.RemoveAll(s => (board.GetPiece(s) != null) && (board.GetPiece(s).Player == Player));

            return possibleMoves;
        }

        public override int PieceValue => Int32.MaxValue;
        private Tuple<int, int>[] _directions;
    }
}