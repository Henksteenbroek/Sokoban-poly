using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_poly.Model.Model.FieldObjects
{
    public class Space : Floor
    {
        public Space(Game game) : base(game)
        {
            FloorChar = ' ';
            Walkable = false;
            givesPoints = false;
        }

    }
}
