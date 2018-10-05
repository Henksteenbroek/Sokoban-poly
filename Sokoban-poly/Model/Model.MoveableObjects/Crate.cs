using Sokoban_poly.Model.Model.MoveableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_poly.Model
{
    public class Crate: GoalObject
    {
        public Crate(Game game) : base(game)
        {
            FloorChar = 'O';
        }
    }
}
