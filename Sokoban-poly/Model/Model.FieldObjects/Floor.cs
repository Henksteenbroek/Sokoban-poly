using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_poly.Model
{
    public class Floor
    {
        public Game game;
        public MoveableObject MoveableObject;
        public Floor Up { get; set; }
        public Floor Down { get; set; }
        public Floor Left { get; set; }
        public Floor Right { get; set; }
        public char FloorChar { get; set; }
        public bool Walkable { get; set; }

        public Floor(Game game)
        {
            this.game = game;
            FloorChar = '.';
            Walkable = true;
            
        }

        public char getFloorChar()
        {
            if(MoveableObject == null)
            {
                return FloorChar;
            } else
            {
                return MoveableObject.FloorChar;
            }
        }
    }
}
