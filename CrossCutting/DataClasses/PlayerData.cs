﻿namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses;

public class PlayerData
{
    public PlayerData()
    {
        Name = string.Empty;
        Token = string.Empty;
        AiDifficultyLevel = new AiDifficultyLevel();
    }

    public string Name { get; set; }
    public string Token { get; set; }
    public bool IsAi { get; set; }
    public bool IsHuman { get; set; }
    public bool IsPlayersTurn { get; set; }
    public bool IsWinner { get; set; }
    public int Points { get; set; }
    public AiDifficultyLevel AiDifficultyLevel { get; set; }
}