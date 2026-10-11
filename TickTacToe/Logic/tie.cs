namespace TickTacToe.Logic;

public class Tie
{
    public static bool isTie(Cell[,] board)
    {
        foreach (var cell in board)
        {
            if (cell == Cell.Empty)
            {
                return false;
            }
        }
        return true;
    }
}