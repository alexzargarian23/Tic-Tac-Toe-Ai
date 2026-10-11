using TickTacToe.Logic;

namespace TickTacToe.AI_Moves;

public class Priority
{
    public static int[] moves(Cell[,] board, Cell ai, Cell human)
    {
        for (int turn = 0; turn < 2; turn++)
        {
            Cell player = (turn == 0) ? ai : human;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == Cell.Empty && canWin(board, i, j, player))
                    {
                        return new int[] { i, j };
                    }
                }
            }
        }

        if (board[1, 1] == Cell.Empty)
        {
            return new int[] { 1, 1 };
        }

        if (board[0, 0] == human && board[2, 2] == Cell.Empty) return new int[] { 2, 2 };
        if (board[2, 2] == human && board[0, 0] == Cell.Empty) return new int[] { 0, 0 };
        if (board[0, 2] == human && board[2, 0] == Cell.Empty) return new int[] { 2, 0 };
        if (board[2, 0] == human && board[0, 2] == Cell.Empty) return new int[] { 0, 2 };

        int[][] corners = new int[][] { new int[] { 0, 0 }, new int[] { 0, 2 }, new int[] { 2, 0 }, new int[] { 2, 2 } };
        foreach (var corner in corners)
        {
            if (board[corner[0], corner[1]] == Cell.Empty)
            {
                return corner;
            }
        }

        int[][] sides = new int[][] { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 1, 2 }, new int[] { 2, 1 } };
        foreach (var side in sides)
        {
            if (board[side[0], side[1]] == Cell.Empty)
            {
                return side;
            }
        }

        return new int[] { 0, 0 };
    }

    private static bool canWin(Cell[,] board, int row, int col, Cell player)
    {
        board[row, col] = player;

        bool win = false;
        if (checkRows.checkRowWin(board) == player) win = true;
        if (ColumWin.ColumWinner(board) == player) win = true;
        if (Diagonal.FirstDiagonalCell(board) == player) win = true;

        board[row, col] = Cell.Empty; 

        return win;
    }
}