

namespace COMP3401OO_Engine.Delegates.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with a DeleteDelegate
    /// Author: William Smith
    /// Date: 06/04/22
    /// </summary>
    public interface IInitialiseDeleteMultiDel
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a 'DeleteMultipleDelegate' method
        /// </summary>
        /// <param name="pDeleteDel"> Delete Multiple Method </param>
        void Initialise(DeleteMultipleDelegate pDeleteDel);

        #endregion
    }
}
