using COMP3401OO.EnginePackage.Delegates;

namespace COMP3401OO.EnginePackage.EntityManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to be terminated
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface ITerminate
    {
        #region METHODS

        /// <summary>
        /// Disposes resources to the garbage collector
        /// </summary>
        void Termination();

        #endregion


        #region PROPERTIES

        /// <summary>
        /// Property which allows only read access to a DeleteDelegate
        /// </summary>
        DeleteDelegate Terminate { get; } 

        #endregion
    }
}
