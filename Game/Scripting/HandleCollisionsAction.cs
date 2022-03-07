using System;
using System.Collections.Generic;
using System.Data;
using Cycle.Game.Casting;
using Cycle.Game.Services;


namespace Cycle.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private string gameOverMsg = "";

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                // HandleFoodCollisions(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>

        // private void HandleFoodCollisions(Cast cast)
        // {
        //     Player playerOne = (Player)cast.GetFirstActor("playerOne");
        //     Player playerTwo = (Player)cast.GetFirstActor("playerTwo");
            // Score score = (Score)cast.GetFirstActor("score");
            // Food food = (Food)cast.GetFirstActor("food");
            
            // if (playerOne.GetHead().GetPosition().Equals(food.GetPosition()))
            // {
            //     int points = food.GetPoints();
            //     playerOne.GrowTail(points);
            //     score.AddPoints(points);
            //     food.Reset();
            // }
        // }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Player playerOne = (Player)cast.GetFirstActor("playerOne");
            Player playerTwo = (Player)cast.GetFirstActor("playerTwo");
            Actor headOne = playerOne.GetHead();
            Actor headTwo = playerTwo.GetHead();
            List<Actor> bodyOne = playerOne.GetBody();
            List<Actor> bodyTwo = playerTwo.GetBody();

            foreach (Actor segment in bodyOne)
            {
                if (segment.GetPosition().Equals(headOne.GetPosition()))
                {
                    isGameOver = true;
                    gameOverMsg = "Self-burn that's rare! Player One Loses!";
                }
                else if (segment.GetPosition().Equals(headTwo.GetPosition()))
                {
                    isGameOver = true;
                    gameOverMsg = "Player Two Loses!";
                }
            }
            foreach (Actor segment in bodyTwo)
            {
                if (segment.GetPosition().Equals(headTwo.GetPosition()))
                {
                    isGameOver = true;
                    gameOverMsg = "Self-burn that's rare! Player Two Loses!";
                }
                else if (segment.GetPosition().Equals(headOne.GetPosition()))
                {
                    isGameOver = true;
                    gameOverMsg = "Player One Loses!";
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Player playerOne = (Player)cast.GetFirstActor("playerOne");
                Player playerTwo = (Player)cast.GetFirstActor("playerTwo");
                List<Actor> segmentsOne = playerOne.GetSegments();
                List<Actor> segmentsTwo = playerTwo.GetSegments();
                // Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText($"Game Over!\n{gameOverMsg}");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segmentsOne)
                {
                    segment.SetColor(Constants.WHITE);
                }
                foreach (Actor segment in segmentsTwo)
                {
                    segment.SetColor(Constants.WHITE);
                }
                // food.SetColor(Constants.WHITE);
            }
        }

    }
}