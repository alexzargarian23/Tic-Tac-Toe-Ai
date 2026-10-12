namespace TickTacToe;

public class Board
{
    public Cell[,] board = new Cell[3, 3];

    // print the bord
    public void PrintEmptyBoard()

    {
        Console.WriteLine(" 1 2 3");
        var counter = 1;
        for (var i = 0; i < 3; i++)
        {
            Console.Write(counter + " ");
            for (var j = 0; j < 3; j++)
                if (board[i, j] == Cell.Empty)
                    Console.Write("- ");
                else
                    Console.Write(board[i, j] + " ");

            Console.WriteLine();
            counter++;
        }
    }
}