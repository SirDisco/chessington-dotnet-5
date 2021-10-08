using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KnightTests
    {
        [Test]
        public void Knight_CanMoveProperly()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            board.AddPiece(Square.At(4, 4), knight);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(6, 5));
            moves.Should().Contain(Square.At(6, 3));
            moves.Should().Contain(Square.At(5, 6));
            moves.Should().Contain(Square.At(5, 2));
            moves.Should().Contain(Square.At(3, 6));
            moves.Should().Contain(Square.At(3, 2));
            moves.Should().Contain(Square.At(2, 5));
            moves.Should().Contain(Square.At(2, 3));
        }

        [Test]
        public void WhiteKnight_CanTakeBlackPiece()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            var enemyKnight = new Knight(Player.Black);
            
            board.AddPiece(Square.At(4, 4), knight);
            board.AddPiece(Square.At(5, 6), enemyKnight);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().Contain(board.FindPiece(enemyKnight));
        }
        
        [Test]
        public void BlackKnight_CantTakeBlackPiece()
        {
            var board = new Board();
            var knight = new Knight(Player.White);
            var friendlyKnight = new Knight(Player.White);
            
            board.AddPiece(Square.At(4, 4), knight);
            board.AddPiece(Square.At(5, 6), friendlyKnight);

            var moves = knight.GetAvailableMoves(board);

            moves.Should().NotContain(board.FindPiece(friendlyKnight));
        }
    }
}