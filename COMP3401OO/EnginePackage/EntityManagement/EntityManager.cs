using System.Collections.Generic;
using COMP3401OO.EnginePackage.Delegates.Interfaces;
using COMP3401OO.EnginePackage.EntityManagement.Interfaces;
using COMP3401OO.EnginePackage.Exceptions;
using COMP3401OO.EnginePackage.Factories.Interfaces;
using COMP3401OO.EnginePackage.InputManagement.Interfaces;
using COMP3401OO.EnginePackage.SceneManagement.Interfaces;
using COMP3401OO.EnginePackage.Services.Interfaces;

namespace COMP3401OO.EnginePackage.EntityManagement
{
    /// <summary>
    /// Class which contains the master list of entities in the game level 
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public class EntityManager : IEntityManager, IInitialiseIEntityFactory, IService
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<string, IEntity>, name it '_entityDict':
        private IDictionary<string, IEntity> _entityDict;

        // DECLARE an IFactory<IEntity>, name it '_entityFactory':
        private IFactory<IEntity> _entityFactory;

        // DECLARE an ISceneManager, name it '_sceneManager':
        private ISceneManager _sceneManager;

        // DECLARE an IKeyboardPublisher, name it '_kbManager':
        private IKeyboardPublisher _kBManager;

        // DECLARE an int, name it 'uIDCount', used to set unique IDs:
        private int _uIDCount;

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
        /// <param name="pSceneManager">Reference to ISceneManager object</param>
        public void Initialise(ISceneManager pSceneManager)
        {
            // IF pSceneManager DOES HAVE an active instance:
            if (pSceneManager != null)
            {
                // INITIALISE _sceneManager with reference to pSceneManager
                _sceneManager = pSceneManager;
            }
            // IF pSceneManager DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR:pSceneManager does not have an active instance!");
            }
        }

        /// <summary>
        /// Initialises an object with a reference to an IKeyboardPublisher
        /// </summary>
        /// <param name="pKBManager">Reference to IKeyboardPublisher object</param>
        public void Initialise(IKeyboardPublisher pKBManager)
        {
            // IF pKBManager DOES HAVE an active instance:
            if (pKBManager != null)
            {
                // ASSIGNMENT, set instance of _kBManager as pKBManager:
                _kBManager = pKBManager;
            }
            // IF pKBManager DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pKBManager does not have an active instance!");
            }
        }

        /// <summary>
        /// Creates an object of IEntity, using <T> as a generic type
        /// </summary>
        /// <param name="pUName">Reference to object using unique name</param>
        public IEntity Create<T>(string pUName) where T : IEntity, new()
        {
            // INCREMENT iDCount by 1:
            _uIDCount++;

            // DECLARE & INSTANTIATE an IEntity as a new T(), name it _object:
            IEntity _object = _entityFactory.Create<T>();

            // INITIALISE _object with reference to Terminate():
            (_object as IInitialiseDeleteDel).Initialise(Terminate);
            
            // CALL generate() to initialise uID and pUName:
            Generate(_object, _uIDCount, pUName);

            // ADD pUName as a key and _object as a value to _entityDict:
            _entityDict.Add(pUName, _object);

            // RETURN newly created object:
            return _entityDict[pUName];
        }

        /// <summary>
        /// Terminates an object from entity manager and other managers
        /// </summary>
        /// <param name="uName">Reference to object using unique name</param>
        public void Terminate(string pUName)
        {
            // CALL Termination(), on ITerminate to dispose of resources:
            (_entityDict[pUName] as ITerminate).Termination();

            // CALL RemoveInstance(), on SceneManager to remove 'value' of key 'pUName':
            _sceneManager.RemoveInstance(pUName);

            // IF "uName" implements IKeyboardListener:
            if (_entityDict[pUName] is IKeyboardListener)
            {
                // CALL Unsubscribe() on KeyboardManager, passing pUName as a parameter:
                _kBManager.Unsubscribe(pUName);
            }

            // CALL Remove() on _entityDict to remove 'value' of key 'pUName':
            _entityDict.Remove(pUName);
        }

        /// <summary>
        /// Returns an IDictionary<string, IEntity> which is the master Dictionary in the program
        /// </summary>
        public IDictionary<string, IEntity> GetDictionary()
        {
            // RETURN instance of _entityDict:
            return _entityDict;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEIENTITYFACTORY

        /// <summary>
        /// Initialises an object with an IFactory<IEntity> object
        /// </summary>
        /// <param name="pFactory"> IFactory<IEntity> object </param>
        public void Initialise(IFactory<IEntity> pFactory)
        {
            // IF pFactory DOES HAVE an active instance:
            if (pFactory != null)
            {
                // INITIALISE _entityFactory with reference to pFactory:
                _entityFactory = pFactory;
            }
            // IF pFactory DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pFactory does not have an active instance!");
            }
        }

        #endregion


        #region PRIVATE METHODS

        /// <summary>
        /// Assigns unique IDs and Names to IEntity objects
        /// </summary>
        /// <typeparam name="T">Generic type substituted by a class implementing IEntity</typeparam>
        /// <param name="pRqdObject">Reference to an object of IEntity</param>
        /// <param name="pUID">Used to assign unique ID to entity</param>
        /// <param name="pUName">Used to assign unique Name to entity</param>
        private void Generate<T>(T pRqdObject, int pUID, string pUName) where T : IEntity
        {
            // ASSIGNMENT, set value of IEntity's pUID as pID:
            pRqdObject.UID = pUID;

            // ASSIGNMENT, set value of IEntity's UName as pUName:
            pRqdObject.UName = pUName;
        }

        #endregion
    }
}
