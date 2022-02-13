using System.Collections.Generic;
using COMP3401OO.EnginePackage.EntityManagement;

namespace COMP3401OO.EnginePackage.SceneManagement
{
    /// <summary>
    /// Interface that allows implementations to store a reference to the Dictionary in Scene Manager
    /// </summary>
    public interface ISceneGraph
    {
        #region METHODS

        /// <summary>
        /// Initialises object with a reference to an IDictionary<string, IEntity>
        /// </summary>
        /// <param name="sceneDictionary">Holds reference to 'IDictionary<string, IEntity>'</param>
        void Initialise(IDictionary<string, IEntity> sceneDictionary);

        #endregion
    }
}
