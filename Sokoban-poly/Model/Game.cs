using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_poly.Model
{
    public class Game
    {
        public int Maze_x { get; set; }
        public int Maze_y { get; set; }
        public int GoalCount { get; set; }
        public int GoalsCleared { get; set; }
        public Floor First { get; set; }
        public Floor Last { get; set; }
        public Truck Truck { get; set; }

        public Game()
        {
            GoalsCleared = 0;
        }

        public bool checkWin()
        {
            GoalsCleared = 0;

            Floor temp1 = First;
            Floor temp2 = First;

            while (temp1 != Last)
            {
                if (temp1 != null)
                {
                    if(temp1.MoveableObject != null && temp1.MoveableObject.getsPoints && temp1.givesPoints)
                    {
                        GoalsCleared++;
                    }
                    temp1 = temp1.Right;
                }
                else if (temp2.Down != null)
                {
                    temp1 = temp2.Down;
                    temp2 = temp2.Down;
                }
            }
            if(Last.MoveableObject != null && Last.MoveableObject.getsPoints && Last.givesPoints)
            {
                GoalsCleared++;
            }

            if (GoalsCleared >= GoalCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool moveObject(MoveableObject moveableObject, int direction)
        {
            if (moveableObject.canMove(direction))
            {
                Floor target = null;

                switch (direction)
                {
                    case 0:
                        target = moveableObject.Location.Up;
                        break;
                    case 1:
                        target = moveableObject.Location.Down;
                        break;
                    case 2:
                        target = moveableObject.Location.Left;
                        break;
                    case 3:
                        target = moveableObject.Location.Right;
                        break;
                }

                if (target.MoveableObject != null)
                {
                    if (!target.MoveableObject.canMove(direction) || !moveObject(target.MoveableObject, direction))
                    {
                        return false;
                    }
                }
                moveableObject.Location.MoveableObject = null;
                moveableObject.Location = target;
                target.MoveableObject = moveableObject;
            }
            return true;
        }
    }
}

