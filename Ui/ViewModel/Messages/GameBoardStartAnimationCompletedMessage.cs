using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Messages
{
    internal class GameBoardStartAnimationCompletedMessage : ValueChangedMessage<bool>
    {
        public GameBoardStartAnimationCompletedMessage(bool isCompleted) : base(isCompleted)
        {
        }
    }
}
