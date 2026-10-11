using TickTacToe;

// 1. Create a board and print it empty
bord b = new bord();
b.printEmoptyBord();

Console.WriteLine();   // blank line for readability

// 2. Put some marks in by hand and print again
b.board[0, 0] = Cell.X;
b.board[1, 1] = Cell.O;
b.board[2, 2] = Cell.X;
b.printEmoptyBord();