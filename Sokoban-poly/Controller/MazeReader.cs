using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban_poly.Model;
using Sokoban_poly.Model.Model.FieldObjects;

namespace Sokoban_poly.Controller
{
    public class MazeReader
    {
        string[] levelStrings;
        Floor[,] levelSquares;
        Game game;

        public MazeReader(Game game)
        {
            this.game = game;
        }

        public Floor[,] ReadMaze(int mazeNumber)
        {
            int x = 0;
            int y = 0;
            int goalCount = 0;

            levelStrings = System.IO.File.ReadAllLines(@"C:\Users\Acer\Desktop\Doolhof\doolhof" + mazeNumber + ".txt");
            levelSquares = new Floor[levelStrings.Length, levelStrings[x].Length];

            for (y = 0; y < levelStrings.Length; y++)
            {
                for (x = 0; x < levelStrings[y].Length; x++)
                {
                    switch (levelStrings[y][x])
                    {
                        case '#':
                            levelSquares[y, x] = new Wall(game);
                            break;
                        case '.':
                            levelSquares[y, x] = new Floor(game);
                            break;
                        case 'x':
                            levelSquares[y, x] = new Goal(game);
                            goalCount++;
                            break;
                        case 'o':
                            levelSquares[y, x] = new Floor(game);
                            levelSquares[y, x].MoveableObject = new Crate();
                            levelSquares[y, x].MoveableObject.Location = levelSquares[y, x];
                            break;
                        case '@':
                            levelSquares[y, x] = new Floor(game);
                            game.Truck = new Truck();
                            levelSquares[y, x].MoveableObject = game.Truck;
                            levelSquares[y, x].MoveableObject.Location = levelSquares[y, x];
                            break;
                        case ' ':
                            levelSquares[y, x] = new Space(game);
                            break;
                        default:
                            levelSquares[y, x] = null;
                            Console.WriteLine("Unidentified char at " + x + "," + y);
                            break;
                    }

                }
            }
            game.GoalCount = goalCount;
            return levelSquares;
        }

        public void CreateLinks(Floor[,] fields)
        {
            game.First = fields[0, 0];
            game.Last = fields[fields.GetLength(0) - 1, fields.GetLength(1) - 1];

            for (int y = 0; y < fields.GetLength(0); y++)
            {
                for (int x = 0; x < fields.GetLength(1); x++)
                {
                    if (x + 1 != fields.GetLength(1) && fields[y, x + 1] != null)
                    {
                        fields[y, x].Right = fields[y, x + 1];
                        fields[y, x + 1].Left = fields[y, x];
                    }
                    if (y + 1 != fields.GetLength(0) && fields[y + 1, x] != null)
                    {
                        fields[y, x].Down = fields[y + 1, x];
                        fields[y + 1, x].Up = fields[y, x];
                    }
                }
            }

            fields = null;
            levelSquares = null;
            levelStrings = null;
               
        }
    }
}
