using COMP3401OO.EnginePackage.Behaviours.Interfaces;
using COMP3401OO.EnginePackage.CoreInterfaces;
using COMP3401OO.EnginePackage.CustomEventArgs;
using COMP3401OO.EnginePackage.EntityManagement.Interfaces;
using COMP3401OO.EnginePackage.Exceptions;

namespace COMP3401OO.EnginePackage.Behaviours
{
    /// <summary>
    /// Class which is used to separate logic from an entity
    /// Author: William Smith
    /// Date: 26/02/22
    /// </summary>
    public abstract class Behaviour : IInitialiseIEntity, IUpdateEventListener
    {
        #region FIELD VARIABLES

        // DECLARE an IEntity, name it '_entity':
        protected IEntity _entity;

        #endregion


        #region IMPLEMENTATION OF IINITIALISEIENTITY

        /// <summary>
        /// Initialises an object with an IEntity object
        /// </summary>
        /// <param name="pEntity"> IEntity object </param>
        public void Initialise(IEntity pEntity)
        {
            // IF pEntity DOES HAVE an active instance:
            if (pEntity != null)
            {
                // INITIALISE _entity with reference to pEntity:
                _entity = pEntity;
            }
            // IF pEntity DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pEntity does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IUPDATEEVENTLISTENER

        /// <summary>
        /// Event which performs any necessary update logic each time a game loop runs
        /// </summary>
        /// <param name="pSource"> Invoking object </param>
        /// <param name="pArgs"> Required arguments </param>
        public virtual void OnUpdate(object pSource, UpdateEventArgs pArgs)
        {
            // UPDATE _entity's position using it's current velocity:
            _entity.Position += (_entity as IVelocity).Velocity;
        }

        #endregion
    }
}
