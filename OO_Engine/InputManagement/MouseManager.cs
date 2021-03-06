using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using COMP3401OO_Engine.CoreInterfaces;
using COMP3401OO_Engine.EntityManagement.Interfaces;
using COMP3401OO_Engine.InputManagement.Interfaces;
using COMP3401OO_Engine.Services.Interfaces;

namespace COMP3401OO_Engine.InputManagement
{
    /// <summary>
    /// Class which manages all entities listening for Mouse input
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public class MouseManager : IUpdatable, IMousePublisher, IService
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<string, IMouseListener>, name it '_mouseListeners':
        private IDictionary<string, IMouseListener> _mouseListeners;

        // DECLARE a MouseState, name it '_mouseState':
        private MouseState _mouseState;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of MouseManager
        /// </summary>
        public MouseManager()
        {
            // INSTANTIATE _mouseListeners as new Dictionary<string, IMouseListener>:
            _mouseListeners = new Dictionary<string, IMouseListener>();
        }

        #endregion


        #region IMPLEMENTATION OF IKEYBOARDPUBLISHER

        /// <summary>
        /// Subscribes a Mouse listening object to be stored in a list/dictionary
        /// </summary>
        /// <param name="pMouseListener">Reference to an object implementing IMouseListener</param>
        public void Subscribe(IMouseListener pMouseListener)
        {
            // ADD pMouseListener to Dictionary<string, IMouseListener>:
            _mouseListeners.Add((pMouseListener as IEntity).UName, pMouseListener);
        }

        /// <summary>
        /// Unsubscribes a Mouse listening object from list/dictionary using its unique name
        /// </summary>
        /// <param name="pUName">Used for passing unique name</param>
        public void Unsubscribe(string pUName)
        {
            // CALL Remove(), on Dictionary to remove 'value' of key 'pUName':
            _mouseListeners.Remove(pUName);
        }

        #endregion


        #region IMPLEMENTATION OF IUPDATABLE

        /// <summary>
        /// Updates object when a frame has been rendered on screen
        /// </summary>
        /// <param name="pGameTime">holds reference to GameTime object</param>
        public void Update(GameTime pGameTime)
        {
            // ASSIGNMENT, use GetState() to get what keys have been activated:
            _mouseState = Mouse.GetState();

            // FOREACH IMouseListener object in _mouseListeners:
            foreach (IMouseListener pMouseListener in _mouseListeners.Values) 
            {
                // CALL 'OnMouseInput()' passing pMouseState as a parameter, used to get Mouse input:
                pMouseListener.OnMouseInput(_mouseState);
            }
        }

        #endregion
    }
}
