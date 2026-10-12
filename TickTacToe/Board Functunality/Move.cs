namespace TickTacToe;

public class MoveValidator
{
    public static void Move(Cell[,] board, Cell currentPlayer)
    {
        var row = 0;
        var column = 0;

        do
        {
            Console.WriteLine("What is the row (1-3)?");
            row = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("What is the column (1-3)?");
            column = int.Parse(Console.ReadLine()) - 1;
        } while (row < 0 || row > 2 || column < 0 || column > 2 || board[row, column] != Cell.Empty);


        board[row, column] = currentPlayer;
    }
}