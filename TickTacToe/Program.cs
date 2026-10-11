using TickTacToe.AI_Moves;
using TickTacToe.Logic;

namespace TickTacToe;

class Program
{
    static void Main(string[] args)
    {
        bord gameBoard = new bord();

        // 1. Let the user choose their symbol (X or O)
        Cell userSymbol = UserSelection.PickUser();
        
        // 2. AI automatically gets the other symbol
        Cell aiSymbol = (userSymbol == Cell.X) ? Cell.O : Cell.X;

        // X always goes first in Tic-Tac-Toe
        Cell currentPlayer = Cell.X; 
        bool gameOver = false;

        while (!gameOver)
        {
            Console.Clear();
            gameBoard.printEmoptyBord();

            Console.WriteLine($"\nUser Symbol: {userSymbol} | AI Symbol: {aiSymbol}");
            Console.WriteLine($"Current Turn: {currentPlayer}");

            // Explicitly check if it's the human's turn or AI's turn
            if (currentPlayer == userSymbol)
            {
                // Human Turn
                Console.WriteLine("\nYour turn!");
                MoveValidator.Move(gameBoard.board, currentPlayer);
            }
            else
            {
                
               

                
                int[] aiMove = Priority.moves(gameBoard.board, aiSymbol, userSymbol);
                
                // Apply AI move safely
                if (aiMove != null && aiMove.Length == 2)
                {
                    gameBoard.board[aiMove[0], aiMove[1]] = aiSymbol;
                }

            
                Console.Clear();
                gameBoard.printEmoptyBord();
                Console.WriteLine($"\nAI placed {aiSymbol} at Row {aiMove[0] + 1}, Column {aiMove[1] + 1}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            
            Cell winner = CheckForWinner(gameBoard.board);
            if (winner != Cell.Empty)
            {
                Console.Clear();
                gameBoard.printEmoptyBord();
                Console.WriteLine($" Player {winner} Wins!");
                gameOver = true;
                break;
            }

            if (Tie.isTie(gameBoard.board))
            {
                Console.Clear();
                gameBoard.printEmoptyBord();
                Console.WriteLine("\nIt's a tie!");
                gameOver = true;
                break;
            }

            currentPlayer = (currentPlayer == Cell.X) ? Cell.O : Cell.X;
        }

        Console.WriteLine("\nGame Over. Press any key to exit.");
        Console.ReadKey();
    }

   
    private static Cell CheckForWinner(Cell[,] board)
    {
        if (checkRows.checkRowWin(board) != Cell.Empty) 
            return checkRows.checkRowWin(board);
            
        if (ColumWin.ColumWinner(board) != Cell.Empty) 
            return ColumWin.ColumWinner(board);
            
        if (Diagonal.FirstDiagonalCell(board) != Cell.Empty) 
            return Diagonal.FirstDiagonalCell(board);
        
        return Cell.Empty;
    }
}