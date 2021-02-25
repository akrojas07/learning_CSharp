
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine
{
    class Program
    {
        public static Stock[,] VendingStock = new Stock[3, 4];

        static void Main(string[] args)
        {
            // restock vending machine 
            RestockMachine();

            //show vending machine stock to user 
            ShowStock();

            //prompt user for selection 
            promptUser();


            //thank user
            Console.WriteLine("Thank you, come again");
            Console.ReadLine(); 


        }

        public static void RestockMachine()
        {
            VendingStock[0, 0] = new Stock(StockNameEnum.Coke, 2.99M, 3);
            VendingStock[0, 1] = new Stock(StockNameEnum.CupOfNoodles, 1.59M, 0);
            VendingStock[0, 2] = new Stock(StockNameEnum.HotCheetos, 1.99M, 4);
            VendingStock[0, 3] = new Stock(StockNameEnum.Nachos, 5.69M, 2);
            VendingStock[1, 0] = new Stock(StockNameEnum.Reeses, .99M, 1);
            VendingStock[1, 1] = new Stock(StockNameEnum.Ruffles, 2.49M, 6);
            VendingStock[1, 2] = new Stock(StockNameEnum.Skittles, .69M, 1);
            VendingStock[1, 3] = new Stock(StockNameEnum.Snickers, 1.99M, 3);
            VendingStock[2, 0] = new Stock(StockNameEnum.Sprite, 3.99M, 6);
            VendingStock[2, 1] = new Stock(StockNameEnum.Starburst, 1.99M, 10);
            VendingStock[2, 2] = new Stock(StockNameEnum.Takis, 1.49M, 7);
            VendingStock[2, 3] = new Stock(StockNameEnum.Water, .99M, 3);
            
        }
        /// <summary>
        /// ShowStock displays stock that is available for user 
        /// </summary>

        public static void ShowStock()
        {
            Console.WriteLine("|     A0       |     A1       |     A2       |      A3       |");
            //Console.WriteLine("|--------------|--------------|--------------|---------------|");
            
            Console.WriteLine("|     "+VendingStock[0, 0].Name + "     | " + VendingStock[0, 1].Name + " |  " + VendingStock[0, 2].Name + "  |     "+ VendingStock[0, 3].Name + "    | ");
            Console.WriteLine("|     " + VendingStock[0, 0].Price + "     |   " + VendingStock[0, 1].Price + "       |    " + VendingStock[0, 2].Price + "      |     " + VendingStock[0, 3].Price + "      | ");
            
            Console.WriteLine("|--------------|--------------|--------------|---------------|");

            Console.WriteLine("|     B0       |     B1       |     B2       |      B3       |");
            
            Console.WriteLine("|   " + VendingStock[1, 0].Name + "     |   " + VendingStock[1, 1].Name + "    |  " + VendingStock[1, 2].Name + "    |     " + VendingStock[1, 3].Name + "  | ");
            Console.WriteLine("|   " + VendingStock[1, 0].Price + "       |     " + VendingStock[1, 1].Price + "     |    " + VendingStock[1, 2].Price + "      |      " + VendingStock[1, 3].Price + "     | ");
            Console.WriteLine("|--------------|--------------|--------------|---------------|");

            Console.WriteLine("|     C0       |     C1       |     C2       |      C3       |");
            Console.WriteLine("|   " + VendingStock[2, 0].Name + "     |   " + VendingStock[2, 1].Name + "  |    " + VendingStock[2, 2].Name + "     |     " + VendingStock[2, 3].Name + "     | ");
            Console.WriteLine("|     " + VendingStock[2, 0].Price + "     |    " + VendingStock[2, 1].Price + "      |    " + VendingStock[2, 2].Price + "      |     " + VendingStock[2, 3].Price + "      | ");
            Console.WriteLine("|--------------|--------------|--------------|---------------|");
        }
        /// <summary>
        /// Prompts User to select an item. 
        /// Will validate the input user has entered.
        /// If invalid, user will be prompted to make another selection. 
        /// </summary>

        public static void promptUser()
        {
            string userInput = "";
            int amount;
            string firstInput;
            string secondInput;
            int rowValue;
            int columnValue;

            //prompt user to select an item  
            do
            {
                Console.WriteLine("Please select an item");
                userInput = Console.ReadLine();

            } while (!SelectionInputValidation(userInput));

            //Separate user input to validate each entry individually
            firstInput = userInput.Substring(0, 1);
            secondInput = userInput.Substring(1, 1);


            //translate inputs into row and column coordinates 
            rowValue = RowTranslation(firstInput);
            columnValue = int.Parse(secondInput);


            //set available amount of item equal to amount in Vending Stock array 
            int availableAmount = VendingStock[rowValue, columnValue].Amount;

            //prompt user to select an amount
            if (availableAmount == 0)
            {
                Console.WriteLine($"{ VendingStock[rowValue, columnValue].Name} is currently out of stock.");
                amount = 0;

            }
            else
            {
                //write out the amount available of selected item
                Console.WriteLine($"There are {availableAmount} {VendingStock[rowValue, columnValue].Name} available.");

                //prompt user to enter an amount
                do
                {
                    Console.WriteLine("How many would you like to purchase?");

                    //validate that this is an int
                    amount = int.Parse(Console.ReadLine());

                    //if amount entered by user is greater than available amount, write to console 
                    if (amount > availableAmount)
                    {
                        Console.WriteLine($"{amount} { VendingStock[rowValue, columnValue].Name} cannot be purchased. Only { VendingStock[rowValue, columnValue].Amount} remain.");
                    }
                    //if amount entered by user is zero, exit out of program
                    else if (amount == 0)
                    {
                        break;
                    }
                    //if amount entered by user is less than available amount: 
                    else
                    {
                        decimal totalCost;
                        decimal payment;
                        decimal moneyBack;

                        //prompt user for payment
                        totalCost = costCalculation(amount, rowValue, columnValue);
                        Console.WriteLine($"The total cost for {amount} {VendingStock[rowValue, columnValue].Name} is {totalCost}" +
                        $". Please insert payment amount");

                        //validate that this is a decimal
                        userInput = Console.ReadLine();
                        PaymentInputValidation(userInput, out payment);
                        
                        //loop to determine if payment provided by user is sufficient
                        do
                        {
                            if (payment > totalCost)
                            {
                                moneyBack = paymentCalculation(payment, totalCost);

                                Console.WriteLine($"Your change is {moneyBack}");
                                break;
                            }
                            else if (payment == totalCost)
                            {
                                Console.WriteLine("Your payment has been received.");
                                break;
                            }
                            else
                            {
                                paymentCalculation(payment, totalCost);
                                userInput = Console.ReadLine();
                                PaymentInputValidation(userInput, out decimal additionalPayment);
                                payment += additionalPayment; 
                                                                
                            }

                        } while (payment != totalCost);
                    }
                    

                } while (amount > availableAmount);


            }
        }    

        
        /// <summary>
        /// Validates input taken from user. 
        /// If invalid, will indicate which aspect of the entry was incorrect 
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns> true if user has entered valid input</returns>
        public static bool SelectionInputValidation(string userInput)
        {
            ////validate that user has entered two characters  
            if (userInput.Length != 2)
            {
               Console.WriteLine($"{userInput} is an invalid selection. Please try again.");
               return false; 
            }
                        
                //Separate user input to validate each entry individually
                string firstInput = userInput.Substring(0, 1);
                string secondInput = userInput.Substring(1, 1);

                //validate each entry separately 
                if (firstInput.ToUpper() != "A" && firstInput.ToUpper() != "B" && firstInput.ToUpper() != "C")
                {
                    Console.WriteLine($"Selection of {firstInput} is invalid. Please try again");
                    return false;
                }

                if (secondInput != "0" && secondInput != "1" && secondInput != "2")
                {
                    Console.WriteLine($"Selection of {secondInput} is invalid. Please try again");
                    return false;
                }
                

            return true;
        }

        /// <summary>
        /// Validates that a user has entered a valid payment number 
        /// Translates to decimal if successful
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="userPayment"></param>
        /// <returns>true if successfully translated into decimal</returns>
        /// <returns> userPayment if successfully translated </returns>
        public static bool PaymentInputValidation(string userInput, out decimal userPayment)
        {
            bool parsed = true;
            userPayment = 0.00m;
            parsed = decimal.TryParse(userInput, out decimal payment);

            if(!parsed)
            {
                Console.WriteLine($"{userInput} is invalid. Please try again");
                return false;
            }

            userPayment = payment;
            return true;

        }

        /// <summary>
        /// translates a letter input into a row coordinate 
        /// </summary>
        /// <param name="rowInput"></param>
        /// <returns> row coordinate</returns>
        public static int RowTranslation (string rowInput)
        {
            int rowValue;
            
            if (rowInput.ToUpper() == "A")
            {
                rowValue = 0;
            }
            else if (rowInput.ToUpper() == "B")
            {
                rowValue = 1;
            }
            else
            {
                rowValue = 2;
            }

            return rowValue; 

        }

        /// <summary>
        /// Calculates the cost of an item within the vending machine
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns> total cost of Vending machine item</returns>
        public static decimal costCalculation(int amount, int row, int column)
        {
            decimal totalCost = amount * VendingStock[row, column].Price; 
            
            return totalCost; 
        }

        /// <summary>
        /// Compares payment made by user to the total cost of an item
        /// </summary>
        /// <param name="userPayment"></param>
        /// <param name="cost"></param>
        /// <returns>user change or additional amount needed</returns>

        public static decimal paymentCalculation(decimal userPayment, decimal cost)
        {

            decimal change = 0.00m;
            decimal difference = 0.00m;

            do
            {
                if (userPayment > cost)
                {
                    change = userPayment - cost;
                    return change;

                }
                else if (userPayment == cost)
                {
                    change = 0.00m;
                    return change;
                }
                else
                {
                    difference = cost - userPayment;
                    Console.WriteLine($"{difference} remaining. Please add additional payment");
                    return difference;
                }
            } while (userPayment < cost);
            
        }
       
        


    }
}
