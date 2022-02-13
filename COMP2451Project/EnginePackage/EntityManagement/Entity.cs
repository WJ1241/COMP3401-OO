using Microsoft.Xna.Framework;

namespace COMP3401OO.EnginePackage.EntityManagement
{
    /// <summary>
    /// Abstract class for more specific entities to inherit from
    /// </summary>
    public abstract class Entity : IEntity, ISetBoundary, ITerminate
    {
        #region FIELD VARIABLES

        // DECLARE an int, call it '_uID', used to store unique ID:
        protected int _uID;

        // DECLARE an string, call it '_uName', used to store unique Name:
        protected string _uName;

        // DECLARE a bool, call it '_selfDestruct', used to check when an entity should be terminated:
        protected bool _selfDestruct;

        // DECLARE a Vector2, call it '_initPosition', needed to store initial location, in the case of resetting game:
        protected Vector2 _initPosition;

        // DECLARE a Vector2, call it '_position', stores current location, needed to draw texture when location(x,y) is changed
        protected Vector2 _position;

        // DECLARE a Vector2, call it '_windowBorder', used for storing screen size:
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

        /// <summary>
        /// Property which allows access to get boolean value to test if object should be terminated
        /// </summary>
        public bool SelfDestruct
        {
            get
            {
                // RETURN value of current _selfDestruct:
                return _selfDestruct;
            }
        }

        #endregion
    }
}
