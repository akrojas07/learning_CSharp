using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter an operand (+ - / *): ");
            //var keyOperand = Console.ReadLine();
            //while (keyOperand != ("+") && keyOperand != ("-") && keyOperand != ("*") && keyOperand != ("/"))
            //{
            //    Console.WriteLine($"{keyOperand} is not a valid operand. Please enter a valid operand (+ - / *): ");
            //    keyOperand = Console.ReadLine();
            //}
            
            string keyFirstValue;
            int firstValue;
            do
            {
                Console.WriteLine("Enter a number: ");
                keyFirstValue = Console.ReadLine();
            }
            while (!int.TryParse(keyFirstValue, out firstValue));


            string keySecondValue;
            int secondValue;
            do
            {
                Console.WriteLine("Enter a non-zero number: ");
                keySecondValue = Console.ReadLine();

            } 
            while (!int.TryParse(keySecondValue, out secondValue) || secondValue == 0);

            //Console.WriteLine($"{ secondValue }");
            //Console.ReadLine();

            int remainder = firstValue % secondValue;
            int quotient = firstValue / secondValue;

            //Console.WriteLine($"{ remainder }");

            if (remainder == 0)
            {
                if (quotient % 5 == 0)
                {
                    Console.WriteLine("Fizzbuzz");
                }
                else 
                {
                    Console.WriteLine("Fizz");
                }
            }
            else
            {
                Console.WriteLine("Buzz");
            }




            Console.ReadLine();
        }

    }
}
