﻿namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class Node
{
    public int Depth { get; set; }
    public List<string> Board { get; set; }
    public int NodeRating { get; set; }
    public int SetAreaId { get; set; }
}