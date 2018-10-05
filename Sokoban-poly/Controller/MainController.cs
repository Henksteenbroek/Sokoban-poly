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
            int mazeNumber = inputView.getMazeNumber();
            reader.CreateLinks(reader.ReadMaze(mazeNumber));
            while (!game.checkWin())
            {
                mazeView.showBoard();
                int input = inputView.readInput(inputView.validInputGiven());
                if (input >= 0)
                {
                    game.Truck.move(input);
                }
                else if (input == -1)
                {
                    reader.CreateLinks(reader.ReadMaze(mazeNumber));
                }
                else
                {
                    mazeView.showStartingScreen();
                    mazeNumber = inputView.getMazeNumber();
                    reader.CreateLinks(reader.ReadMaze(mazeNumber));
                }
                
            }
            mazeView.gameWon();
            Console.ReadLine();
            run();
        }
    }
}
