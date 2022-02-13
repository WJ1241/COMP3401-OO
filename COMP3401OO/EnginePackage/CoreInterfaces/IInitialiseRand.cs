﻿using System;

namespace COMP3401OO.EnginePackage.CoreInterfaces
{
    /// <summary>
    /// Interface that allows implementations to store a Random object
    /// </summary>
    interface IInitialiseRand
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a Random object
        /// </summary>
        /// <param name="rand">holds reference to a Random object</param>
        void Initialise(Random rand);

        #endregion
    }
}