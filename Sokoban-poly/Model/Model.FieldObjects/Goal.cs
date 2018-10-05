using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_poly.Model
{
    public class Goal : Floor
    { 
        public Goal(Game game) : base(game)
        {
            FloorChar = 'x';
            Walkable = true;
            givesPoints = true;
        }
    }
}
