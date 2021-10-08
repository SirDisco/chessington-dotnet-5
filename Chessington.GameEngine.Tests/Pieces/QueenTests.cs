using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class QueenTests
    {
        [Test]
        public void Queen_CanMoveUpRight()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            
            board.AddPiece(Square.At(0, 0), queen);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(1, 1));
            moves.Should().Contain(Square.At(2, 2));
        }
        
        [Test]
        public void Queen_CanMoveUpLeft()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            
            board.AddPiece(Square.At(0, 7), queen);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(1, 6));
            moves.Should().Contain(Square.At(2, 5));
        }
        
        [Test]
        public void Queen_CanMoveDownRight()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            
            board.AddPiece(Square.At(7, 0), queen);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(6, 1));
            moves.Should().Contain(Square.At(5, 2));
        }
        
        [Test]
        public void Queen_CanMoveDownLeft()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            
            board.AddPiece(Square.At(7, 7), queen);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(6, 6));
            moves.Should().Contain(Square.At(5, 5));
        }
        
        [Test]
        public void Queen_CanMoveVertically()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            
            board.AddPiece(Square.At(3, 0), queen);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(4, 0));
            moves.Should().Contain(Square.At(5, 0));
            moves.Should().Contain(Square.At(6, 0));
            
            moves.Should().Contain(Square.At(2, 0));
            moves.Should().Contain(Square.At(1, 0));
        }
        
        [Test]
        public void Queen_CanMoveHorizontally()
        {
            var board = new Board();
            var queen = new Queen(Player.White);
            
            board.AddPiece(Square.At(3, 4), queen);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(3, 3));
            moves.Should().Contain(Square.At(3, 2));
            moves.Should().Contain(Square.At(3, 1));
            
            moves.Should().Contain(Square.At(3, 5));
            moves.Should().Contain(Square.At(3, 6));
        }

        [Test]
        public void Queen_CannotMoveOutsideTheBoard()
        {
            var board = new Board();
            var queen = new Queen(Player.White);

            board.AddPiece(Square.At(4, 4), queen);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().NotContain(Square.At(-1, -1));
            moves.Should().NotContain(Square.At(8, 8));
            
            moves.Should().NotContain(Square.At(4, -1));
            moves.Should().NotContain(Square.At(4, 8));
            
            moves.Should().NotContain(Square.At(8, 4));
            moves.Should().NotContain(Square.At(-1, 4));
        }

        [Test]
        public void Queen_CannotMoveThroughPiece()
        {
            var board = new Board();
            var queen = new Bishop(Player.White);
            var blocker = new Bishop(Player.White);

            board.AddPiece(Square.At(4, 4), queen);
            board.AddPiece(Square.At(6, 6), blocker);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(5, 5));
            moves.Should().NotContain(Square.At(6, 6));
            moves.Should().NotContain(Square.At(7, 7));
        }
        
        [Test]
        public void Queen_CanTakeOtherPiece()
        {
            var board = new Board();
            var queen = new Bishop(Player.White);
            var enemy = new Bishop(Player.Black);

            board.AddPiece(Square.At(4, 4), queen);
            board.AddPiece(Square.At(6, 6), enemy);

            var moves = queen.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(5, 5));
            moves.Should().Contain(Square.At(6, 6));
            moves.Should().NotContain(Square.At(7, 7));
        }
    }
}