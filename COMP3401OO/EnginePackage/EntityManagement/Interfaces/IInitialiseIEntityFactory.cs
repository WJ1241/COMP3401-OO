using COMP3401OO.EnginePackage.Factories.Interfaces;

namespace COMP3401OO.EnginePackage.EntityManagement.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with an IFactory<IEntity> object
    /// Author: William Smith
    /// Date: 23/02/22
    /// </summary>
    public interface IInitialiseIEntityFactory
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with an IFactory<IEntity> object
        /// </summary>
        /// <param name="pFactory"> IFactory<IEntity> object </param>
        void Initialise(IFactory<IEntity> pFactory);

        #endregion
    }
}
