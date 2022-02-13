

namespace COMP3401OO.PongPackage.Delegates.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with a CheckPositionDelegate
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IInitialiseCheckPosDel
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a CheckPositionDelegate
        /// </summary>
        /// <param name="pCheckPosDel"> Method which meets the signature of CheckPositionDelegate </param>
        void Initialise(CheckPositionDelegate pCheckPosDel);

        #endregion
    }
}
