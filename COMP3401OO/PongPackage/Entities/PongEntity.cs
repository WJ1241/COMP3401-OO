using System;
using Microsoft.Xna.Framework;
using COMP3401OO_Engine.Behaviours.Interfaces;
using COMP3401OO_Engine.CoreInterfaces;
using COMP3401OO_Engine.CustomEventArgs;
using COMP3401OO_Engine.EntityManagement;
using COMP3401OO_Engine.Exceptions;

namespace COMP3401OO.PongPackage.Entities
{
    /// <summary>
    /// Abstract class for Pong Entities to inherit from
    /// Author: William Smith
    /// Date: 06/04/22
    /// </summary>
    public abstract class PongEntity : DrawableEntity, IInitialiseParam<EventArgs>, IInitialiseParam<IEventListener<UpdateEventArgs>>, IUpdatable, IVelocity
    {
        #region FIELD VARIABLES

        // DECLARE an EventHandler<UpdateEventArgs>, name it '_update':
        protected EventHandler<UpdateEventArgs> _update;

        // DECLARE an UpdateEventArgs, name it '_updateArgs':
        protected UpdateEventArgs _updateArgs;

        // DECLARE a Vector2, name it '_velocity':
        protected Vector2 _velocity;

        // DECLARE a float, name it 'speed':
        protected float _speed;

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<EVENTARGS>

        /// <summary>
        /// Initialises an object with an EventArgs object
        /// </summary>
        /// <param name="pArgs"> EventArgs object </param>
        public virtual void Initialise(EventArgs pArgs)
        {
            // IF pArgs DOES HAVE an active instance:
            if (pArgs != null)
            {
                // INITIALISE _updateArgs with reference to pArgs
                _updateArgs = pArgs as UpdateEventArgs;
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
        public virtual void Initialise(IEventListener<UpdateEventArgs> pUpdateEventListener)
        {
            // IF pUpdateEventListener DOES HAVE an active instance:
            if (pUpdateEventListener != null)
            {
                // SUBSCRIBE _update to pUpdateEventListener.OnEvent:
                _update += pUpdateEventListener.OnEvent;
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
            // SET RequiredArg Property value of _args to reference of pGameTime:
            _updateArgs.RequiredArg = pGameTime;

            // INVOKE _update(), passing this class, and _updateArgs as parameters:
            _update.Invoke(this, _updateArgs);
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
