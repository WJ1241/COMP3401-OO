using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using COMP3401OO_Engine.CoreInterfaces;
using COMP3401OO_Engine.EntityManagement.Interfaces;
using COMP3401OO_Engine.SceneManagement.Interfaces;
using COMP3401OO_Engine.Services.Interfaces;
using COMP3401OO_Engine.Exceptions;

namespace COMP3401OO_Engine.SceneManagement
{
    /// <summary>
    /// Class which holds reference to list in Scene Manager, Draws and Updates entities
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public class SceneGraph : ISceneGraph, IUpdatable, IDraw, IService, ISpawn
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<string, IEntity>, name it '_entityDictionary':
        private IDictionary<string, IEntity> _sceneDictionary;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of SceneGraph
        /// </summary>
        public SceneGraph()
        {
            // EMPTY CONSTRUCTOR
        }

        #endregion


        #region IMPLEMENTATION OF ISCENEGRAPH

        /// <summary>
        /// Initialises object with a reference to an IDictionary<string, IEntity>
        /// </summary>
        /// <param name="pSceneDictionary">Holds reference to 'IDictionary<string, IEntity>'</param>
        public void Initialise(IDictionary<string, IEntity> pSceneDictionary)
        {
            // IF pSceneManager DOES HAVE an active instance:
            if (pSceneDictionary != null)
            {
                // INITIALISE _sceneDictionary with reference to pSceneDictionary:
                _sceneDictionary = pSceneDictionary;
            }
            // IF pSceneManager DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pSceneDictionary does not have an active instance!");
            }
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
            // ASSIGN pEntity.Position as the same value as pPosition:
            pEntity.Position = pPosition;
        }

        #endregion


        #region IMPLEMENTATION OF IDRAW

        /// <summary>
        /// When called, draws entity's texture on screen
        /// </summary>
        /// <param name="pSpriteBatch">Needed to draw entity's texture on screen</param>
        public void Draw(SpriteBatch pSpriteBatch)
        {
            // FOREACH any entity implementing IDraw:
            foreach (IDraw pEntity in _sceneDictionary.Values)
            {
                // CALL Draw method on all entities in _entityDictionary:
                pEntity.Draw(pSpriteBatch);
            }
        }

        #endregion


        #region IMPLEMENTATION OF IUPDATABLE

        /// <summary>
        /// Updates object when a frame has been rendered on screen
        /// </summary>
        /// <param name="pGameTime">holds reference to GameTime object</param>
        public void Update(GameTime pGameTime)
        {
            // FOREACH any entity implementing IUpdatable:
            // NEED TO USE TOLIST() AS COLLECTION IS MODIFIED WHEN THIS METHOD IS STILL BEING CALLED
            foreach (IEntity pEntity in _sceneDictionary.Values.ToList())
            {
                // IF pEntity implements IUpdatable:
                if (pEntity is IUpdatable)
                {
                    // CALL Update method on all updatable entities in _entityDictionary:
                    (pEntity as IUpdatable).Update(pGameTime);
                }
            }
        }

        #endregion
    }
}
