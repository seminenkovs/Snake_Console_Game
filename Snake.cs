using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake : ISnake
    {
        private bool SnakeOutOfRange = false;

        public int SnakeLength { get; set; } = 1;
        public Direction Direction { get; set; } = Direction.Right;
        public Point SnakeHead { get; set; } = new Point();
        List<Point> SnakeBody { get; set; } = new List<Point>();

        public bool GameOver
        {
            get 
            {
                return ((SnakeBody.Where(body => body.X == SnakeHead.X &&
                    body.Y == SnakeHead.Y).ToList().Count() > 1) || SnakeOutOfRange == true );    
            }
        }
        public void EatMeal()
        {
            SnakeLength++;
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.Left:
                    SnakeHead.X--;
                    break;
                case Direction.Right:
                    SnakeHead.X++;
                    break;
                case Direction.Up:
                    SnakeHead.Y--;
                    break;
                case Direction.Down:
                    SnakeHead.Y++;
                    break;
            }

            try
            {
                Console.SetCursorPosition(SnakeHead.X, SnakeHead.Y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("@");
                SnakeBody.Add(new Point(SnakeHead.X, SnakeHead.Y));

                if (SnakeBody.Count > this.SnakeLength)
                {
                    var tail = SnakeBody.First();

                    Console.SetCursorPosition(tail.X,tail.Y);
                    Console.Write(" ");

                    SnakeBody.Remove(tail);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                SnakeOutOfRange = true;
            }
        }
    }
}
