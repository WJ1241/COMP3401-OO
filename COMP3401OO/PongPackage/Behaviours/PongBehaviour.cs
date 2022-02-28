using Microsoft.Xna.Framework;
using COMP3401OO.EnginePackage.Behaviours;
using COMP3401OO.EnginePackage.CoreInterfaces;
using COMP3401OO.EnginePackage.CustomEventArgs;

namespace COMP3401OO.PongPackage.Behaviours
{
    /// <summary>
    /// Class which contains an extension of Behaviour to provide more specific functionality to Pong based entities
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public abstract class PongBehaviour : Behaviour
    {
        #region IMPLEMENTATION OF IUPDATEEVENTLISTENER

        /// <summary>
        /// Event which performs any necessary update logic each time a game loop runs
        /// </summary>
        /// <param name="pSource"> Invoking object </param>
        /// <param name="pArgs"> Required arguments </param>
        public override void OnUpdate(object pSource, UpdateEventArgs pArgs)
        {
            // UPDATE _entity's position using it's current velocity:
            _entity.Position += (_entity as IVelocity).Velocity;

            // CALL Boundary():
            Boundary();
        }

        #endregion


        #region PROTECTED METHODS

        /// <summary>
        /// Used when an object hits a boundary, possibly to change direction or stop
        /// </summary>
        protected abstract void Boundary();

        #endregion
    }
}
