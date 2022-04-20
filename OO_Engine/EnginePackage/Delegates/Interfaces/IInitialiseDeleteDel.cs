

namespace COMP3401OO_Engine.Delegates.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with a DeleteDelegate
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IInitialiseDeleteDel
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a DeleteDelegate
        /// </summary>
        /// <param name="pDeleteDelegate"> Method which meets the signature of DeleteDelegate </param>
        void Initialise(DeleteDelegate pDeleteDelegate);

        #endregion
    }
}
