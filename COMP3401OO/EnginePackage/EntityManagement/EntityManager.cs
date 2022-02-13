using System.Collections.Generic;
using COMP3401OO.EnginePackage.Delegates.Interfaces;
using COMP3401OO.EnginePackage.EntityManagement.Interfaces;
using COMP3401OO.EnginePackage.InputManagement.Interfaces;
using COMP3401OO.EnginePackage.SceneManagement.Interfaces;

namespace COMP3401OO.EnginePackage.EntityManagement
{
    /// <summary>
    /// Class which contains the master list of entities in the game level 
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public class EntityManager : IEntityManager
    {
        #region FIELD VARIABLES

        // DECLARE an int, name it 'uIDCount', used to set unique IDs:
        private int _uIDCount;

        // DECLARE an IDictionary<string, IEntity>, name it '_entityDict':
        private IDictionary<string, IEntity> _entityDict;

        // DECLARE an ISceneManager, name it '_sceneManager':
        private ISceneManager _sceneManager;

        // DECLARE an IKeyboardPublisher, name it '_kbManager':
        private IKeyboardPublisher _kBManager;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of EntityManager
        /// </summary>
        public EntityManager()
        {
            // ASSIGNMENT, set value of _uIDCount to 0:
            _uIDCount = 0;

            // INSTANTIATE _entityDict as new Dictionary<string, IEntity>:
            _entityDict = new Dictionary<string, IEntity>();
        }

        #endregion


        #region IMPLEMENTATION OF IENTITYMANAGER

        /// <summary>
        /// Initialises an object with a reference to an ISceneManager
        /// </summary>
        /// <param name="sceneManager">Reference to ISceneManager object</param>
        public void Initialise(ISceneManager sceneManager)
        {
            // ASSIGNMENT, set instance of _sceneManager as sceneManager:
            _sceneManager = sceneManager;
        }

        /// <summary>
        /// Initialises an object with a reference to an IKeyboardPublisher
        /// </summary>
        /// <param name="kBManager">Reference to IKeyboardPublisher object</param>
        public void Initialise(IKeyboardPublisher kBManager)
        {
            // ASSIGNMENT, set instance of _kBManager as kBManager:
            _kBManager = kBManager;
        }

        /// <summary>
        /// Creates an object of IEntity, using <T> as a generic type
        /// </summary>
        /// <param name="uName">Reference to object using unique name</param>
        public IEntity Create<T>(string uName) where T : IEntity, new()
        {
            // INCREMENT iDCount by 1:
            _uIDCount++;

            // DECLARE & INSTANTIATE an IEntity as a new T(), name it _object:
            IEntity _object = new T();

            // INITIALISE _object with reference to Terminate():
            (_object as IInitialiseDeleteDel).Initialise(Terminate);
            
            // CALL generate() to initialise uID and uName:
            Generate(_object, _uIDCount, uName);

            // ADD _object to _entityDict:
            _entityDict.Add(uName, _object);

            // RETURN newly created object:
            return _entityDict[uName];
        }

        /// <summary>
        /// Terminates an object from entity manager and other managers
        /// </summary>
        /// <param name="uName">Reference to object using unique name</param>
        public void Terminate(string uName)
        {
            // CALL Terminate(), on ITerminate to dispose of resources:
            (_entityDict[uName] as ITerminate).Terminate();

            // CALL RemoveInstance(), on SceneManager to remove 'value' of key 'uName':
            _sceneManager.RemoveInstance(uName);

            // IF "uName" implements IKeyboardListener:
            if (_entityDict[uName] is IKeyboardListener)
            {
                // CALL Unsubscribe() on KeyboardManager, passing uName as a parameter
                _kBManager.Unsubscribe(uName);
            }

            // CALL Remove() on _entityDict to remove 'value' of key 'uName':
            _entityDict.Remove(uName);
        }

        /// <summary>
        /// Property which can get a reference to an IDictionary<string, IEntity>
        /// </summary>
        public IDictionary<string, IEntity> GetDictionary
        {
            get 
            {
                // RETURN value of current _entityDict:
                return _entityDict;
            }
        }

        #endregion


        #region PRIVATE METHODS

        /// <summary>
        /// Assigns unique IDs and Names to IEntity objects
        /// </summary>
        /// <typeparam name="T">Generic type substituted by a class implementing IEntity</typeparam>
        /// <param name="rqdObject">Reference to an object of IEntity</param>
        /// <param name="uID">Used to assign unique ID to entity</param>
        /// <param name="uName">Used to assign unique Name to entity</param>
        private void Generate<T>(T rqdObject, int uID, string uName) where T : IEntity
        {
            // ASSIGNMENT, set value of IEntity's UID as pID:
            rqdObject.UID = uID;

            // ASSIGNMENT, set value of IEntity's UName as uName:
            rqdObject.UName = uName;
        }

        #endregion
    }
}
