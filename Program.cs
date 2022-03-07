using Cycle.Game.Casting;
using Cycle.Game.Directing;
using Cycle.Game.Scripting;
using Cycle.Game.Services;
using Cycle.Game;


namespace Cycle
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            // cast.AddActor("food", new Food());
            int x1 = Constants.MAX_X / 2;
            int y1 = Constants.MAX_Y / 2;
            int x2 = Constants.MAX_X / 3;
            int y2 = Constants.MAX_Y / 3;
            Point startPositionOne = new Point(x1, y1);
            Point startPositionTwo = new Point(x2, y2);
            cast.AddActor("playerOne", new Player(startPositionOne));
            cast.AddActor("playerTwo", new Player(startPositionTwo));
            // cast.AddActor("score", new Score());

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlPlayerOneAction(keyboardService));
            script.AddAction("input", new ControlPlayerTwoAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}