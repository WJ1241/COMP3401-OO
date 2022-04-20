

namespace COMP3401OO_Engine.Behaviours.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with an IUpdateEventListener object
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public interface IInitialiseIUpdateEventListener
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with an IUpdateEventListener object
        /// </summary>
        /// <param name="pUpdateEventListener"> IUpdateEventListener object </param>
        void Initialise(IUpdateEventListener pUpdateEventListener);

        #endregion
    }
}
