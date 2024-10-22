// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;

class Program
{
    // Global variables for the game
    static char[,] board = new char[3, 3]; // 3x3 game board
    static char currentPlayer = 'X'; // Current player ('X' or 'O')
    static bool isGameOver = false; // Flag to check if the game is over
    static int movesCount = 0; // To track the number of moves

    static void Main(string[] args)
    {
        InitializeBoard(); // Initialize the board with empty spaces

        while (!isGameOver)
        {
            Console.Clear(); // Clear the console for a fresh game state
            DrawBoard(); // Draw the current state of the board

            PlayerMove(); // Ask the player to make a move

            if (CheckWin()) // Check if the current player won
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine($"Player {currentPlayer} wins!");
                isGameOver = true;
            }
            else if (movesCount >= 9) // If all moves are made, it's a draw
            {
                Console.Clear();
                DrawBoard();
                Console.WriteLine("It's a draw!");
                isGameOver = true;
            }
            else
            {
                SwitchPlayer(); // Switch to the other player
            }
        }
    }

    // Method to initialize the board
    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = ' '; // Set each cell to an empty space
            }
        }
    }

    // Method to draw the current board state
    static void DrawBoard()
    {
        Console.WriteLine("   0   1   2 ");
        Console.WriteLine("  -----------");
        for (int i = 0; i < 3; i++)
        {
            Console.Write(i + " | ");
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                if (j < 2) Console.Write(" | ");
            }
            Console.WriteLine(" |");
            Console.WriteLine("  -----------");
        }
    }

    // Method for the player to make a move
    static void PlayerMove()
    {
        int row = -1, col = -1;
        bool validInput = false;

        while (!validInput)
        {
            Console.WriteLine($"Player {currentPlayer}, enter your move (row and column): ");

            try
            {
                Console.Write("Row (0-2): ");
                row = int.Parse(Console.ReadLine());

                Console.Write("Column (0-2): ");
                col = int.Parse(Console.ReadLine());

                if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
                {
                    board[row, col] = currentPlayer; // Update the board with the player's move
                    movesCount++; // Increment move count
                    validInput = true; // Exit the loop once a valid move is made
                }
                else
                {
                    Console.WriteLine("Invalid move, try again.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input, please enter numbers between 0 and 2.");
            }
        }
    }

    // Method to check if the current player has won
    static bool CheckWin()
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
            {
                return true;
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
            {
                return true;
            }
        }

        // Check diagonals
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
        {
            return true;
        }

        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
        {
            return true;
        }

        return false;
    }

    // Method to switch the current player
    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }
}

