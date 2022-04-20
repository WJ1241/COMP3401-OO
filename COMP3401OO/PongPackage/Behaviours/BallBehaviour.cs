using System;
using Microsoft.Xna.Framework;
using COMP3401OO_Engine.Behaviours.Interfaces;
using COMP3401OO_Engine.CoreInterfaces;
using COMP3401OO_Engine.CustomEventArgs;
using COMP3401OO_Engine.EntityManagement.Interfaces;
using COMP3401OO.PongPackage.Delegates;

namespace COMP3401OO.PongPackage.Behaviours
{
    /// <summary>
    /// Class which is used to contain behaviour code related to a Ball object in Pong
    /// Author: William Smith
    /// Date: 25/02/22
    /// </summary>
    public class BallBehaviour : PongBehaviour, ICollisionEventListener, IInitialiseParam<CheckPositionDelegate>
    {
        #region FIELD VARIABLES

        // DECLARE a CheckPosDelegate, name it '_checkPos':
        private CheckPositionDelegate _checkPos;

        // DECLARE a Vector2, name it '_velocity':
        private Vector2 _velocity;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of BallBehaviour
        /// </summary>
        public BallBehaviour()
        {
            // EMPTY CONSTRUCTOR
        }

        #endregion


        #region IMPLEMENTATION OF ICOLLISIONEVENTLISTENER
        
        /// <summary>
        /// Event which performs any necessary update logic each time a collision occurs
        /// </summary>
        /// <param name="pSource"> Invoking object </param>
        /// <param name="pArgs"> Required arguments </param>
        public void OnCollision(object pSource, CollisionEventArgs pArgs)
        {
            // SET value of _velocity to value of _entity.Velocity:
            _velocity = (_entity as IVelocity).Velocity;

            // IF moving left:
            if ((_entity as IVelocity).Velocity.X < 0)
            {
                // MINUS & ASSIGN 0.2 multiplied by pArgs.RequiredArg's Velocity, to _velocity:
                _velocity.X -= 0.2f * (pArgs.RequiredArg as IVelocity).Velocity.Length();
            }
            // IF moving right:
            else if ((_entity as IVelocity).Velocity.X > 0)
            {
                // ADD & ASSIGN 0.2 multiplied by pArgs.RequiredArg's Velocity, to _velocity:
                _velocity.X += 0.2f * (pArgs.RequiredArg as IVelocity).Velocity.Length();
            }

            // REVERSE _velocity.X:
            _velocity.X *= -1;

            // SET Velocity Property value of _entity to value of _velocity:
            (_entity as IVelocity).Velocity = _velocity;
        }


        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<CHECKPOSITIONDELEGATE>

        /// <summary>
        /// Initialises an object with a CheckPositionDelegate
        /// </summary>
        /// <param name="pCheckPosDel"> Method which meets the signature of CheckPositionDelegate </param>
        public void Initialise(CheckPositionDelegate pCheckPosDel)
        {
            // IF pCheckPosDel DOES contain a valid method reference:
            if (pCheckPosDel != null)
            {
                // INITTIALISE _checkPos with reference to pCheckPosDel
                _checkPos = pCheckPosDel;
            }
            // IF pCheckPosDel DOES NOT contain a valid method reference:
            else
            {
                // THROW a new NullReferenceException(), with corresponding message:
                throw new NullReferenceException("ERROR: pCheckPosDel does not contain a valid method reference!");
            }
        }

        #endregion


        #region PROTECTED METHODS

        /// <summary>
        /// Used when an object hits a boundary, possibly to change direction or stop
        /// </summary>
        protected override void Boundary()
        {
            // DECLARE & INITIALISE a Vector2, name it 'tempVel', give value of _entity's Velocity Property:
            Vector2 tempVel = (_entity as IVelocity).Velocity;

            // IF at top screen edge or bottom screen edge:
            if (_entity.Position.Y <= 0 || _entity.Position.Y >= (_entity as IContainBoundary).WindowBorder.Y - (_entity as ITexture).TexSize.Y)
            {
                // REVERSE tempVel.Y:
                tempVel.Y *= -1;

                // SET value of _entity's Velocity property to newly adjusted value of tempVel:
                (_entity as IVelocity).Velocity = tempVel;
            }
            // IF at left screen edge or right screen edge:
            else if (_entity.Position.X <= 0 || _entity.Position.X >= ((_entity as IContainBoundary).WindowBorder.X - (_entity as ITexture).TexSize.X))
            {
                // REVERSE _tempVel.X:
                tempVel.X *= -1;

                // SET value of _entity's Velocity property to newly adjusted value of tempVel:
                (_entity as IVelocity).Velocity = tempVel;

                // IF entity exceeds the left screen bounds:
                if (_entity.Position.X <= 0)
                {
                    // SET Position property value of _entity to the left edge of the screen so that it cannot leave screen if travelling too quick:
                    _entity.Position = new Vector2(0, _entity.Position.Y);
                }
                // IF entity exceeds the right screen bounds:
                if (_entity.Position.X >= ((_entity as IContainBoundary).WindowBorder.X - (_entity as ITexture).TexSize.X))
                {
                    // SET Position property value of tempTFComp to the right edge of the screen so that it cannot leave screen if travelling too quick:
                    _entity.Position = new Vector2((_entity as IContainBoundary).WindowBorder.X - (_entity as ITexture).TexSize.X, _entity.Position.Y);
                }

                /*

                // IF at left screen edge:
                if (_entity.Position.X <= 0)
                {
                    // CALL _checkPos, passing _entity.Position as a parameter:
                     _checkPos(_entity.Position);
                }
                // IF at right screen edge:
                else if (_entity.Position.X >= (_entity as IContainBoundary).WindowBorder.X - (_entity as ITexture).TexSize.X)
                {
                    // CALL _checkPos, passing a new Vector2 with a modified _entity.Position.X as a parameter:
                     _checkPos(new Vector2(_entity.Position.X + (_entity as ITexture).TexSize.X, _entity.Position.Y));
                }

                // CALL Terminate on _entity, passing _uName as a parameter:
                (_entity as ITerminate).Terminate(_entity.UName);

                */
            }
        }

        #endregion
    }
}
