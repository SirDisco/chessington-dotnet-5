using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public class ScoreCalculator
    {
        private IBoard _board;

        public ScoreCalculator(IBoard board)
        {
            _board = board;
        }

        public int GetScore(Player colour)
        {
            int totalScore = 0;
            foreach (var piece in _board.CapturedPieces)
            {
                if (piece.Player == colour)
                    totalScore += piece.PieceValue;
            }

            return totalScore;
        }

        public int GetWhiteScore()
        {
            return GetScore(Player.White);
        }
        
        public int GetBlackScore()
        {
            return GetScore(Player.Black);
        }
    }
}