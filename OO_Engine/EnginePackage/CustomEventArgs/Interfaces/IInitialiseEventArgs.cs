using System;

namespace COMP3401OO_Engine.Behaviours.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with an EventArgs object
    /// Author: William Smith
    /// Date: 06/04/22
    /// </summary>
    public interface IInitialiseEventArgs
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with an EventArgs object
        /// </summary>
        /// <param name="pArgs"> EventArgs object </param>
        void Initialise(EventArgs pArgs);

        #endregion
    }
}
