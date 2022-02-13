using Microsoft.Xna.Framework;

namespace COMP3401OO.EnginePackage.CoreInterfaces
{
    /// <summary>
    /// Interface that allows implementations to have velocity when displayed on screen
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IVelocity
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows access to get value of an entity's velocity
        /// </summary>
        Vector2 Velocity { get; }

        #endregion 
    }
}
