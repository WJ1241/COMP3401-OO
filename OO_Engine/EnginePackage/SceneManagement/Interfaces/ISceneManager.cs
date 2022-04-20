using System.Collections.Generic;
using COMP3401OO_Engine.CollisionManagement.Interfaces;
using COMP3401OO_Engine.EntityManagement.Interfaces;

namespace COMP3401OO_Engine.SceneManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to manage entities in the scene
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface ISceneManager
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a reference to an ISceneGraph
        /// </summary>
        /// <param name="pSceneGraph">Holds References to an ISceneGraph</param>
        void Initialise(ISceneGraph pSceneGraph);

        /// <summary>
        /// Initialises an object with a reference to an ICollisionManager
        /// </summary>
        /// <param name="pCollisionManager">Holds References to an ICollisionManager</param>
        void Initialise(ICollisionManager pCollisionManager);

        /// <summary>
        /// Returns an IDictionary<string, IEntity> containing entities in the scene
        /// </summary>
        IDictionary<string, IEntity> GetDictionary();

        /// <summary>
        /// Removes instance of object from list/dictionary using an entity's unique name
        /// </summary>
        /// <param name="pUName">Used for passing unique name</param>
        void RemoveInstance(string pUName);

        #endregion
    }
}
