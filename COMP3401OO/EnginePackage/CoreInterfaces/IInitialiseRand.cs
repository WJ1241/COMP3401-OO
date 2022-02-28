using System;

namespace COMP3401OO.EnginePackage.CoreInterfaces
{
    /// <summary>
    /// Interface that allows implementations to store a Random object
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IInitialiseRand
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a Random object
        /// </summary>
        /// <param name="pRand">holds reference to a Random object</param>
        void Initialise(Random pRand);

        #endregion
    }
}
