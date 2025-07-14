using Microsoft.AspNetCore.Mvc;
using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Ui.AspNetCoreWebUI.Models;
using System.Text.Json;

namespace MichaelKoch.TicTacToe.Ui.AspNetCoreWebUI.Controllers;

public class GameController : Controller
{
    private readonly IGameService _gameService;
    private readonly IGameEvaluator _gameEvaluator;
    private const string GameStateKey = "GameState";

    public GameController(IGameService gameService, IGameEvaluator gameEvaluator)
    {
        _gameService = gameService;
        _gameEvaluator = gameEvaluator;
    }

    public IActionResult Index()
    {
        var gameModel = GetGameState();
        return View(gameModel);
    }

    [HttpPost]
    public async Task<IActionResult> MakeMove(int areaId)
    {
        var gameModel = GetGameState();
        
        if (gameModel.GameEnded)
        {
            return RedirectToAction("Index");
        }

        var area = gameModel.GameBoard.ConcreteAreas[areaId];
        if (area.IsOccupied)
        {
            return RedirectToAction("Index");
        }

        // Make the move
        var currentPlayer = gameModel.GetCurrentPlayer();
        area.Token = currentPlayer.Token;
        area.IsOccupied = true;

        // Check for winner with simple logic
        var winner = CheckForWinner(gameModel.GameBoard.ConcreteAreas);
        if (winner != null)
        {
            var winningPlayer = gameModel.Players.First(p => p.Token == winner);
            winningPlayer.IsWinner = true;
            gameModel.GameStatus = $"{winningPlayer.Name} wins!";
            gameModel.WinnerName = winningPlayer.Name;
            gameModel.GameEnded = true;
            
            // Mark winning areas
            MarkWinningAreas(gameModel.GameBoard.ConcreteAreas, winner);
        }
        else if (gameModel.GameBoard.ConcreteAreas.All(a => a.IsOccupied))
        {
            gameModel.GameStatus = "It's a draw!";
            gameModel.GameEnded = true;
        }
        else
        {
            // Switch to next player
            gameModel.SwitchPlayer();
            gameModel.GameStatus = $"{gameModel.GetCurrentPlayer().Name}'s turn";
        }

        SaveGameState(gameModel);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult NewGame()
    {
        HttpContext.Session.Remove(GameStateKey);
        return RedirectToAction("Index");
    }

    private GameViewModel GetGameState()
    {
        var gameStateJson = HttpContext.Session.GetString(GameStateKey);
        if (string.IsNullOrEmpty(gameStateJson))
        {
            var newGame = new GameViewModel();
            SaveGameState(newGame);
            return newGame;
        }

        return JsonSerializer.Deserialize<GameViewModel>(gameStateJson) ?? new GameViewModel();
    }

    private void SaveGameState(GameViewModel gameModel)
    {
        var json = JsonSerializer.Serialize(gameModel);
        HttpContext.Session.SetString(GameStateKey, json);
    }

    private string? CheckForWinner(List<SimpleGameBoardArea> areas)
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (areas[i * 3].IsOccupied && areas[i * 3].Token == areas[i * 3 + 1].Token && areas[i * 3].Token == areas[i * 3 + 2].Token)
                return areas[i * 3].Token;
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (areas[i].IsOccupied && areas[i].Token == areas[i + 3].Token && areas[i].Token == areas[i + 6].Token)
                return areas[i].Token;
        }

        // Check diagonals
        if (areas[0].IsOccupied && areas[0].Token == areas[4].Token && areas[0].Token == areas[8].Token)
            return areas[0].Token;

        if (areas[2].IsOccupied && areas[2].Token == areas[4].Token && areas[2].Token == areas[6].Token)
            return areas[2].Token;

        return null;
    }

    private void MarkWinningAreas(List<SimpleGameBoardArea> areas, string winnerToken)
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (areas[i * 3].Token == winnerToken && areas[i * 3 + 1].Token == winnerToken && areas[i * 3 + 2].Token == winnerToken)
            {
                areas[i * 3].IsWinArea = true;
                areas[i * 3 + 1].IsWinArea = true;
                areas[i * 3 + 2].IsWinArea = true;
                return;
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (areas[i].Token == winnerToken && areas[i + 3].Token == winnerToken && areas[i + 6].Token == winnerToken)
            {
                areas[i].IsWinArea = true;
                areas[i + 3].IsWinArea = true;
                areas[i + 6].IsWinArea = true;
                return;
            }
        }

        // Check diagonals
        if (areas[0].Token == winnerToken && areas[4].Token == winnerToken && areas[8].Token == winnerToken)
        {
            areas[0].IsWinArea = true;
            areas[4].IsWinArea = true;
            areas[8].IsWinArea = true;
            return;
        }

        if (areas[2].Token == winnerToken && areas[4].Token == winnerToken && areas[6].Token == winnerToken)
        {
            areas[2].IsWinArea = true;
            areas[4].IsWinArea = true;
            areas[6].IsWinArea = true;
            return;
        }
    }
}