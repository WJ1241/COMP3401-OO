﻿

namespace COMP3401OO.EnginePackage.InputManagement.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to publish Mouse input to listeners
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IMousePublisher
    {
        #region METHODS

        /// <summary>
        /// Subscribes a Mouse listening object to be stored in a list/dictionary
        /// </summary>
        /// <param name="mouseListener">Reference to an object implementing IMouseListener</param>
        void Subscribe(IMouseListener mouseListener);

        /// <summary>
        /// Unsubscribes a Mouse listening object from list/dictionary using its unique name
        /// </summary>
        /// <param name="uName">Used for passing unique name</param>
        void Unsubscribe(string uName);

        #endregion
    }
}