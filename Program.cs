using All_The_Brave_Frontier;
using System;
using System.Linq.Expressions;

public class Program
{
    public static void Main()
    {
        String menu = "\n\n [1] View Party" +
                            "\n [2] Edit Party" +
                            "\n [3] Fight" +
                            "\n [4] Exit Game";

    Console.Write("\n What is your name?: ");
    String playerName = Console.ReadLine();

    Console.Write($"\n Welcome to All The Brave Frontier {playerName}!");
    Console.WriteLine("");

    Char choice = ' ';

        Gameplay gameplay = new Gameplay();

        Console.WriteLine("\n Generate 25 characters");
        gameplay.Generate25Units();
        gameplay.ViewBarracks();
        gameplay.MergeUnits();
        gameplay.SetParty();


        do
        {
            Console.WriteLine(menu);

            Console.Write("\n What would you like to do: ");
            choice = Console.ReadKey().KeyChar;

            switch (choice)
            {
                case '1':
                    Console.WriteLine("\n View Party");
                    gameplay.ViewParty();
                    break;
                case '2':
                    Console.WriteLine("\n Edit Party");
                    gameplay.ArrangeParty();
                    break;
                case '3':
                    Console.WriteLine("\n Fight");
                    gameplay.generateEnemy();
                    gameplay.Fight();
                    break;
                case '4':
                    Console.WriteLine("\n Quit Game");
                    Console.WriteLine($"Thank you for playing, {playerName}! Farewell.");
                    choice = 'x';
                    break;
                default:
                    Console.WriteLine("\n Choose Again.");
                    break;
            }
        }
        while (choice != 'x');
        

        
        
    }
}

