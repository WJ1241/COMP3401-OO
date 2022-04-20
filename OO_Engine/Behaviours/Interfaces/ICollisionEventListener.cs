using COMP3401OO_Engine.CustomEventArgs;

namespace COMP3401OO_Engine.Behaviours.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to listen for objects invoking a collision event
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public interface ICollisionEventListener
    {
        #region METHODS

        /// <summary>
        /// Event which performs any necessary update logic each time a collision occurs
        /// </summary>
        /// <param name="pSource"> Invoking object </param>
        /// <param name="pArgs"> Required arguments </param>
        void OnCollision(object pSource, CollisionEventArgs pArgs);

        #endregion
    }
}
