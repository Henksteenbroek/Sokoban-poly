using Sokoban_poly.Model;
using Sokoban_poly.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_poly.Controller
{
    public class MainController
    {
        Game game;
        MazeReader reader;
        InputView inputView;
        MazeView mazeView;
        public MainController()
        {
            game = new Game();
            reader = new MazeReader(game);
            reader.CreateLinks(reader.ReadMaze(1));
            mazeView = new MazeView(game);
            inputView = new InputView();
            run();
        }

        public void run()
        {
            mazeView.showStartingScreen();
            reader.CreateLinks(reader.ReadMaze(inputView.getMazeNumber()));
            while (true)
            {
                mazeView.showBoard();
                int input = inputView.readInput(inputView.validInputGiven());
                if (input >= 0)
                {
                    game.moveObject(game.Truck, input);
                }
                else if (input == -1)
                {

                }
                else
                {
                    mazeView.showStartingScreen();
                    reader.CreateLinks(reader.ReadMaze(inputView.getMazeNumber()));
                }
                Console.WriteLine(game.GoalsCleared);
            }
        }
    }
}
