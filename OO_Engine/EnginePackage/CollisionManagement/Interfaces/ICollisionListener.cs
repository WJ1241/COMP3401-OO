

namespace COMP3401OO_Engine.CollisionManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to listen for collisions with other objects
    /// Author: William Smith
    /// Date: 23/02/22
    /// </summary>
    public interface ICollisionListener
    {
        #region METHODS

        /// <summary>
        /// Called by Collision Manager when two entities collide
        /// </summary>
        /// <param name="pScndCollidable">Other entity implementing ICollidable</param>
        void OnCollision(ICollidable pScndCollidable);

        #endregion
    }
}
