using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_poly.Model.Model.MoveableObjects
{
    public class GoalObject : MoveableObject
    {
        public GoalObject(Game game) : base(game)
        {
            getsPoints = true;
        }
    }
}
