using System;
using Microsoft.Xna.Framework.Input;

namespace COMP3401OO.EnginePackage.CustomEventArgs
{
    /// <summary>
    /// Class which is used to contain any required arguments related to a mouse input
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public class MouseEventArgs : EventArgs
    {
        #region FIELD VARIABLES

        // DECLARE a MouseState, name it '_mouseState':
        private MouseState _mouseState;

        #endregion


        #region PROPERTIES

        /// <summary>
        /// Property which allows read and write access to a MouseState argument
        /// </summary>
        public MouseState RequiredArg
        {
            get
            {
                // RETURN value of _mouseState:
                return _mouseState;
            }
            set
            {
                // SET value of _mouseState to incoming value:
                _mouseState = value;
            }
        }

        #endregion
    }
}
