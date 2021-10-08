using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KingTests
    {
        [Test]
        public void King_CanMoveInEveryDirection()
        {
            var board = new Board();
            var king = new King(Player.White);
            
            board.AddPiece(Square.At(4, 4), king);

            var moves = king.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(5, 3));
            moves.Should().Contain(Square.At(5, 4));
            moves.Should().Contain(Square.At(5, 5));
            moves.Should().Contain(Square.At(4, 3));
            
            moves.Should().Contain(Square.At(4, 5));
            moves.Should().Contain(Square.At(3, 3));
            moves.Should().Contain(Square.At(3, 4));
            moves.Should().Contain(Square.At(3, 5));
        }
        
        [Test]
        public void King_CanMoveOnlyOne()
        {
            var board = new Board();
            var king = new King(Player.White);
            
            board.AddPiece(Square.At(4, 4), king);

            var moves = king.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(4, 6));
            moves.Should().NotContain(Square.At(5, 2));
        }
        
        [Test]
        public void King_CanTakeEnemyPiece()
        {
            var board = new Board();
            var king = new King(Player.White);
            var enemy = new Pawn(Player.Black);
            
            board.AddPiece(Square.At(4, 4), king);
            board.AddPiece(Square.At(4, 5), enemy);

            var moves = king.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(4, 5));
        }
        
        [Test]
        public void King_CantTakeFriendlyPieces()
        {
            var board = new Board();
            var king = new King(Player.White);
            var friend = new Pawn(Player.White);
            
            board.AddPiece(Square.At(4, 4), king);
            board.AddPiece(Square.At(4, 5), friend);

            var moves = king.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(4, 5));
        }
    }
}