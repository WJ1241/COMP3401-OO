using Microsoft.Xna.Framework;

namespace COMP3401OO_Engine.CoreInterfaces
{
    /// <summary>
    /// Interface that allows implementations to have velocity when displayed on screen
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public interface IVelocity
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows read and write access to a Vector2 velocity
        /// </summary>
        Vector2 Velocity { get; set; }

        #endregion 
    }
}
