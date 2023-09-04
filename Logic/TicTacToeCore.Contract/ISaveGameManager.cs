﻿using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface ISaveGameManager
{
    void SaveCurrentGame(GameInfoBoardData gameInfoBoardData, PlayerGameBoardData playerGameBoardData);
    SaveGame LoadLastSaveGame();
}