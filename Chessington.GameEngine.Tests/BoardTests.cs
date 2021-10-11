using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void PawnCanBeAddedToBoard()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(0, 0), pawn);

            board.GetPiece(Square.At(0, 0)).Should().BeSameAs(pawn);
        }

        [Test]
        public void PawnCanBeFoundOnBoard()
        {
            var board = new Board();
            var pawn = new Pawn(Player.White);
            var square = Square.At(6, 4);
            board.AddPiece(square, pawn);

            var location = board.FindPiece(pawn);

            location.Should().Be(square);
        }

        [Test]
        public void WhiteScoreTest()
        {
            var capturedPieces = new List<Piece>()
            {
                new Rook(Player.Black),
                new Queen(Player.White),
                new Pawn(Player.Black)
            };
            
            var board = A.Fake<IBoard>();
            A.CallTo(() => board.CapturedPieces).Returns(capturedPieces);

            var scoreCalculator = new ScoreCalculator(board);

            scoreCalculator.GetWhiteScore().Should().Equals(6);
        }
        
        [Test]
        public void BlackScoreTest()
        {
            var capturedPieces = new List<Piece>()
            {
                new Rook(Player.White),
                new Bishop(Player.White),
                new Pawn(Player.Black)
            };
            
            var board = A.Fake<IBoard>();
            A.CallTo(() => board.CapturedPieces).Returns(capturedPieces);

            var scoreCalculator = new ScoreCalculator(board);

            scoreCalculator.GetBlackScore().Should().Equals(9);
        }
    }
}
