using System.Linq;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class RookTests
    {
        [Test]
        public void Rook_CanMoveVertically()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            
            board.AddPiece(Square.At(3, 0), rook);

            var moves = rook.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(4, 0));
            moves.Should().Contain(Square.At(5, 0));
            moves.Should().Contain(Square.At(6, 0));
            
            moves.Should().Contain(Square.At(2, 0));
            moves.Should().Contain(Square.At(1, 0));
        }
        
        [Test]
        public void Rook_CanMoveHorizontally()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            
            board.AddPiece(Square.At(3, 4), rook);

            var moves = rook.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 3));
            moves.Should().Contain(Square.At(3, 2));
            moves.Should().Contain(Square.At(3, 1));
            
            moves.Should().Contain(Square.At(3, 5));
            moves.Should().Contain(Square.At(3, 6));
        }
        
        [Test]
        public void Rook_CantMoveThroughPiece()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            var blocker = new Pawn(Player.White);
            
            board.AddPiece(Square.At(3, 0), rook);
            board.AddPiece(Square.At(3, 4), blocker);

            var moves = rook.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 3));
            moves.Should().NotContain(Square.At(3, 4));
            moves.Should().NotContain(Square.At(3, 5));
        }

        [Test]
        public void Rook_CanTakeEnemyPiece()
        {
            var board = new Board();
            var rook = new Rook(Player.White);
            var enemy = new Pawn(Player.Black);
            
            board.AddPiece(Square.At(3, 0), rook);
            board.AddPiece(Square.At(3, 4), enemy);

            var moves = rook.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 3));
            moves.Should().Contain(Square.At(3, 4));
            moves.Should().NotContain(Square.At(3, 5));
        }
    }
}