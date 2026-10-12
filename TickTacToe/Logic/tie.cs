namespace TickTacToe.Logic;

public class Tie
{
    public static bool IsTie(Cell[,] board)
    {
        foreach (var cell in board)
            if (cell == Cell.Empty)
                return false;

        return true;
    }
}