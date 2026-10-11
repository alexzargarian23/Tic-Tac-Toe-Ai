namespace TickTacToe;
//class for picking the user
public class UserSelection
{
    public static Cell PickUser()
    {
        Console.Write("Please chose what player you want to play (X or 1 ) or (Y or 2): ");
        string userInput;
        Cell player = Cell.Empty;
        do
        {
            userInput = Console.ReadLine();
        }
        while (!(userInput.ToLower() == "x" || userInput == "1" || userInput.ToLower() == "y" ||
                 userInput.ToLower() == "2"));


        if (userInput.ToLower() == "x" || userInput =="1")
        {
            Console.WriteLine("you are the X");
             return  Cell.X;
        }
        else
        {
            Console.WriteLine("you are the Y");
            return  Cell.O;
        }
    }
  
    }
