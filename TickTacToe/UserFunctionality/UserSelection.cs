namespace TickTacToe;

// Class for picking the user
public class UserSelection
{
    public static Cell PickUser()
    {
        string userInput;

        while (true)
        {
            Console.Write("Please choose what player you want to play (X, x, 1) or (O,o, 2)  ");
            userInput = Console.ReadLine().ToLower();

            if (userInput == "x" || userInput == "1")
            {
                Console.WriteLine("You selected Player X");
                return Cell.X;
            }
            if (userInput == "o" || userInput == "2" || userInput == "y")
            {
                Console.WriteLine("You selected Player O");
                return Cell.O;
            }

            Console.WriteLine(" Invalid selection! Please enter X, O, 1, or 2");
        }
    }
}