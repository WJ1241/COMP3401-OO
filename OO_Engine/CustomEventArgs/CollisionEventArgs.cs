using System;
using COMP3401OO_Engine.CollisionManagement.Interfaces;

namespace COMP3401OO_Engine.CustomEventArgs
{
    /// <summary>
    /// Class which is used to contain any required arguments related to a collision
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public class CollisionEventArgs : EventArgs
    {
        #region FIELD VARIABLES

        // DECLARE a GameTime, name it '_collidable':
        private ICollidable _collidable;

        #endregion


        #region PROPERTIES

        /// <summary>
        /// Property which allows read and write access to an ICollidable argument
        /// </summary>
        public ICollidable RequiredArg
        {
            get
            {
                // RETURN value of _collidable:
                return _collidable;
            }
            set
            {
                // SET value of _collidable to incoming value:
                _collidable = value;
            }
        }

        #endregion
    }
}
