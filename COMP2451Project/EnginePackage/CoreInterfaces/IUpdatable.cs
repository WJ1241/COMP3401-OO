using Microsoft.Xna.Framework;

namespace COMP3401OO.EnginePackage.CoreInterfaces
{
    /// <summary>
    /// Interface that allows implementations to be updated with a GameTime object
    /// </summary>
    public interface IUpdatable
    {
        #region METHODS

        /// <summary>
        /// Updates object when a frame has been rendered on screen
        /// </summary>
        /// <param name="gameTime">holds reference to GameTime object</param>
        void Update(GameTime gameTime);

        #endregion
    }
}
