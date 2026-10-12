namespace TickTacToe.Logic;

public class Diagonal
{
    public static Cell FirstDiagonalCell(Cell[,] board)
    {
        if (board[0, 0] != Cell.Empty && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) return board[0, 0];

        if (board[0, 2] != Cell.Empty && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) return board[0, 2];

        return Cell.Empty;
    }
}