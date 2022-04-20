using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using COMP3401OO_Engine.Behaviours.Interfaces;
using COMP3401OO_Engine.CoreInterfaces;
using COMP3401OO_Engine.CustomEventArgs;
using COMP3401OO_Engine.EntityManagement.Interfaces;
using COMP3401OO.PongPackage.Behaviours.Interfaces;

namespace COMP3401OO.PongPackage.Behaviours
{
    /// <summary>
    /// Class which is used to contain behaviour code related to a Ball object in Pong
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public class PaddleBehaviour : PongBehaviour, IKBEventListener, ITestKBInput
    {
        #region FIELD VARIABLES

        // DECLARE a Vector2, name it '_direction':
        private Vector2 _direction;

        // DECLARE a string, name it '_currentInput':
        private string _currentInput;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of PaddleBehaviour
        /// </summary>
        public PaddleBehaviour()
        {
            // EMPTY CONSTRUCTOR
        }

        #endregion


        #region IMPLEMENTATION OF IKBEVENTLISTENER

        /// <summary>
        /// Event which performs any necessary input logic each time a user inputs from their keyboard
        /// </summary>
        /// <param name="pSource"> Invoking object </param>
        /// <param name="pArgs"> Required arguments </param>
        public void OnKBInput(object pSource, KBEventArgs pArgs)
        {
            // INSTANTIATE new Vector2, set as 0 to stop movement:
            _direction = new Vector2(0);

            // IF Player 1:
            if ((_entity as IPlayer).PlayerNum == PlayerIndex.One)
            {
                // IF Player 1 HAS been assigned a texture named "Paddle1_DFLT":
                if ((_entity as IRtnTextureDict).ReturnTextureDict().ContainsKey("Paddle1_DFLT"))
                {
                    // SET Texture Property of _entity to "Paddle1_DFLT":
                    (_entity as ITexture).Texture = (_entity as IRtnTextureDict).ReturnTextureDict()["Paddle1_DFLT"];
                }

                // IF W or S Key pressed
                if (pArgs.RequiredArg.IsKeyDown(Keys.W) || pArgs.RequiredArg.IsKeyDown(Keys.S))
                {
                    // IF Player 1 HAS been assigned a texture named "Paddle1_INPT":
                    if ((_entity as IRtnTextureDict).ReturnTextureDict().ContainsKey("Paddle1_INPT"))
                    {
                        // SET Texture Property of _entity to "Paddle1_INPT":
                        (_entity as ITexture).Texture = (_entity as IRtnTextureDict).ReturnTextureDict()["Paddle1_INPT"];
                    }

                    // IF W Key pressed:
                    if (pArgs.RequiredArg.IsKeyDown(Keys.W))
                    {
                        // SET value of _currentInput to "W":
                        _currentInput = "W";
                    }
                    // IF S Key pressed:
                    else if (pArgs.RequiredArg.IsKeyDown(Keys.S))
                    {
                        // SET value of _currentInput to "S":
                        _currentInput = "S";
                    }
                }

                // IF _currentInput is "W" Key:
                if (_currentInput == "W")
                {
                    // ASSIGN direction.Y, give value of -1:
                    _direction.Y = -1;

                    // SET RotationAngle Property value of _entity to 0 (Normal Orientation):
                    (_entity as IRotation).RotationAngle = 0;
                }
                // IF _currentInput is "S" Key
                if (_currentInput == "S")
                {
                    // ASSIGN direction.Y, give value of 1:
                    _direction.Y = 1;

                    // SET RotationAngle Property value of _entity to PI (Flip 180 deg):
                    (_entity as IRotation).RotationAngle = (float)Math.PI;
                }
            }
            // IF Player 2:
            else if ((_entity as IPlayer).PlayerNum == PlayerIndex.Two)
            {
                // IF Player 2 HAS been assigned a texture named "Paddle2_DFLT":
                if ((_entity as IRtnTextureDict).ReturnTextureDict().ContainsKey("Paddle2_DFLT"))
                {
                    // SET Texture Property of _entity to "Paddle2_DFLT":
                    (_entity as ITexture).Texture = (_entity as IRtnTextureDict).ReturnTextureDict()["Paddle2_DFLT"];
                }

                // IF Up OR Down Arrow Key pressed:
                if (pArgs.RequiredArg.IsKeyDown(Keys.Up) || pArgs.RequiredArg.IsKeyDown(Keys.Down))
                {
                    // IF Player 2 HAS been assigned a texture named "Paddle2_INPT":
                    if ((_entity as IRtnTextureDict).ReturnTextureDict().ContainsKey("Paddle2_INPT"))
                    {
                        // SET Texture Property of _entity to "Paddle2_INPT":
                        (_entity as ITexture).Texture = (_entity as IRtnTextureDict).ReturnTextureDict()["Paddle2_INPT"];
                    }

                    // IF Up Arrow Key pressed:
                    if (pArgs.RequiredArg.IsKeyDown(Keys.Up))
                    {
                        // SET value of _currentInput to "Up":
                        _currentInput = "Up";
                    }
                    // IF Down Arrow Key pressed:
                    else if (pArgs.RequiredArg.IsKeyDown(Keys.Down))
                    {
                        // SET value of _currentInput to "Down":
                        _currentInput = "Down";
                    }
                }

                // IF _currentInput is "Up" Key:
                if (_currentInput == "Up")
                {
                    // ASSIGN direction.Y, give value of -1:
                    _direction.Y = -1;

                    // SET RotationAngle Property value of _entity to 0 (Normal Orientation):
                    (_entity as IRotation).RotationAngle = 0;
                }
                // IF _currentInput is "Down" Key
                if (_currentInput == "Down")
                {
                    // ASSIGN direction.Y, give value of 1:
                    _direction.Y = 1;

                    // SET RotationAngle Property value of _entity to PI (Flip 180 deg):
                    (_entity as IRotation).RotationAngle = (float)Math.PI;
                }
            }

            // INITIALISE _currentInput with a blank string to reset input:
            _currentInput = "";
        }

        #endregion


        #region IMPLEMENTATION OF ITESTKBINPUT

        /// <summary>
        /// Property which gives caller write access to what key is pressed
        /// </summary>
        public string SetKeyPressed
        {
            set
            {
                // SET value of _currentInput to incoming value:
                _currentInput = value;
            }
        }

        #endregion


        #region IMPLEMENTATION OF IUPDATEEVENTLISTENER

        /// <summary>
        /// Event which performs any necessary update logic each time a game loop runs
        /// </summary>
        /// <param name="pSource"> Invoking object </param>
        /// <param name="pArgs"> Required arguments </param>
        public override void OnUpdate(object pSource, UpdateEventArgs pArgs)
        {
            // ASSIGNMENT, set value of _velocity to _speed mutlipled by _direction:
            (_entity as IVelocity).Velocity = (_entity as IGetSpeed).Speed * _direction;

            // UPDATE _entity's position using it's current velocity:
            _entity.Position += (_entity as IVelocity).Velocity;

            // CALL Boundary():
            Boundary();
        }

        #endregion


        #region PROTECTED METHODS

        /// <summary>
        /// Used when an object hits a boundary, possibly to change direction or stop
        /// </summary>
        protected override void Boundary()
        {
            // IF paddle at top of screen:
            if (_entity.Position.Y <= (_entity as IRotation).Origin.Y)
            {
                // SET value of _entity.Position to '0':
                _entity.Position = new Vector2(_entity.Position.X, (_entity as IRotation).Origin.Y);
            }
            // IF paddle at bottom of screen:
            else if (_entity.Position.Y >= (_entity as IContainBoundary).WindowBorder.Y - (_entity as IRotation).Origin.Y)
            {
                // SET value of _entity.Position to a new Vector2, using WindowBorder and TexSize to prevent it from going off screen:
                _entity.Position = new Vector2(_entity.Position.X, (_entity as IContainBoundary).WindowBorder.Y - (_entity as IRotation).Origin.Y);
            }
        }

        #endregion
    }
}
