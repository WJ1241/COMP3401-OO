using System.Collections.Generic;
using COMP3401OO_Engine.EntityManagement.Interfaces;

namespace COMP3401OO_Engine.CollisionManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to store objects which can collide with other objects
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface ICollisionManager
    {
        #region METHODS

        /// <summary>
        /// Initialises object with a IReadOnlyDictionary<string, IEntity>
        /// </summary>
        /// <param name="pEntityDictionary">holds reference to 'IReadOnlyDictionary<string, IEntity>'</param>
        void Initialise(IReadOnlyDictionary<string, IEntity> pEntityDictionary);

        #endregion
    }
}
