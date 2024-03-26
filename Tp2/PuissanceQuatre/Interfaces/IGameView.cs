using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpionApp.Interfaces
{
    public interface IGameView
        {
            void ClearScreen();
            void Display(string message);
            void DisplayLineBreak();
            void DisplayLineBreakMessage(string message);
            ConsoleKey GetUserInput();
            void SetCursorPosition(int left, int top);
        }

}


