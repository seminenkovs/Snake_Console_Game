using System;
using System.Threading;

namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            bool exit = false; // loop exit flag

            double frameRate = 1000 / 5.0; // Snake speed 5 cells in a second
            
            DateTime lastTimeStamp = DateTime.Now; // Time stamp of last action

            Meal meal = new Meal();
            Snake snake = new Snake();

            //game loop
            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey();

                    switch (input.Key)
                    {
                        case ConsoleKey.Escape:
                            exit = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;
                    }
                }

                // game action
                if ((DateTime.Now - lastTimeStamp).TotalMilliseconds >= frameRate) 
                {
                    snake.Move();

                    

                    if (meal.CurrentPosition.X == snake.SnakeHead.X &&
                        meal.CurrentPosition.Y == snake.SnakeHead.Y)
                    {
                        snake.EatMeal();

                        Thread.Sleep(100);

                        meal = new Meal(); // show new meal target

                        frameRate /= 1.1;
                    }

                    if (snake.GameOver)
                    {
                        Console.Clear();
                        Console.WriteLine(new String('\n', 13));
                        Console.Write(new String(' ', 40));
                        Console.Write($"Game Over. Your Score is : {snake.SnakeLength -  1}");
                        exit = true;
                        //Delay
                        Console.ReadLine();
                    }

                    lastTimeStamp = DateTime.Now;
                }
            }
        }
    }
}
