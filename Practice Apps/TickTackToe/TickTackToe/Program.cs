using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTackToe
    {
        public class Program
        {
            public static int[,] TBoard = new int[3, 3];

        public static void Main(string[] args)

        {
            Console.WriteLine("   |  0  |  1  |  2  |");
            Console.WriteLine("   |-----------------|");
            Console.WriteLine(" 0 |     |     |     |");
            Console.WriteLine("   |-----------------|");

            Console.WriteLine(" 1 |     |     |     |");
            Console.WriteLine("   |-----------------|");

            Console.WriteLine(" 2 |     |     |     |");
            Console.WriteLine("   |-----------------|");

            int PlayerOneR;
            int PlayerOneC;
            int PlayerTwoR;
            int PlayerTwoC;
            int TurnCount = 1;
            bool boardEntryValid = true;

            do
            {
                do
                {
                    //loop through player one and verify whether their entry is valid. If it is, add it to the TTT board
                    PlayerOneR = ValidCoordinates(1, "Row");
                    PlayerOneC = ValidCoordinates(1, "Column");
                    Console.WriteLine($"Coordinates selected: {PlayerOneR}, {PlayerOneC}");
                    boardEntryValid = BoardEntry(1, PlayerOneR, PlayerOneC);
                } while (!boardEntryValid);

                if (WinnerDet(TurnCount))
                {
                    break;
                }

                do
                {
                    //loop through player two and verify whether their entry is valid. If it is, add it to the TTT board 
                    PlayerTwoR = ValidCoordinates(2, "Row");
                    PlayerTwoC = ValidCoordinates(2, "Column");
                    Console.WriteLine($"Coordinates selected: {PlayerTwoR}, {PlayerTwoC}");
                    boardEntryValid = BoardEntry(2, PlayerTwoR, PlayerTwoC);
                } while (!boardEntryValid);

                TurnCount++;

            } while (WinnerDet(TurnCount) != true);

            Console.ReadLine();
        }

        /// <summary>
        /// Validates coordinates entered by players 
        /// </summary>
        /// <param name="playerID"></param>
        /// <param name="selectionType"></param>
        /// <returns>int of player choice </returns>
            public static int ValidCoordinates(int playerID, string selectionType)
            {
                string pChoice = string.Empty;
                int playerChoice;

                do
                {
                    Console.WriteLine($"Player {playerID}, please select a {selectionType}:  ");
                    pChoice = Console.ReadLine();

                    int.TryParse(pChoice, out playerChoice);

                    if (playerChoice != 0 && playerChoice != 1 && playerChoice != 2)
                    {
                        Console.WriteLine("Your selection is invalid, please try again.\n");

                    }
                    else
                    {
                        break;
                    }

                }
                while (playerChoice != 0 && playerChoice != 1 && playerChoice != 2);

                return playerChoice;


            }

        /// <summary>
        /// Method to validate whether grid coordinates are associated to an empty spot
        /// </summary>
        /// <param name="playerID"></param>
        /// <param name="validatedRow"></param>
        /// <param name="validatedColumn"></param>
        /// <returns>true if empty</returns>

            public static bool BoardEntry(int playerID, int validatedRow, int validatedColumn)
            {
                if (TBoard[validatedRow, validatedColumn] != 0)
                {
                    Console.WriteLine($"Coordinates {validatedRow},{validatedColumn} already contain a value, please try again.\n");
                    //ValidCoordinates(playerID,"row");
                    return false;
                    //loop through the validation again
                }
                else
                {
                    // if slot is empty, enter 1 or 2 
                    if (playerID == 1)
                    {
                        TBoard[validatedRow, validatedColumn] = 1;
                    }
                    else
                    {
                        TBoard[validatedRow, validatedColumn] = 2;
                    }
                    return true;
                }

            }




            // method to determine if there is a winner 

        public static bool WinnerDet(int turnCount)
        {
            int tc = turnCount;

            if (tc > 2)
            {
                //loop across to check if winner 
                for (int i = 0; i < 3; i++)
                {
                    int j = 0;
                    if (TBoard[i, j] == TBoard[i, j + 1] && TBoard[i, j] == TBoard[i, (j + 2)] && TBoard[i, j] + TBoard[i, j + 1] + TBoard[i, (j + 2)] == 3)
                    {
                        Console.WriteLine("Player 1 Wins");
                        return true;
                    }
                    else if (TBoard[i, j] == TBoard[i, j + 1] && TBoard[i, j] == TBoard[i, (j + 2)] && TBoard[i, j] + TBoard[i, j + 1] + TBoard[i, (j + 2)] == 6)
                    {
                        Console.WriteLine("Player 2 Wins");
                        return true;
                    }
                }
                // loop bottom to check if winner 
                for (int j = 0; j < 3; j++)
                {
                    int i = 0;
                    if (TBoard[i, j] == TBoard[i + 1, j] && TBoard[i, j] == TBoard[i + 2, j] && TBoard[i, j] + TBoard[i + 1, j] + TBoard[i + 2, j] == 3)
                    {
                        Console.WriteLine("Player 1 Wins");
                        return true;
                    }
                    else if (TBoard[i, j] == TBoard[i + 1, j] && TBoard[i, j] == TBoard[i + 2, j] && TBoard[i, j] + TBoard[i + 1, j] + TBoard[i + 2, j] == 6)
                    {
                        Console.WriteLine("Player 2 Wins");
                        return true;
                    }
                }

                // diagonal winner check
                if ((TBoard[0, 0] == TBoard[1, 1] && TBoard[0, 0] == TBoard[2, 2] && TBoard[0, 0] + TBoard[1, 1] + TBoard[2, 2] == 3) || TBoard[2, 0] + TBoard[1, 1] + TBoard[0, 2] == 3)
                {
                    Console.WriteLine("Player 1 Wins");
                    return true;
                }
                else if ((TBoard[0, 0] == TBoard[1, 1] && TBoard[0, 0] == TBoard[2, 2] && TBoard[0, 0] + TBoard[1, 1] + TBoard[2, 2] == 6) || TBoard[2, 0] + TBoard[1, 1] + TBoard[0, 2] == 6)
                {
                    Console.WriteLine("Player 2 Wins");
                    return true;
                }
                return false;
            }

            else if (tc == 9)
            {
                Console.WriteLine("Draw");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

