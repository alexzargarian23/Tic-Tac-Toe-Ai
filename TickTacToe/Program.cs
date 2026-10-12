using TickTacToe.AiMoves;
using TickTacToe.Logic;

namespace TickTacToe;

internal class Program
{
    private static void Main(string[] args)
    {
        var gameBoard = new Board();

        // 1. Let the user choose their symbol (X or O)
        var userSymbol = UserSelection.PickUser();

        // 2. AI automatically gets the other symbol
        var aiSymbol = userSymbol == Cell.X ? Cell.O : Cell.X;

        // X always goes first in Tic-Tac-Toe
        var currentPlayer = Cell.X;
        var gameOver = false;

        while (!gameOver)
        {
            Console.Clear();
            gameBoard.PrintEmptyBoard();

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
                var aiMove = Priority.Moves(gameBoard.board, aiSymbol, userSymbol);

                // Apply AI move safely
                if (aiMove != null && aiMove.Length == 2) gameBoard.board[aiMove[0], aiMove[1]] = aiSymbol;


                Console.Clear();
                gameBoard.PrintEmptyBoard();
                Console.WriteLine($"\nAI placed {aiSymbol} at Row {aiMove[0] + 1}, Column {aiMove[1] + 1}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }


            var winner = CheckForWinner(gameBoard.board);
            if (winner != Cell.Empty)
            {
                Console.Clear();
                gameBoard.PrintEmptyBoard();
                Console.WriteLine($" Player {winner} Wins!");
                gameOver = true;
                break;
            }

            if (Tie.IsTie(gameBoard.board))
            {
                Console.Clear();
                gameBoard.PrintEmptyBoard();
                Console.WriteLine("\nIt's a tie!");
                gameOver = true;
                break;
            }

            currentPlayer = currentPlayer == Cell.X ? Cell.O : Cell.X;
        }

        Console.WriteLine("\nGame Over. Press any key to exit.");
        Console.ReadKey();
    }


    private static Cell CheckForWinner(Cell[,] board)
    {
        if (CheckRows.CheckRowWin(board) != Cell.Empty)
            return CheckRows.CheckRowWin(board);

        if (ColumnWin.ColumnWinner(board) != Cell.Empty)
            return ColumnWin.ColumnWinner(board);

        if (Diagonal.FirstDiagonalCell(board) != Cell.Empty)
            return Diagonal.FirstDiagonalCell(board);

        return Cell.Empty;
    }
}