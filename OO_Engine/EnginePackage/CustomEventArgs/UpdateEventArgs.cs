using System;
using Microsoft.Xna.Framework;

namespace COMP3401OO_Engine.CustomEventArgs
{
    /// <summary>
    /// Class which is used to contain any required arguments related to a game loop
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public class UpdateEventArgs : EventArgs
    {
        #region FIELD VARIABLES

        // DECLARE a GameTime, name it '_gameTime':
        private GameTime _gameTime;

        #endregion


        #region PROPERTIES

        /// <summary>
        /// Property which allows read and write access to a GameTime argument
        /// </summary>
        public GameTime RequiredArg
        {
            get
            {
                // RETURN value of _gameTime:
                return _gameTime;
            }
            set
            {
                // SET value of _gameTime to incoming value:
                _gameTime = value;
            }
        }

        #endregion
    }
}
