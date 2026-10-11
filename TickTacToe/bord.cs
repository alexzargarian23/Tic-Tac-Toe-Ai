namespace TickTacToe;

public class bord
{
    public Cell [,] board = new Cell[3,3];
    // print the bord
    public  void printEmoptyBord()
    
    {
        Console.WriteLine(" 1 2 3");
        int counter = 1;
        for (int i = 0; i < 3; i++)
        {
           
            Console.Write(counter + " ");
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == Cell.Empty)
                {
                    Console.Write( "- ");
                }
                else
                {
                    Console.Write(board[i, j] + " ");
                }
               
            }
            Console.WriteLine();
            counter++;
          
        }
        
        
    }
}