namespace TickTacToe.Logic;

public class CheckRows
{
    public static Cell CheckRowWin(Cell[,] board)
    {
        for (var i = 0; i < 3; i++)
            if (board[i, 0] != Cell.Empty && board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2])
                return board[i, 0];

        return Cell.Empty;
    }
}