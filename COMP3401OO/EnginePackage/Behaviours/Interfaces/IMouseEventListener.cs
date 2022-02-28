using COMP3401OO.EnginePackage.CustomEventArgs;

namespace COMP3401OO.EnginePackage.Behaviours.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to listen for objects invoking a mouse input event
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public interface IMouseEventListener
    {
        #region METHODS

        /// <summary>
        /// Event which performs any necessary input logic each time a user inputs from their mouse
        /// </summary>
        /// <param name="pSource"> Invoking object </param>
        /// <param name="pArgs"> Required arguments </param>
        void OnMouseInput(object pSource, MouseEventArgs pArgs);

        #endregion
    }
}
