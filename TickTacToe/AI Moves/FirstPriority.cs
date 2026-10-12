using TickTacToe.Logic;

namespace TickTacToe.AiMoves;

public class Priority
{
    public static int[] Moves(Cell[,] board, Cell ai, Cell human)
    {
        for (var turn = 0; turn < 2; turn++)
        {
            var player = turn == 0 ? ai : human;

            for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++)
                if (board[i, j] == Cell.Empty && CanWin(board, i, j, player))
                    return new[] { i, j };
        }

        if (board[1, 1] == Cell.Empty) return new[] { 1, 1 };

        if (board[0, 0] == human && board[2, 2] == Cell.Empty) return new[] { 2, 2 };
        if (board[2, 2] == human && board[0, 0] == Cell.Empty) return new[] { 0, 0 };
        if (board[0, 2] == human && board[2, 0] == Cell.Empty) return new[] { 2, 0 };
        if (board[2, 0] == human && board[0, 2] == Cell.Empty) return new[] { 0, 2 };

        var corners = new[] { new[] { 0, 0 }, new[] { 0, 2 }, new[] { 2, 0 }, new[] { 2, 2 } };
        foreach (var corner in corners)
            if (board[corner[0], corner[1]] == Cell.Empty)
                return corner;

        var sides = new[] { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 1, 2 }, new[] { 2, 1 } };
        foreach (var side in sides)
            if (board[side[0], side[1]] == Cell.Empty)
                return side;

        return new[] { 0, 0 };
    }

    private static bool CanWin(Cell[,] board, int row, int col, Cell player)
    {
        board[row, col] = player;

        var win = false;
        if (CheckRows.CheckRowWin(board) == player) win = true;
        if (ColumnWin.ColumnWinner(board) == player) win = true;
        if (Diagonal.FirstDiagonalCell(board) == player) win = true;

        board[row, col] = Cell.Empty;

        return win;
    }
}