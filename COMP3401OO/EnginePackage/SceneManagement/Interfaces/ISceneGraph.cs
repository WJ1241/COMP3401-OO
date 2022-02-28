using System.Collections.Generic;
using COMP3401OO.EnginePackage.EntityManagement.Interfaces;

namespace COMP3401OO.EnginePackage.SceneManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to store a reference to the Dictionary in Scene Manager
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface ISceneGraph
    {
        #region METHODS

        /// <summary>
        /// Initialises object with a reference to an IDictionary<string, IEntity>
        /// </summary>
        /// <param name="pSceneDictionary">Holds reference to 'IDictionary<string, IEntity>'</param>
        void Initialise(IDictionary<string, IEntity> pSceneDictionary);

        #endregion
    }
}
