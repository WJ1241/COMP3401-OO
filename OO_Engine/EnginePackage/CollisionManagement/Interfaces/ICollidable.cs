using Microsoft.Xna.Framework;

namespace COMP3401OO_Engine.CollisionManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to have a HitBox
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public interface ICollidable
    {
        #region PROPERTIES

        /// <summary>
        /// Used to Return a Rectangle object to caller of property
        /// </summary>
        Rectangle HitBox { get; }

        #endregion
    }
}
