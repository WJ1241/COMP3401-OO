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
    /// Class which manages all entities listening for Keyboard input
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public class KeyboardManager : IUpdatable, IKeyboardPublisher, IService
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<string, IKeyboardListener>, name it '_kBListeners':
        private IDictionary<string, IKeyboardListener> _kBListeners;

        // DECLARE a KeyboardState, name it '_keyboardState':
        private KeyboardState _keyboardState;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of KeyboardManager
        /// </summary>
        public KeyboardManager() 
        {
            // INSTANTIATE _kBListeners as new Dictionary<string, IKeyboardListener>:
            _kBListeners = new Dictionary<string, IKeyboardListener>();
        }

        #endregion


        #region IMPLEMENTATION OF IKEYBOARDPUBLISHER

        /// <summary>
        /// Subscribes a Keyboard listening object to be stored in a list/dictionary
        /// </summary>
        /// <param name="pKeyboardListener">Reference to an object implementing IKeyboardListener</param>
        public void Subscribe(IKeyboardListener pKeyboardListener)
        {
            // ADD pKeyboardListener to Dictionary<string, IKeyboardListener>:
            _kBListeners.Add((pKeyboardListener as IEntity).UName, pKeyboardListener);
        }

        /// <summary>
        /// Unsubscribes a Keyboard listening object from list/dictionary using its unique name
        /// </summary>
        /// <param name="pUName">Used for passing unique name</param>
        public void Unsubscribe(string pUName)
        {
            // CALL Remove(), on Dictionary to remove 'value' of key 'pUName':
            _kBListeners.Remove(pUName);
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
            _keyboardState = Keyboard.GetState();

            // FOREACH IKeyboardListener object in _kBListeners:
            foreach (IKeyboardListener pKeyboardListener in _kBListeners.Values)
            {
                // CALL 'OnKBInput()' passing _keyboardState as a parameter, used to get Keyboard input:
                pKeyboardListener.OnKBInput(_keyboardState);
            }
        }

        #endregion
    }
}
