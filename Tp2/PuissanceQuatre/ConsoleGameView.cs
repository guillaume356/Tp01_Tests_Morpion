using MorpionApp.Interfaces;

public class ConsoleGameView : IGameView
{
    public void ClearScreen()
    {
        Console.Clear();
    }

    public void Display(string message)
    {
        Console.Write(message);
    }

    public void DisplayLineBreak()
    {
        Console.WriteLine();
    }

    public void DisplayLineBreakMessage(string message)
    {
        Console.WriteLine(message);
    }

    public ConsoleKey GetUserInput()
    {
        return Console.ReadKey(true).Key;
    }

    public void SetCursorPosition(int left, int top)
    {
        Console.SetCursorPosition(left, top);
    }
}
