using System;
using Microsoft.Xna.Framework.Input;

namespace COMP3401OO.EnginePackage.CustomEventArgs
{
    /// <summary>
    /// Class which is used to contain any required arguments related to a keyboard input
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public class KBEventArgs : EventArgs
    {
        #region FIELD VARIABLES

        // DECLARE a KeyboardState, name it '_keyboardState':
        private KeyboardState _keyboardState;

        #endregion


        #region PROPERTIES

        /// <summary>
        /// Property which allows read and write access to a KeyboardState argument
        /// </summary>
        public KeyboardState RequiredArg
        {
            get
            {
                // RETURN value of _keyboardState:
                return _keyboardState;
            }
            set
            {
                // SET value of _keyboardState to incoming value:
                _keyboardState = value;
            }
        }

        #endregion
    }
}