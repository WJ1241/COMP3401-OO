using System;
using Microsoft.Xna.Framework;
using COMP3401OO_Engine.Delegates;
using COMP3401OO_Engine.EntityManagement.Interfaces;
using COMP3401OO_Engine.CoreInterfaces;

namespace COMP3401OO_Engine.EntityManagement
{
    /// <summary>
    /// Abstract class for more specific entities to inherit from
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public abstract class Entity : IEntity, IInitialiseParam<DeleteDelegate>, IContainBoundary, ITerminate
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

        // DECLARE a Point, name it '_windowBorder', used for storing screen size:
        protected Point _windowBorder;

        #endregion


        #region IMPLEMENTATION OF IENTITY

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


        #region IMPLEMENTATION OF IINITIALISEPARAM<DELETEDELEGATE>

        /// <summary>
        /// Initialises an object with a DeleteDelegate
        /// </summary>
        /// <param name="pDeleteDelegate"> Method which meets the signature of DeleteDelegate </param>
        public void Initialise(DeleteDelegate pDeleteDelegate)
        {
            // IF pDeleteDelegate DOES contain a valid method reference:
            if (pDeleteDelegate != null)
            {
                // INITIALISE _terminate with reference to pDeleteDelegate:
                _terminate = pDeleteDelegate;
            }
            // IF pCheckPosDel DOES NOT contain a valid method reference:
            else
            {
                // THROW a new NullReferenceException(), with corresponding message:
                throw new NullReferenceException("ERROR: pDeleteDelegate does not contain a valid method reference!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF ICONTAINBOUNDARY

        /// <summary>
        /// Property which allows read and write access to screen borders
        /// </summary>
        public Point WindowBorder
        {
            get
            {
                // RETURN value of _windowborder:
                return _windowBorder;
            }
            set
            {
                // SET value of _windowBorder to incoming value:
                _windowBorder = value;
            }
        }

        #endregion


        #region IMPLEMENTATION OF ITERMINATE

        /// <summary>
        /// Disposes resources to the garbage collector
        /// </summary>
        public abstract void Termination();

        /// <summary>
        /// Property which allows only read access to a DeleteDelegate
        /// </summary>
        public DeleteDelegate Terminate
        {
            get
            {
                // RETURN value of _terminate:
                return _terminate;
            }
        }

        #endregion
    }
}
