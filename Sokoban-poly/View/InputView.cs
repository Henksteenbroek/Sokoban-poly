using Sokoban_poly.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_poly.View
{
    public class InputView
    {
        ConsoleKeyInfo key;
        int returnValue;

        public InputView()
        {

        }

        public ConsoleKeyInfo validInputGiven()
        {
            bool validInputGiven = false;

            Console.WriteLine("> gebruik pijltjestoetsen (s = stop, r = reset)");
            while (!validInputGiven)
            {
                key = Console.ReadKey();
                if (key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.LeftArrow && key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.S && key.Key != ConsoleKey.R)
                {
                    Console.WriteLine(" is geen geldig teken, gebruik de pijltestoetsen of 's' of 'r'");
                }
                else
                {
                    validInputGiven = true;
                }
            }
            return key;
        }

        public int readInput(ConsoleKeyInfo key)
        {
            this.key = key;
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    returnValue = (int)Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    returnValue = (int)Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    returnValue = (int)Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    returnValue = (int)Direction.Right;
                    break;
                case ConsoleKey.R:
                    returnValue = -1;
                    break;
                case ConsoleKey.S:
                    returnValue = -2;
                    break;
            }
            return returnValue;
        }

        public ConsoleKeyInfo gameWon()
        {
            return Console.ReadKey();
        }

        public int getMazeNumber()
        {
            bool validInputGiven = false;
            char c = ' ';
            string s = " ";
            int number = 0;
            while (!validInputGiven)
            {
                key = Console.ReadKey();
                c = key.KeyChar;
                Console.WriteLine(key.Key);
                if (c >= '1' && c <= '4')
                {
                    s = Char.ToString(key.KeyChar);
                    number = Convert.ToInt32(s);
                    validInputGiven = true;
                }
                else
                {
                    Console.WriteLine(" is geen bestaand level");
                }
            }
            return number;
        }
    }
}
