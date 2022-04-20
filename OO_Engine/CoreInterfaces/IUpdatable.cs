using Microsoft.Xna.Framework;

namespace COMP3401OO_Engine.CoreInterfaces
{
    /// <summary>
    /// Interface that allows implementations to be updated with a GameTime object
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IUpdatable
    {
        #region METHODS

        /// <summary>
        /// Updates object when a frame has been rendered on screen
        /// </summary>
        /// <param name="pGameTime">holds reference to GameTime object</param>
        void Update(GameTime pGameTime);

        #endregion
    }
}
