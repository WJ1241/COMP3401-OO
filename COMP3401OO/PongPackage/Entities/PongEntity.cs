using System;
using Microsoft.Xna.Framework;
using COMP3401OO.EnginePackage.Behaviours.Interfaces;
using COMP3401OO.EnginePackage.CoreInterfaces;
using COMP3401OO.EnginePackage.CustomEventArgs;
using COMP3401OO.EnginePackage.EntityManagement;
using COMP3401OO.EnginePackage.Exceptions;

namespace COMP3401OO.PongPackage.Entities
{
    /// <summary>
    /// Abstract class for Pong Entities to inherit from
    /// Author: William Smith
    /// Date: 25/02/22
    /// </summary>
    public abstract class PongEntity : DrawableEntity, IInitialiseIUpdateEventListener, IUpdatable, IVelocity
    {
        #region FIELD VARIABLES

        // DECLARE an EventHandler<UpdateEventArgs>, name it '_update':
        protected EventHandler<UpdateEventArgs> _update;

        // DECLARE a Vector2, name it '_velocity':
        protected Vector2 _velocity;

        // DECLARE a float, name it 'speed':
        protected float _speed;

        #endregion


        #region IMPLEMENTATION OF IINITIALISEIUPDATEVENTLISTENER

        /// <summary>
        /// Initialises an object with an IUpdateEventListener object
        /// </summary>
        /// <param name="pUpdateEventListener"> IUpdateEventListener object </param>
        public virtual void Initialise(IUpdateEventListener pUpdateEventListener)
        {
            // IF pUpdateEventListener DOES HAVE an active instance:
            if (pUpdateEventListener != null)
            {
                // SUBSCRIBE _update to pUpdateEventListener.OnUpdate:
                _update += pUpdateEventListener.OnUpdate;
            }
            // IF pUpdateEventListener DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corrsponding message:
                throw new NullInstanceException("ERROR: pUpdateEventListener does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IUPDATABLE

        /// <summary>
        /// Updates object when a frame has been rendered on screen
        /// </summary>
        /// <param name="pGameTime">holds reference to GameTime object</param>
        public virtual void Update(GameTime pGameTime)
        {
            // DECLARE & INSTANTIATE an UpdateEventArgs(), name it '_args':
            UpdateEventArgs _args = new UpdateEventArgs();

            // SET RequiredArg Property value of _args to reference of pGameTime:
            _args.RequiredArg = pGameTime;

            // INVOKE _update(), passing this class, and _args as parameters:
            _update.Invoke(this, _args);
        }

        #endregion


        #region IMPLEMENTATION OF IVELOCITY

        /// <summary>
        /// Property which allows read and write access to a Vector2 velocity
        /// </summary>
        public Vector2 Velocity
        {
            get
            {
                // RETURN value of _velocity:
                return _velocity;
            }
            set 
            {
                // SET value of _velocity to incoming value:
                _velocity = value;
            }
        }

        #endregion
    }
}
