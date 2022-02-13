using System.Collections.Generic;
using COMP3401OO.EnginePackage.InputManagement.Interfaces;
using COMP3401OO.EnginePackage.SceneManagement.Interfaces;

namespace COMP3401OO.EnginePackage.EntityManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to store Entities
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IEntityManager
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a reference to an ISceneManager
        /// </summary>
        /// <param name="sceneManager">Reference to ISceneManager object</param>
        void Initialise(ISceneManager sceneManager);

        /// <summary>
        /// Initialises an object with a reference to an IKeyboardPublisher
        /// </summary>
        /// <param name="kBManager">Reference to IKeyboardPublisher object</param>
        void Initialise(IKeyboardPublisher kBManager);

        /// <summary>
        /// Creates an object of IEntity, using <T> as a generic type
        /// </summary>
        /// <param name="uName">Reference to object using unique name</param>
        IEntity Create<T>(string uName) where T : IEntity, new();

        /// <summary>
        /// Returns an IDictionary<string, IEntity> which is the master Dictionary in the program
        /// </summary>
        IDictionary<string, IEntity> GetDictionary();

        /// <summary>
        /// Terminates an object from entity manager and other managers
        /// </summary>
        /// <param name="uName">Reference to object using unique name</param>
        void Terminate(string uName);

        #endregion
    }
}
