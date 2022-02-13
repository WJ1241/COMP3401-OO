using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using COMP3401OO.EnginePackage.CollisionManagement;
using COMP3401OO.EnginePackage.CoreInterfaces;
using COMP3401OO.EnginePackage.EntityManagement;

namespace COMP3401OO.EnginePackage.SceneManagement
{
    /// <summary>
    /// Class which manages all entities in the scene
    /// </summary>
    public class SceneManager : ISceneManager, IUpdatable, IDraw, ISpawn
    {
        #region FIELD VARIABLES

        // DECLARE a ISceneGraph, call it 'sceneGraph':
        private ISceneGraph _sceneGraph;

        // DECLARE a IDictionary<string, IEntity>, call it '_sceneDictionary':
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
        /// <param name="sceneGraph">Holds References to an ISceneGraph</param>
        public void Initialise(ISceneGraph sceneGraph) 
        {
            // ASSIGNMENT, set instance of _sceneGraph as the same as sceneGraph:
            _sceneGraph = sceneGraph;

            // INITIALISE _sceneGraph, passing _sceneDictionary as a parameter:
            _sceneGraph.Initialise(_sceneDictionary);
        }

        /// <summary>
        /// Initialises an object with a reference to an ICollisionManager
        /// </summary>
        /// <param name="collisionManager">Holds References to an ICollisionManager</param>
        public void Initialise(ICollisionManager collisionManager) 
        {
            // INITIALISE _collisionManager, passing _sceneDictionary cast as an IReadOnlyDictionary<string, IEntity>, as a parameter:
            collisionManager.Initialise((IReadOnlyDictionary<string, IEntity>) _sceneDictionary);
        }

        /// <summary>
        /// Removes instance of object from list/dictionary using an entity's unique name
        /// </summary>
        /// <param name="uName">Used for passing unique name</param>
        public void RemoveInstance(string uName)
        {
            // CALL Remove(), on Dictionary to remove 'value' of key 'uName':
            _sceneDictionary.Remove(uName);

            // WRITE to console, alerting when object has been removed from scene:
            Console.WriteLine(uName + " has been Removed from Scene!");
        }

        #endregion


        #region IMPLEMENTATION OF ISPAWN

        /// <summary>
        /// Spawns Entity on screen and adds to a list/dictionary
        /// </summary>
        /// <param name="entity">Reference to an instance of IEntity</param>
        /// <param name="position">Positional values used to place entity</param>
        public void Spawn(IEntity entity, Vector2 position)
        {
            // ADD entity to Dictionary<string, IEntity>:
            _sceneDictionary.Add(entity.UName, entity);

            // CALL Spawn() on _sceneGraph, passing entity and position as parameters:
            (_sceneGraph as ISpawn).Spawn(entity, position);

            // WRITE to console, alerting when object has been added to the scene:
            Console.WriteLine(entity.UName + " ID:" + entity.UID + " has been Spawned on Scene!");
        }

        #endregion


        #region IMPLEMENTATION OF IDRAW

        /// <summary>
        /// When called, draws entity's texture on screen
        /// </summary>
        /// <param name="spritebatch">Needed to draw entity's texture on screen</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // CALL Draw() on _sceneGraph, passing spriteBatch as a parameter:
            (_sceneGraph as IDraw).Draw(spriteBatch);
        }

        #endregion


        #region IMPLEMENTATION OF IUPDATABLE

        /// <summary>
        /// Updates object when a frame has been rendered on screen
        /// </summary>
        /// <param name="gameTime">holds reference to GameTime object</param>
        public void Update(GameTime gameTime)
        {
            // CALL Update() on _sceneGraph, passing gameTime as a parameter:
            (_sceneGraph as IUpdatable).Update(gameTime);
        }

        #endregion
    }
}