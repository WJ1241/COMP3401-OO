using Microsoft.Xna.Framework;
using COMP3401OO.EnginePackage.Delegates;
using COMP3401OO.EnginePackage.Delegates.Interfaces;
using COMP3401OO.EnginePackage.EntityManagement.Interfaces;

namespace COMP3401OO.EnginePackage.EntityManagement
{
    /// <summary>
    /// Abstract class for more specific entities to inherit from
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public abstract class Entity : IEntity, IInitialiseDeleteDel, ISetBoundary, ITerminate
    {
        #region FIELD VARIABLES

        // DECLARE a DeleteDelegate, name it '_terminate', used to remove any entity references:
        protected DeleteDelegate _terminate;

        // DECLARE an int, name it '_uID', used to store unique ID:
        protected int _uID;

        // DECLARE a string, name it '_uName', used to store unique Name:
        protected string _uName;

        // DECLARE a Vector2, name it '_initPosition', needed to store initial location, in the case of resetting game:
        protected Vector2 _initPosition;

        // DECLARE a Vector2, name it '_position', stores current location, needed to draw texture when location(x,y) is changed
        protected Vector2 _position;

        // DECLARE a Vector2, name it '_windowBorder', used for storing screen size:
        protected Vector2 _windowBorder;

        #endregion


        #region IMPLEMENTATION OF IENTITY

        /// <summary>
        /// Initialises entity variable values
        /// </summary>
        public abstract void Initialise();

        /// <summary>
        /// Property which can get and set value of an entity's position
        /// </summary>
        public Vector2 Position
        {
            get
            {
                // RETURN value of current location(x,y):
                return _position;
            }
            set
            {
                // ASSIGNMENT give location(x,y) value of external class modified value:
                _position = value;
            }
        }

        /// <summary>
        /// Property which can get and set value of an entity's unique ID
        /// </summary>
        public int UID 
        {
            get
            {
                // RETURN value of current _uID:
                return _uID;
            }
            set 
            {
                // ASSIGNMENT give _uID value of external class modified value:
                _uID = value;
            }
        }

        /// <summary>
        /// Property which can get and set value of an entity's unique Name
        /// </summary>
        public string UName 
        {
            get 
            {
                // RETURN value of current _uName:
                return _uName;
            }
            set 
            {
                // ASSIGNMENT give _uName value of external class modified value:
                _uName = value;
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEDELETEDEL

        /// <summary>
        /// Initialises an object with a DeleteDelegate
        /// </summary>
        /// <param name="pDeleteDelegate"> Method which meets the signature of DeleteDelegate </param>
        public void Initialise(DeleteDelegate pDeleteDelegate)
        {
            // INITIALISE _terminate with reference to pDeleteDelegate:
            _terminate = pDeleteDelegate;
        }

        #endregion


        #region IMPLEMENTATION OF ISETBOUNDARY

        /// <summary>
        /// Property which can set value of screen window borders
        /// </summary>
        public Vector2 WindowBorder
        {
            set
            {
                // ASSIGNMENT give _windowBorder value of external class modified value:
                _windowBorder = value;
            }
        }

        #endregion


        #region IMPLEMENTATION OF ITERMINATE

        /// <summary>
        /// Disposes resources to the garbage collector
        /// </summary>
        public abstract void Terminate();

        #endregion
    }
}
