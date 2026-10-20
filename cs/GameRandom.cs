using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading; // main namespace 
using System.Text.RegularExpressions;

namespace CSCollection
{
	public class GameRandom
	{
		public static void Main(string[] args)
		{
            Random rd = new Random();
            bool repeat = true;
            String Name; 
            String ComputerChoice; 
            String rs; 

            while(repeat)
            {
                Name = "";
                ComputerChoice = "";
                rs = "";
                
                while (Name != "rock" && Name != "scissors" && Name != "paper") 
                { 
                    Console.Write("Choice: ");
                    Name = Console.ReadLine();
                    Name = Name.ToLower();
                }

                switch(rd.Next(1, 4))
                {
                    case 1: ComputerChoice = "rock"; break;
                    case 2: ComputerChoice = "paper"; break; 
                    case 3: ComputerChoice = "scissors"; break; 
                    
                }

                switch(Name)
                {
                        case "rock":
                        if(ComputerChoice == "rock")
                        {
                            Console.WriteLine("It's a draw!");
                        }
                        else if (ComputerChoice == "paper")
                        {
                            Console.WriteLine("You lose!");
                        }
                        else {
                            Console.WriteLine("You win!");
                        }
                        break;

                        case "paper":
                        if(ComputerChoice == "paper")
                        {
                            Console.WriteLine("It's a draw!");
                        }
                        else if (ComputerChoice == "scissors")
                        {
                            Console.WriteLine("You lose!");
                        }
                        else {
                            Console.WriteLine("You win!");
                        }
                        break; 

                        case "scissors":
                        if(ComputerChoice == "scissors")
                        {
                            Console.WriteLine("It's a draw!");
                        }
                        else if (ComputerChoice == "rock")
                        {
                            Console.WriteLine("You lose!");
                        }
                        else {
                            Console.WriteLine("You win!");
                        }
                        break;
                }

                Console.Write("Again: ");
                rs = Console.ReadLine();
                rs = rs.ToLower();

                if(rs == "y") repeat = true; 
                else repeat = false; 

                Console.WriteLine($"Player: {Name}");
                Console.WriteLine($"Computer: {ComputerChoice}");
            }
        }
	}
}
