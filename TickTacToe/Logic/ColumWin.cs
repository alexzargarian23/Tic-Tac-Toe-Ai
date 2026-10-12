namespace TickTacToe.Logic;

public class ColumnWin
{
    public static Cell ColumnWinner(Cell[,] board)
    {
        for (var col = 0; col < 3; col++)
            if (board[0, col] != Cell.Empty
                && board[0, col] == board[1, col]
                && board[1, col] == board[2, col])
                return board[0, col];

        return Cell.Empty;
    }
}