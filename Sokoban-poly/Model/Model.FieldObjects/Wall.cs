using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_poly.Model
{
    public class Wall : Floor
    {
        public Wall(Game game) : base(game)
        {
            FloorChar = '█';
            Walkable = false;
            givesPoints = false;
        }
    }
}
