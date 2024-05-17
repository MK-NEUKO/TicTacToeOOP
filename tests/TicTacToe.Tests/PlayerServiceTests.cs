using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Core.Services;
using Xunit;

namespace TicTacToe.Tests;

public class PlayerServiceTests
{
    [Fact]
    public void ChangeCurrentPlayer_ShouldChangeIsCurrentPlayer()
    {
        // Arrange
        var player1 = new FakePlayer() { IsCurrentPlayer = true };
        var player2 = new FakePlayer() { IsCurrentPlayer = false };
        var playerService = new PlayerService();

        // Act
        playerService.ChangeCurrentPlayer(new List<IPlayer> { player1, player2 });

        // Assert
        Assert.False(player1.IsCurrentPlayer);
        Assert.True(player2.IsCurrentPlayer);
    }

    [Fact]
    public void ChangeCurrentPlayer_ShouldThrowArgumentNullException()
    {
        //Arrange
        var playerService = new PlayerService();

        //Act

        //Assert
        Assert.Throws<ArgumentNullException>(() => playerService.ChangeCurrentPlayer(null));
    }

    [Fact]
    public void ChangeCurrentPlayer_ShouldThrowArgumentException()
    {
        //Arrange
        var playerService = new PlayerService();
        var emptyPlayerList = new List<IPlayer>();
        var playerListWithOnePlayer = new List<IPlayer> { new FakePlayer() };

        //Act

        //Assert
        Assert.Throws<ArgumentException>(() => playerService.ChangeCurrentPlayer(emptyPlayerList));
        Assert.Throws<ArgumentException>(() => playerService.ChangeCurrentPlayer(playerListWithOnePlayer));
    }
}