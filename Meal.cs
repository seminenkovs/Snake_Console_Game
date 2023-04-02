using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Meal
    {
        public Meal()
        {
            Random rand = new Random();
            var x = rand.Next(1, 20);
            var y = rand.Next(1, 20);
            CurrentPosition = new Point(x, y);
            DrawMeal();
        }

        public Point CurrentPosition { get; set; }

        private void DrawMeal()
        {
            Console.SetCursorPosition(CurrentPosition.X, CurrentPosition.Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("*");
        }
    }
}
