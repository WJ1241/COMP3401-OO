using Microsoft.Xna.Framework;

namespace COMP3401OO.EnginePackage.EntityManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to have access to Screen Size
    /// Author: William Smith
    /// Date: 26/02/22
    /// </summary>
    public interface IContainBoundary
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows read and write access to screen borders
        /// </summary>
        Point WindowBorder { get; set; }

        #endregion
    }
}
