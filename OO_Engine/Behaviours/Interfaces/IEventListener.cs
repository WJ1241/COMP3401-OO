

namespace COMP3401OO_Engine.Behaviours.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to listen to events specified by the generic argument
    /// Authors: William Smith
    /// Date: 20/04/22
    /// </summary>
    /// <typeparam name="EA"> Generic Event Args </typeparam>
    public interface IEventListener<EA>
    {
        #region METHODS

        /// <summary>
        /// Event which gives a listener arguments related to the replacement of generic 'EA'
        /// </summary>
        /// <param name="pSource"> Object invoking event </param>
        /// <param name="pArgs"> Necessary arguments to complete behaviour </param>
        void OnEvent(object pSource, EA pArgs);

        #endregion
    }
}
