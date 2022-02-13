using System;
using Microsoft.Xna.Framework;
using COMP3401OO.EnginePackage.CollisionManagement.Interfaces;
using COMP3401OO.EnginePackage.CoreInterfaces;
using COMP3401OO.EnginePackage.Delegates;
using COMP3401OO.PongPackage.Delegates;
using COMP3401OO.PongPackage.Delegates.Interfaces;

namespace COMP3401OO.PongPackage
{
    /// <summary>
    /// Class which adds a Ball entity on screen
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public class Ball : PongEntity, IInitialiseCheckPosDel, IInitialiseRand, IReset, ICollidable, ICollisionListener
    {
        #region FIELD VARIABLES

        // DECLARE a CheckPositionDelegate, name it '_checkPos':
        private CheckPositionDelegate _checkPos;

        // DECLARE a Random, name it '_rand':
        private Random _rand;

        // DECLARE a Vector2 and name it 'direction':
        private Vector2 _direction;

        // DECLARE an int, name it '_randNum':
        private int _randNum;

        // DECLARE an float, name it '_rotation':
        private float _rotation;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of Ball
        /// </summary>
        public Ball()
        {
        }

        #endregion


        #region IMPLEMENTATION OF IENTITY

        /// <summary>
        /// Initialises entity variable values
        /// </summary>
        public override void Initialise()
        {
            // INSTANTIATE new Vector, value of 1 for both X and Y:
            _direction = new Vector2(1);
            
            // ASSIGNMENT, set _speed to 8:
            _speed = 8;
            
            // ASSIGNMENT, set value of _velocity to _speed mutlipled by _direction:
            _velocity = _speed * _direction;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISECHECKPOSDEL

        /// <summary>
        /// Initialises an object with a CheckPositionDelegate
        /// </summary>
        /// <param name="pCheckPosDel"> Method which meets the signature of CheckPositionDelegate </param>
        public void Initialise(CheckPositionDelegate pCheckPosDel)
        {
            // INITIALISE _checkPos with reference to pCheckPosDel:
            _checkPos = pCheckPosDel;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISERAND

        /// <summary>
        /// Initialises an object with a Random object
        /// </summary>
        /// <param name="rand">holds reference to a Random object</param>
        public void Initialise(Random rand)
        {
            // ASSIGNMENT, set instance of _rand the same as rand:
            _rand = rand;
        }

        #endregion


        #region IMPLEMENTATION OF IUPDATE

        /// <summary>
        /// Updates object when a frame has been rendered on screen
        /// </summary>
        /// <param name="gameTime">holds reference to GameTime object</param>
        public override void Update(GameTime gameTime)
        {
            // ADD & ASSIGN _velocity to _position:
            _position += _velocity;

            // CALL Boundary() method:
            Boundary();
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
                // RETURN a rectangle, object current X axis location, object current Y axis location, texture width size, texture height size:
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height); 
            }
        }

        #endregion


        #region IMPLEMENTATION OF ICOLLISIONLISTENER

        /// <summary>
        /// Called by Collision Manager when two entities collide
        /// </summary>
        /// <param name="scndCollidable">Other entity implementing ICollidable</param>
        public void OnCollision(ICollidable scndCollidable)
        {
            if (_velocity.X < 0) // IF moving left
            {
                // MINUS & ASSIGN 0.2 multiplied by _scndCollidable's Velocity, to _velocity:
                _velocity.X -= 0.2f * (scndCollidable as IVelocity).Velocity.Length();
            }
            else if (_velocity.X > 0)  // IF moving right
            {
                // ADD & ASSIGN 0.2 multiplied by _scndCollidable's Velocity, to _velocity:
                _velocity.X += 0.2f * (scndCollidable as IVelocity).Velocity.Length();
            }

            // REVERSE _velocity.X:
            _velocity.X *= -1;
        }

        #endregion


        #region IMPLEMENTATION OF ITERMINATE

        /// <summary>
        /// Disposes resources to the garbage collector
        /// </summary>
        public override void Terminate()
        {
            // No functionality, MonoGame deals with object and texture in garbage collector already
        }

        #endregion


        #region IMPLEMENTATION OF IRESET

        /// <summary>
        /// Resets an object's positional values
        /// </summary>
        public void Reset()
        {
            // ASSIGN random rotation:
            _rotation = (float)(Math.PI / 2 + (_rand.NextDouble() * (Math.PI / 1.5f) - Math.PI / 3));

            // ASSIGN velocity.X using Sine and _rotation:
            _velocity.X = (float)Math.Sin(_rotation);

            // ASSIGN velocity.Y using Cosine and _rotation:
            _velocity.Y = (float)Math.Cos(_rotation);

            // ASSIGN Random number between 1 and 2, 3 is exclusive:
            _randNum = _rand.Next(1, 3);

            if (_randNum == 2) // IF Random number is 2
            {
                // REVERSE velocity.X:
                _velocity.X *= -1;
            }

            // MULTIPLY & ASSIGN _velocity by _speed:
            _velocity *= _speed;
        }

        #endregion


        #region PROTECTED METHODS

        /// <summary>
        /// Used when an object hits a boundary, possibly to change direction or stop
        /// </summary>
        protected override void Boundary()
        {
            // IF at top screen edge or bottom screen edge:
            if (_position.Y <= 0 || _position.Y >= (_windowBorder.Y - _texture.Height))
            {
                // REVERSE _velocity.Y:
                _velocity.Y *= -1;
            }
            // IF at left screen edge or right screen edge:
            else if (_position.X <= 0 || _position.X >= (_windowBorder.X - _texture.Width))
            {
                // IF at left screen edge:
                if (_position.X <= 0)
                {
                    // CALL _checkPos, passing _position as a parameter:
                    _checkPos(_position);
                }
                // IF at right screen edge:
                else if (_position.X >= (_windowBorder.X - _texture.Width))
                {
                    // CALL _checkPos, passing a new Vector2 with a modified _position.X as a parameter:
                    _checkPos(new Vector2(_position.X + _texture.Width, _position.Y));
                }
                    

                // CALL _terminate, passing _uName as a parameter:
                _terminate(_uName);
            }
        }

        #endregion
    }
}
