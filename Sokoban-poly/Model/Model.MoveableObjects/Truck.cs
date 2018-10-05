using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_poly.Model
{
    public class Truck : MoveableObject
    {
        public Truck(Game game) : base(game)
        {
            FloorChar = '@';
            getsPoints = false;
        }
    }
}
