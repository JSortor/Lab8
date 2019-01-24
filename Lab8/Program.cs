using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[,] nameArray = { {"Dave Johnson", "banana pudding", "Traverse city, MI" },
                                    {"Joe Whitaker", "chicken parmesan", "Detroit, MI" },
                                    {"Bob Barker", "ice cream", "Toledo, OH" },
                                    {"Cody Halasz", "chicken Cordon Bleu", "Caro, MI" },
                                    {"Michael Jackson", "chicken wings", "Detroit, MI" },
                                    {"Kevin Blount", "croissants", "Oxford, MI" },
                                    {"Justin Sortor", "quesadillas", "Warren, MI" },
                                    {"Ashley Butler", "chicken wings", "Denver, Co" },
                                    {"Blake Shelton", "cannolis", "Los Angeles, CA" },
                                    {"John Denver", "ribs", "Nashville, Tn" },
                                    {"Toby Blanco", "oranges", "Macomb, MI" },
                                    {"Victor Sweet", "french fries", "Brooklyn, Ny" },
                                    {"Bobby Bouchier", "pizza", "Baton rouge, La" },
                                    {"Frank Figler", "soup", "Kansas City, KS"},
                                    {"Vanna White", "turkey", "Los angelos, Ca" },
                                    {"Hector Leon", "nachos", "Warren, Mi" },
                                    {"Donny Brasco", "grits", "Lapeer, Mi" },
                                    {"Gary Houston", "fish", "Troy, MI" },
                                    {"Jeff Maher", "cheeseburgers", "Eastpointe, MI" },
                                    {"Frank The Tank", "beer", "College" } };

            Console.WriteLine("Welcome to our C# class.\nWhich student would you like to learn more about?\n(enter a number between 1-20");
            bool goAgain = true;
            
            while (goAgain)
            {
                FindInfo(nameArray);
                goAgain = KeepGoing("Would you like to continue? (y/n) ");
            }


        }
        static bool KeepGoing(string message)
        {
            bool correctInput = true;
            bool continuer = true; 
            do
            {
                Console.Write("\n" + message);
                string confirm = Console.ReadLine().ToLower();
                if (confirm == "n" || confirm == "no")
                {
                    Console.WriteLine("Come back soon!");
                    continuer = false;
                    correctInput = true;
                    Console.ReadKey();
                }
                else if (confirm == "y" || confirm == "yes")
                {
                    Console.WriteLine("\nOkay!\n");
                    continuer = true;
                    correctInput = true;
                }
                else
                {
                    Console.WriteLine("Sorry, I didn't understand.");
                    correctInput = false;
                }
            } while (!correctInput);
            return continuer;
        }
        static void FindInfo(string[,] nameArray)
        {
            Console.WriteLine("Enter the number that corresponds to the team member you wish to look up. \n" +
                    "For a list of team members, enter \"0\".");
            int inputName;
            bool loopChoice = true;
            while (!int.TryParse(Console.ReadLine(), out inputName))
            
            {
                Console.Write("I'm sorry, I didn't understand. Please try again: ");
            }
            if (inputName == 0)
            {
                
                for (int i = 0; i < nameArray.GetLength(0); i++)
                {
                    Console.WriteLine($"{i + 1,2}: {nameArray[i, 0]}"); 
                }

            }
            else
            {
                try
                {
                    Console.WriteLine("\n" + inputName + " is " + nameArray[inputName - 1, 0] + ". Would you like to know more?");
                    do
                    {
                        loopChoice = true; 
                        Console.WriteLine("(Press \"0\" to skip, \"1\" for favorite food, or \"2\" for hometown)\n");
                        try
                        {
                            int inputNum = int.Parse(Console.ReadLine());
                            var test = nameArray[inputName, inputNum]; 
                            if (inputNum == 0)
                            {
                                
                                Console.WriteLine("Going back to the main database. . .");
                                loopChoice = false;
                            }
                            else if (inputNum == 1)
                            {
                               
                                Console.WriteLine(nameArray[inputName - 1, 0] + "'s favorite food is " + nameArray[inputName - 1, inputNum] + ".");
                                Console.WriteLine("Would you like to know more?");
                            }
                            else if (inputNum == 2)
                            {
                                
                                Console.WriteLine(nameArray[inputName - 1, 0] + "'s hometown is " + nameArray[inputName - 1, inputNum] + ".");
                                Console.WriteLine("Would you like to know more?");
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("I'm sorry, that input is not in the acceptable range.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("I'm sorry, I don't understand. Please input a number corresponding to your selection.");
                        }
                    } while (loopChoice);
                } //two sets of exception catches for each nested loop
                  //otherwise it will catch the exception but also exit the loop
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("I'm sorry, that input is not in the acceptable range.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("I'm sorry, I don't understand. Please input a number corresponding to your selection.");
                }

            }
        }
    }
}
