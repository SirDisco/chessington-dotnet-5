using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player)
        {
            _directions = new Tuple<int, int>[4];
            _directions[0] = new Tuple<int, int>(0, 1);
            _directions[1] = new Tuple<int, int>(1, 0);
            _directions[2] = new Tuple<int, int>(-1, 0);
            _directions[3] = new Tuple<int, int>(0, -1);
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);

            var possibleMoves = new List<Square>();

            foreach (var direction in _directions)
            {
                var row = currentPosition.Row + direction.Item1;
                var col = currentPosition.Col + direction.Item2;

                // Loop until we find the edge of the board
                while (board.IsSquareInBoard(Square.At(row, col)))
                {
                    var square = Square.At(row, col);
                    possibleMoves.Add(square);

                    if (board.GetPiece(square) != null)
                        break;

                    row += direction.Item1;
                    col += direction.Item2;
                }
            }

            // Remove moves that contain a friendly piece
            possibleMoves.RemoveAll(s => (board.GetPiece(s) != null) && (board.GetPiece(s).Player == Player));

            return possibleMoves;
        }

        public override int PieceValue { get; protected set; } = 5;
        private Tuple<int, int>[] _directions;
    }
}