using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Core.Services;
using Xunit;

namespace TicTacToe.Tests;

public class PlayerServiceTests
{
    [Theory]
    [InlineData(true, false)]
    [InlineData(false, true)]
    public void ChangeCurrentPlayer_ShouldChangeIsCurrentPlayer(bool player1IsCurrentPlayer, bool player2IsCurrentPlayer)
    {
        // Arrange
        var player1 = new FakePlayer() { IsCurrentPlayer = player1IsCurrentPlayer };
        var player2 = new FakePlayer() { IsCurrentPlayer = player2IsCurrentPlayer };
        var playerService = new PlayerService();

        // Act
        playerService.ChangeCurrentPlayer(new List<IPlayer> { player1, player2 });

        // Assert
        Assert.NotEqual(player1IsCurrentPlayer, player1.IsCurrentPlayer);
        Assert.NotEqual(player2.IsCurrentPlayer ,player2IsCurrentPlayer);
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
        var playerList = new List<IPlayer> { new FakePlayer() };

        //Act

        //Assert
        Assert.Throws<ArgumentException>(() => playerService.ChangeCurrentPlayer(playerList));
    }
}