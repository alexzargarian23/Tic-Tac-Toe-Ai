namespace TickTacToe;

public class MoveValidator
{
    public static void Move(Cell[,] board, Cell currentPlayer)
    {
        int row = 0;
        int colum = 0;

        do
        {
            Console.WriteLine("What is the row (1-3)?");
            row = int.Parse(Console.ReadLine()) - 1; 

            Console.WriteLine("What is the column (1-3)?");
            colum = int.Parse(Console.ReadLine()) - 1; 

         
        
        } while (row < 0 || row > 2 || colum < 0 || colum > 2 || board[row, colum] != Cell.Empty);

        
        board[row, colum] = currentPlayer;
    }
}