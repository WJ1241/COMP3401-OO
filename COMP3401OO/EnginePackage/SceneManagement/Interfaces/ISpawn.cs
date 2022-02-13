using Microsoft.Xna.Framework;
using COMP3401OO.EnginePackage.EntityManagement.Interfaces;

namespace COMP3401OO.EnginePackage.SceneManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to be spawned on screen
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface ISpawn
    {
        #region METHODS

        /// <summary>
        /// Spawns Entity on screen and adds to a list/dictionary
        /// </summary>
        /// <param name="entity">Reference to an instance of IEntity</param>
        /// <param name="position">Positional values used to place entity</param>
        void Spawn(IEntity entity, Vector2 position);

        #endregion
    }
}
