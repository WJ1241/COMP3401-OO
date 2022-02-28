using Microsoft.Xna.Framework.Input;

namespace COMP3401OO.EnginePackage.InputManagement.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to listen for Keyboard input
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IKeyboardListener
    {
        #region METHODS

        /// <summary>
        /// Called when Publisher has new Keyboard input information for listening objects
        /// </summary>
        /// <param name="pKeyboardState">Holds reference to Keyboard State object</param>
        void OnKBInput(KeyboardState pKeyboardState);

        #endregion
    }
}
