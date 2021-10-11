using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player)
        {
            _relativeMoves = new List<Tuple<int, int>>();
            
            _relativeMoves.Add(new Tuple<int, int>(1, 2));
            _relativeMoves.Add(new Tuple<int, int>(2, 1));
            _relativeMoves.Add(new Tuple<int, int>(2, -1));
            _relativeMoves.Add(new Tuple<int, int>(1, -2));
            
            _relativeMoves.Add(new Tuple<int, int>(-1, -2));
            _relativeMoves.Add(new Tuple<int, int>(-2, -1));
            _relativeMoves.Add(new Tuple<int, int>(-2, 1));
            _relativeMoves.Add(new Tuple<int, int>(-1, 2));
        }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentPosition = board.FindPiece(this);

            var possibleMoves = new List<Square>();

            // Get all possible squares in the board
            foreach (var move in _relativeMoves)
            {
                var absolutePosition = new Square(currentPosition.Row + move.Item1,
                    currentPosition.Col + move.Item2);
                
                if (board.IsSquareInBoard(absolutePosition))
                    possibleMoves.Add(absolutePosition);
            }

            // Remove moves that contain a friendly piece
            possibleMoves.RemoveAll(s => (board.GetPiece(s) != null) && (board.GetPiece(s).Player == Player));

            return possibleMoves;
        }

        public override int PieceValue { get; protected set; } = 3;
        private List<Tuple<int, int>> _relativeMoves;
    }
}