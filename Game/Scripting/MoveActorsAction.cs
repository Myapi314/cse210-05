using System.Collections.Generic;
using Cycle.Game.Casting;


namespace Cycle.Game.Scripting
{
    // TODO: Implement the MoveActorsAction class here

    // 1) Add the class declaration. Use the following class comment. Make sure you
    //    inherit from the Action class.

    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of MoveActorsAction is to move all the actors.
    /// </para>
    /// </summary>
    public class MoveActorsAction : Action
    {
        /// <summary>
        /// Constructs a new instance of MoveActorsAction.
        /// </summary>
        public MoveActorsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // Get all the actors from the cast. 
            List<Actor> actors = cast.GetAllActors();

            // Loop through all the actors. 
            foreach (Actor actor in actors)
            {
                // Call the MoveNext() method on each actor. 
                actor.MoveNext();
            }
        }
    }
}