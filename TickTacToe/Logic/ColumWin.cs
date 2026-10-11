namespace TickTacToe.Logic;

public class ColumWin
{
    public static Cell ColumWinner(Cell[,] board)
    {
        for (int col = 0; col < 3; col++)
        {
            if (board[0, col] != Cell.Empty 
                && board[0, col] == board[1, col] 
                && board[1, col] == board[2, col])
            {
                return board[0, col]; 
            }
        }
        
        return Cell.Empty; 
    }
}