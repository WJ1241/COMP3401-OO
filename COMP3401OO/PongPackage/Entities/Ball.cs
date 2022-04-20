using System;
using Microsoft.Xna.Framework;
using COMP3401OO_Engine.Behaviours.Interfaces;
using COMP3401OO_Engine.CollisionManagement.Interfaces;
using COMP3401OO_Engine.CoreInterfaces;
using COMP3401OO_Engine.CustomEventArgs;
using COMP3401OO_Engine.Exceptions;

namespace COMP3401OO.PongPackage.Entities
{
    /// <summary>
    /// Class which adds a Ball entity on screen
    /// Author: William Smith
    /// Date: 06/04/22
    /// </summary>
    public class Ball : PongEntity, IInitialiseParam<Random>, IReset, ICollidable, ICollisionListener
    {
        #region FIELD VARIABLES

        // DECLARE an EventHandler<CollisionEventArgs>, name it '_collision':
        private EventHandler<CollisionEventArgs> _collision;

        // DECLARE a CollisionEventArgs, name it '_collisionArgs':
        private CollisionEventArgs _collisionArgs;

        // DECLARE a Random, name it '_rand':
        private Random _rand;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of Ball
        /// </summary>
        public Ball()
        {
            // ASSIGNMENT, set _speed to 5:
            _speed = 5;
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
                // IF pArgs is related to CollisionEventArgs:
                else if (pArgs is CollisionEventArgs)
                {
                    // INITIALISE _collisionArgs with reference to pArgs:
                    _collisionArgs = pArgs as CollisionEventArgs;
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


        #region IMPLEMENTATION OF IINITIALISEPARAM<IUPDATEVENTLISTENER>

        /// <summary>
        /// Initialises an object with an IUpdateEventListener object
        /// </summary>
        /// <param name="pUpdateEventListener"> IUpdateEventListener object </param>
        public override void Initialise(IUpdateEventListener pUpdateEventListener)
        {
            // IF pUpdateEventListener DOES HAVE an active instance:
            if (pUpdateEventListener != null)
            {
                // SUBSCRIBE _update to pUpdateEventListener.OnUpdate:
                _update += pUpdateEventListener.OnUpdate;

                // SUBSCRIBE _collision to pUpdateEventListener.OnCollision:
                _collision += (pUpdateEventListener as ICollisionEventListener).OnCollision;
            }
            // IF pUpdateEventListener DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corrsponding message:
                throw new NullInstanceException("ERROR: pUpdateEventListener does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISERAND

        /// <summary>
        /// Initialises an object with a Random object
        /// </summary>
        /// <param name="pRand">holds reference to a Random object</param>
        public void Initialise(Random pRand)
        {
            // IF pRand DOES HAVE an active instance:
            if (pRand != null)
            {
                // INITIALISE _rand with reference to pRand:
                _rand = pRand;
            }
            // IF pRand DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pRand does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF ICOLLIDABLE

        /// <summary>
        /// Used to Return a rectangle object to caller of property
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


        #region IMPLEMENTATION OF ICOLLISIONLISTENER

        /// <summary>
        /// Called by Collision Manager when two entities collide
        /// </summary>
        /// <param name="pScndCollidable">Other entity implementing ICollidable</param>
        public void OnCollision(ICollidable pScndCollidable)
        {
            // SET RequiredArg Property value to reference of pScndCollidable:
            _collisionArgs.RequiredArg = pScndCollidable;

            // INVOKE _collision(), passing this class and _collisionArgs as parameters:
            _collision.Invoke(this, _collisionArgs);
        }

        #endregion


        #region IMPLEMENTATION OF IRESET

        /// <summary>
        /// Resets an object's positional values
        /// </summary>
        public void Reset()
        {
            // INITIALISE _velocity with a value of '1' for both axes:
            _velocity = new Vector2(1);

            // IF _rand.Next() lands on '2'
            if (_rand.Next(1, 3) == 2)
            {
                // MULTIPLY _velocity.X by '-1':
                _velocity.X *= -1;
            }

            // IF _rand.Next() lands on '2'
            if (_rand.Next(1, 3) == 2)
            {
                // MULTIPLY _velocity.Y by '-1':
                _velocity.Y *= -1;
            }

            // SET value of _velocity to be itself multiplied by _speed:
            _velocity *= _speed;


            //// ASSIGN random rotation:
            //float _aimRot = (float)(Math.PI / 2 + (_rand.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));

            //// ASSIGN velocity.X using Sine and _rotation:
            //_velocity.X = (float)Math.Sin(_aimRot);

            //// ASSIGN velocity.Y using Cosine and _rotation:
            //_velocity.Y = (float)Math.Cos(_aimRot);

            //// ASSIGN Random number between 1 and 2, 3 is exclusive:
            //int _randNum = _rand.Next(1, 3);

            //// IF Random number is 2:
            //if (_randNum == 2)
            //{
            //    // REVERSE velocity.X:
            //    _velocity.X *= -1;
            //}

            //// MULTIPLY & ASSIGN _velocity by _speed:
            //_velocity *= _speed;
        }

        #endregion
    }
}
