using System.Collections.Generic;
using Cycle.Game.Casting;
using Cycle.Game.Services;


namespace Cycle.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Player playerOne = (Player)cast.GetFirstActor("playerOne");
            Player playerTwo = (Player)cast.GetFirstActor("playerTwo");
            List<Actor> segmentsOne = playerOne.GetSegments();
            List<Actor> segmentsTwo = playerTwo.GetSegments();
            // Actor score = cast.GetFirstActor("score");
            // Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segmentsOne);
            videoService.DrawActors(segmentsTwo);
            // videoService.DrawActor(score);
            // videoService.DrawActor(food);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}