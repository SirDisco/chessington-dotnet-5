using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class BishopTests
    {
        [Test]
        public void Bishop_CanMoveUpRight()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            
            board.AddPiece(Square.At(0, 0), bishop);

            var moves = bishop.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(1, 1));
            moves.Should().Contain(Square.At(2, 2));
        }
        
        [Test]
        public void Bishop_CanMoveUpLeft()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            
            board.AddPiece(Square.At(0, 7), bishop);

            var moves = bishop.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(1, 6));
            moves.Should().Contain(Square.At(2, 5));
        }
        
        [Test]
        public void Bishop_CanMoveDownRight()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            
            board.AddPiece(Square.At(7, 0), bishop);

            var moves = bishop.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(6, 1));
            moves.Should().Contain(Square.At(5, 2));
        }
        
        [Test]
        public void Bishop_CanMoveDownLeft()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            
            board.AddPiece(Square.At(7, 7), bishop);

            var moves = bishop.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(6, 6));
            moves.Should().Contain(Square.At(5, 5));
        }

        [Test]
        public void Bishop_CannotMoveOutsideTheBoard()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);

            board.AddPiece(Square.At(4, 4), bishop);

            var moves = bishop.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(-1, -1));
            moves.Should().NotContain(Square.At(8, 8));
        }

        [Test]
        public void Bishop_CannotMoveThroughPiece()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            var blocker = new Bishop(Player.White);

            board.AddPiece(Square.At(4, 4), bishop);
            board.AddPiece(Square.At(6, 6), blocker);

            var moves = bishop.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(5, 5));
            moves.Should().NotContain(Square.At(6, 6));
            moves.Should().NotContain(Square.At(7, 7));
        }
        
        [Test]
        public void Bishop_CanTakeOtherPiece()
        {
            var board = new Board();
            var bishop = new Bishop(Player.White);
            var enemy = new Bishop(Player.Black);

            board.AddPiece(Square.At(4, 4), bishop);
            board.AddPiece(Square.At(6, 6), enemy);

            var moves = bishop.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(5, 5));
            moves.Should().Contain(Square.At(6, 6));
            moves.Should().NotContain(Square.At(7, 7));
        }
    }
}