using TickTacToe;
using TickTacToe.Logic;

namespace TickTacToe;

public class Program
{
    public static void Main(string[] args)
    {
        bord game = new bord();
        ColumWin columChecker = new ColumWin();

        Cell currentPlayer = UserSelection.PickUser();
        Cell winner = Cell.Empty;

        while (true)
        {
            Console.WriteLine();
            game.printEmoptyBord();
            Console.WriteLine($"Player {currentPlayer}'s turn");

            MoveValidator.Move(game.board, currentPlayer);

            // Check for a winner
            Cell rowWinner = checkRows.checkRowWin(game.board);
            Cell colWinner = columChecker.ColumWinner(game.board);
            Cell diagWinner = Diagonal.FirstDiagonalCell(game.board);

            if (rowWinner != Cell.Empty) winner = rowWinner;
            else if (colWinner != Cell.Empty) winner = colWinner;
            else if (diagWinner != Cell.Empty) winner = diagWinner;

            if (winner != Cell.Empty)
            {
                Console.WriteLine();
                game.printEmoptyBord();
                Console.WriteLine($"Player {winner} wins!");
                break;
            }

            
            if (Tie.isTie(game.board))
            {
                Console.WriteLine();
                game.printEmoptyBord();
                Console.WriteLine("It's a tie!");
                break;
            }

            
            currentPlayer = currentPlayer == Cell.X ? Cell.O : Cell.X;
        }
    }
}