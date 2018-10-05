using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_poly.Model
{
    public class MoveableObject
    {
        Game game;
        public Floor Location { get; set; }
        public char FloorChar { get; set; }
        public bool getsPoints { get; set; }

        public MoveableObject(Game game)
        {
            this.game = game;
            getsPoints = false;
        }

        public void move(int direction)
        {
            game.moveObject(this, direction);
        }

      
        public bool canMove(int direction)
        {
            Floor Target = null;
            switch (direction)
            {
                case 0:
                    Target = Location.Up;
                    break;
                case 1:
                    Target = Location.Down;
                    break;
                case 2:
                    Target = Location.Left;
                    break;
                case 3:
                    Target = Location.Right;
                    break;
            }

            if (Target.Walkable || Target.MoveableObject != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
