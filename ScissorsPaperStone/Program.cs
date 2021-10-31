using System;
using System.Linq;

namespace ScissorsPaperStone
{
    class Program
    {
        static void Main(string[] args)
        {
            bool allUnique = args.Distinct().Count() == args.Length;
            if (args.Length < 3 || args.Length % 2 == 0 || !allUnique)
            {
                Console.WriteLine("Wrong arguments! Quantity must be odd and more than 3.\nExample: Scissors Paper Stone Knife Bottle");
                return;
            }
            
            RandomMoveGenerator moveGenerator = new RandomMoveGenerator(args);
            Rules rules = new Rules();
            HelpTable table = new HelpTable();

            Console.WriteLine(moveGenerator.HMAC);
            Console.WriteLine("Avaiable moves: ");
            for (int i = 1; i <= args.Length; i++)
            {
                Console.WriteLine(i + " - " + args[i - 1]);
            }
            Console.WriteLine("0 - exit\n? - help");

            bool parsed = false;
            int userMove = -1;
            do
            {
                Console.Write("Enter your move: ");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "0":
                        return;
                    case "?":
                        table.DrawHelpTable(args, rules);
                        break;
                    default:
                        int.TryParse(userChoice, out userMove);
                        userMove -= 1;
                        if (userMove == -1) { break; }
                        if (userMove < args.Length && userMove > -1) { parsed = true; }
                        break;
                }
            } while (!parsed);

            Console.WriteLine("Ur move is: " + args[userMove]);
            Console.WriteLine("Winner: " + rules.PickWinner(args, moveGenerator.GetMoveId(args), userMove));
            Console.WriteLine("PC move was: " + moveGenerator.Move);
            Console.WriteLine("HMAC key: " + moveGenerator.Key);
        }
    }
}
