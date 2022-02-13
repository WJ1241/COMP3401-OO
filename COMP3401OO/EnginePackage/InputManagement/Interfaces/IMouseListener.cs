using Microsoft.Xna.Framework.Input;

namespace COMP3401OO.EnginePackage.InputManagement.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to listen for Mouse input
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IMouseListener
    {
        #region METHODS

        /// <summary>
        /// Called when Publisher has new mouse input information for listening objects
        /// </summary>
        /// <param name="mouseState"> MouseState object </param>
        void OnMouseInput(MouseState pMouseState);

        #endregion
    }
}
