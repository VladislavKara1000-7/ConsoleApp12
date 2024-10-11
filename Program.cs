

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.Serialization;
using static System.Formats.Asn1.AsnWriter;
class HelloWorld
{
    static int height = Random.Shared.Next(3, 11);
    static int wight = Random.Shared.Next(3, 11);
    static string[,] trees = new string[height, wight];
    static int[,] treasure = new int[height, wight];
    static int hp = 3;
    static int score = 0;
    static int x;
    static int y;
    static List<string> trophies = new List<string>();
    static bool game = true;
   static void StartingForest()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < wight; j++)
            {

                trees[i, j] = "*";
                treasure[i, j] = Random.Shared.Next(1, 4);
            }
        }
    }
    static void ScoreCheck()
    {
        if (score < 0)
        {
            score = 0;
        }
    }
    static void IsAlive()
    {
        if (hp < 1)
        {
            game = false;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < wight; j++)
                {
                    Console.Write(trees[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine($"You Lose\nScore:{score}");
            foreach (string i in trophies)
            {
                Console.Write($"{i} ");
            }
        }
    }
    static void AddTreasure()
    {
        trees[y - 1, x - 1] = "X";
        string[] treasures = new string[4];
        treasures[0] = "Golden_Skull";
        treasures[1] = "Stand_arrow";
        treasures[2] = "Crystal_eye";
        trophies.Add(treasures[Random.Shared.Next(0, 3)]);
        score += 100;
        if (hp < 3)
        {
            hp++;
        }
    }
    static void LocationUnlock()
    {
        switch (treasure[y - 1, x - 1])
        {
            case 1:
                trees[y - 1, x - 1] = "O";
                break;
            case 2:
                AddTreasure();
                break;
            case 3:
                trees[y - 1, x - 1] = "!";
                hp--;
                score -= 50;
                break;
            case 4:
                trees[y - 1, x - 1] = "$";
                score += 500;
                game = false;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < wight; j++)
                    {
                        Console.Write(trees[i, j]);
                    }
                    Console.WriteLine();
                }
                break;
        }
    }  
        static void InputLocation()
        {
            Console.WriteLine("x:");
            if (int.TryParse(Console.ReadLine(), out x) && x - 1 < wight && x - 1 >= 0)
            {
                Console.WriteLine("y:");
                if (int.TryParse(Console.ReadLine(), out y) && y - 1 < height && y - 1 >= 0)
                {
                    if (trees[y - 1, x - 1] == "*")
                    {

                        LocationUnlock();
                        IsAlive();
                        ScoreCheck();
                    }
                    else
                    {
                        Console.WriteLine("Wrong coordinats");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong coordinats");
                }
            }
            else
            {
                Console.WriteLine("Wrong coordinats");
            }
        }
        static void display()
        {
            Console.WriteLine($"HP-{hp}\nScore:{score}");
            Console.Write("Treasures:");
            foreach (string i in trophies)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < wight; j++)
                {
                    Console.Write(trees[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            Console.Write("Enter name:");
            string name = Console.ReadLine();
            StartingForest();
            treasure[Random.Shared.Next(0, height), Random.Shared.Next(0, wight)] = 4;
            bool game = true;
            int hp = 3;
            int score = 0;
            Console.WriteLine($"X:{wight}\nY:{height}\nO-Nothing\nX-Treasure\n!-Trap\n$-Prise(WIN)");
            while (game)
            {
                display();
            InputLocation();
            }
        }

 }
