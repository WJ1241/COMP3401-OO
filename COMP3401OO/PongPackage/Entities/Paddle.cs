using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using COMP3401OO_Engine.Behaviours.Interfaces;
using COMP3401OO_Engine.CollisionManagement.Interfaces;
using COMP3401OO_Engine.CoreInterfaces;
using COMP3401OO_Engine.CustomEventArgs;
using COMP3401OO_Engine.Exceptions;
using COMP3401OO_Engine.InputManagement.Interfaces;

namespace COMP3401OO.PongPackage.Entities
{
    /// <summary>
    /// Class which adds a Paddle entity on screen
    /// Author: William Smith
    /// Date: 06/04/22
    /// </summary>
    public class Paddle : PongEntity, ICollidable, IGetSpeed, IKeyboardListener, IPlayer, IRtnTextureDict
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<string, Texture2D>, name it '_textureDict':
        private IDictionary<string, Texture2D> _textureDict;

        // DECLARE an EventHandler<KBEventArgs>, name it '_kBInput':
        private EventHandler<KBEventArgs> _kBInput;

        // DECLARE a KBEventArgs, name it '_kbArgs':
        private KBEventArgs _kbArgs;

        // DECLARE a PlayerIndex and name it '_playerNum':
        private PlayerIndex _playerNum;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of Paddle
        /// </summary>
        public Paddle()
        {
            // INSTANTIATE _textureDict as a new Dictionary<string, Texture2D>():
            _textureDict = new Dictionary<string, Texture2D>();

            // ASSIGNMENT, set _speed to 10:
            _speed = 10;
        }

        #endregion


        #region IMPLEMENTATION OF ICOLLIDABLE

        /// <summary>
        /// Used to Return a Rectangle object to caller of property
        /// </summary>
        public Rectangle HitBox
        {
            get
            {
                // RETURN a rectangle, object current X axis location - X axis origin, object current Y axis location - Y axis origin, texture width size, texture height size:
                return new Rectangle((int)(_position.X - _origin.X), (int)(_position.Y - _origin.Y), _texSize.X, _texSize.Y);
            }
        }

        #endregion


        #region IMPLEMENTATION OF IGETSPEED

        /// <summary>
        /// Property which allows only read access to a speed integer
        /// </summary>
        public float Speed
        {
            get
            {
                // RETURN value of _speed:
                return _speed;
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEEVENTARGS

        /// <summary>
        /// Initialises an object with an EventArgs object
        /// </summary>
        /// <param name="pArgs"> EventArgs object </param>
        public override void Initialise(EventArgs pArgs)
        {
            // IF pArgs DOES HAVE an active instance:
            if (pArgs != null)
            {
                // IF pArgs is related to CollisionEventArgs:
                if (pArgs is UpdateEventArgs)
                {
                    // INITIALISE _updateArgs with reference to pArgs:
                    _updateArgs = pArgs as UpdateEventArgs;
                }
                // IF pArgs is related to KBEventArgs:
                else if (pArgs is KBEventArgs)
                {
                    // INITIALISE _kbArgs with reference to pArgs:
                    _kbArgs = pArgs as KBEventArgs;
                }
            }
            // IF pArgs DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corrsponding message:
                throw new NullInstanceException("ERROR: pArgs does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IEVENTLISTENER<UPDATEEVENTARGS>>

        /// <summary>
        /// Initialises an object with an IUpdateEventListener object
        /// </summary>
        /// <param name="pUpdateEventListener"> IUpdateEventListener object </param>
        public override void Initialise(IEventListener<UpdateEventArgs> pUpdateEventListener)
        {
            // IF pUpdateEventListener DOES HAVE an active instance:
            if (pUpdateEventListener != null)
            {
                // SUBSCRIBE _update to pUpdateEventListener.OnEvent:
                _update += pUpdateEventListener.OnEvent;

                // SUBSCRIBE _kbInput to pUpdateEventListener.OnEvent:
                _kBInput += (pUpdateEventListener as IEventListener<KBEventArgs>).OnEvent;
            }
            // IF pUpdateEventListener DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corrsponding message:
                throw new NullInstanceException("ERROR: pUpdateEventListener does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IKEYBOARDLISTENER

        /// <summary>
        /// Called when Publisher has new Keyboard input information for listening objects
        /// </summary>
        /// <param name="pKeyboardState">Holds reference to Keyboard State object</param>
        public void OnKBInput(KeyboardState pKeyboardState)
        {
            // SET RequiredArg Property value of _args to reference of pKeyboardState:
            _kbArgs.RequiredArg = pKeyboardState;

            // INVOKE _kbInput(), passing this class, and _kbArgs as parameters:
            _kBInput.Invoke(this, _kbArgs);
        }

        #endregion


        #region IMPLEMENTATION OF IPLAYER

        /// <summary>
        /// Property which can set value of a PlayerIndex
        /// </summary>
        public PlayerIndex PlayerNum 
        {
            get
            {
                // RETURN value of _playerNum:
                return _playerNum;
            }
            set 
            {
                // ASSIGNMENT give _playerNum value of whichever class is modifying value
                _playerNum = value;
            }
        }

        #endregion


        #region IMPLEMENTATION OF IRTNTEXTUREDICT

        /// <summary>
        /// Returns a reference to a string, Texture Dictionary
        /// </summary>
        /// <returns> IDictionary<string, Texture2D> object </returns>
        public IDictionary<string, Texture2D> ReturnTextureDict()
        {
            // RETURN instance of _textureDict:
            return _textureDict;
        }

        #endregion
    }
}
