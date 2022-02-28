using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using COMP3401OO.EnginePackage.CoreInterfaces;
using COMP3401OO.EnginePackage.CollisionManagement.Interfaces;
using COMP3401OO.EnginePackage.EntityManagement.Interfaces;
using COMP3401OO.EnginePackage.SceneManagement.Interfaces;
using COMP3401OO.EnginePackage.Services.Interfaces;
using COMP3401OO.EnginePackage.Exceptions;

namespace COMP3401OO.EnginePackage.SceneManagement
{
    /// <summary>
    /// Class which manages all entities in the scene
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public class SceneManager : ISceneManager, IUpdatable, IDraw, IService, ISpawn
    {
        #region FIELD VARIABLES

        // DECLARE an ISceneGraph, name it 'sceneGraph':
        private ISceneGraph _sceneGraph;

        // DECLARE an IDictionary<string, IEntity>, name it '_sceneDictionary':
        private IDictionary<string, IEntity> _sceneDictionary;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of SceneManager
        /// </summary>
        public SceneManager()
        {
            // INSTANTIATE _sceneDictionary as new Dictionary<string, IEntity>:
            _sceneDictionary = new Dictionary<string, IEntity>();
        }

        #endregion


        #region IMPLEMENTATION OF ISCENEMANAGER

        /// <summary>
        /// Initialises an object with a reference to an ISceneGraph
        /// </summary>
        /// <param name="pSceneGraph">Holds References to an ISceneGraph</param>
        public void Initialise(ISceneGraph pSceneGraph) 
        {
            // IF pSceneGraph DOES HAVE an active instance:
            if (pSceneGraph != null)
            {
                // INITIALISE _sceneGraph with reference to pSceneGraph:
                _sceneGraph = pSceneGraph;

                // TRY checking if Initialise() throws a NullInstanceException:
                try
                {
                    // INITIALISE _sceneGraph with a reference to _sceneDictionary:
                    _sceneGraph.Initialise(_sceneDictionary);
                }
                // CATCH NullInstanceException from Initialise() 
                catch (NullInstanceException e)
                {
                    // PRINT exception message to console:
                    Console.WriteLine(e.Message);
                }
            }
            // IF pSceneGraph DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message
                throw new NullInstanceException("ERROR: pSceneGraph does not have an active instance!");
            }
        }

        /// <summary>
        /// Initialises an object with a reference to an ICollisionManager
        /// </summary>
        /// <param name="pCollisionManager">Holds References to an ICollisionManager</param>
        public void Initialise(ICollisionManager pCollisionManager) 
        {
            // INITIALISE pCollisionManager, passing _sceneDictionary cast as an IReadOnlyDictionary<string, IEntity>, as a parameter:
            pCollisionManager.Initialise((IReadOnlyDictionary<string, IEntity>) _sceneDictionary);
        }

        /// <summary>
        /// Returns an IDictionary<string, IEntity> containing entities in the scene
        /// </summary>
        public IDictionary<string, IEntity> GetDictionary()
        {
            // RETURN instance of _sceneDictionary():
            return _sceneDictionary;
        }

        /// <summary>
        /// Removes instance of object from list/dictionary using an entity's unique name
        /// </summary>
        /// <param name="pUName">Used for passing unique name</param>
        public void RemoveInstance(string pUName)
        {
            // CALL Remove(), on Dictionary to remove 'value' of key 'pUName':
            _sceneDictionary.Remove(pUName);

            // WRITE to console, alerting when object has been removed from scene:
            Console.WriteLine(pUName + " has been Removed from Scene!");
        }

        #endregion


        #region IMPLEMENTATION OF ISPAWN

        /// <summary>
        /// Spawns Entity on screen and adds to a list/dictionary
        /// </summary>
        /// <param name="pEntity">Reference to an instance of IEntity</param>
        /// <param name="pPosition">Positional values used to place entity</param>
        public void Spawn(IEntity pEntity, Vector2 pPosition)
        {
            // ADD pEntity to Dictionary<string, IEntity>:
            _sceneDictionary.Add(pEntity.UName, pEntity);

            // CALL Spawn() on _sceneGraph, passing entity and position as parameters:
            (_sceneGraph as ISpawn).Spawn(pEntity, pPosition);

            // WRITE to console, alerting when object has been added to the scene:
            Console.WriteLine(pEntity.UName + " ID:" + pEntity.UID + " has been Spawned on Scene!");
        }

        #endregion


        #region IMPLEMENTATION OF IDRAW

        /// <summary>
        /// When called, draws entity's texture on screen
        /// </summary>
        /// <param name="pSpriteBatch">Needed to draw entity's texture on screen</param>
        public void Draw(SpriteBatch pSpriteBatch)
        {
            // CALL Draw() on _sceneGraph, passing pSpriteBatch as a parameter:
            (_sceneGraph as IDraw).Draw(pSpriteBatch);
        }

        #endregion


        #region IMPLEMENTATION OF IUPDATABLE

        /// <summary>
        /// Updates object when a frame has been rendered on screen
        /// </summary>
        /// <param name="pGameTime">holds reference to GameTime object</param>
        public void Update(GameTime pGameTime)
        {
            // CALL Update() on _sceneGraph, passing pGameTime as a parameter:
            (_sceneGraph as IUpdatable).Update(pGameTime);
        }

        #endregion
    }
}