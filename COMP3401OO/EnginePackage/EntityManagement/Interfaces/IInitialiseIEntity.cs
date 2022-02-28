

namespace COMP3401OO.EnginePackage.EntityManagement.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with an IEntity object
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public interface IInitialiseIEntity
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with an IEntity object
        /// </summary>
        /// <param name="pEntity"> IEntity object </param>
        void Initialise(IEntity pEntity);

        #endregion
    }
}
