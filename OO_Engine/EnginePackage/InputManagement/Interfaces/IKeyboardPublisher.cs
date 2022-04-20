

namespace COMP3401OO_Engine.InputManagement.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to publish Keyboard input to listeners
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IKeyboardPublisher
    {
        #region METHODS

        /// <summary>
        /// Subscribes a Keyboard listening object to be stored in a list/dictionary
        /// </summary>
        /// <param name="pKeyboardListener">Reference to an object implementing IKeyboardListener</param>
        void Subscribe(IKeyboardListener pKeyboardListener);

        /// <summary>
        /// Unsubscribes a Keyboard listening object from list/dictionary using its unique name
        /// </summary>
        /// <param name="pUName">Used for passing unique name</param>
        void Unsubscribe(string pUName);

        #endregion
    }
}
