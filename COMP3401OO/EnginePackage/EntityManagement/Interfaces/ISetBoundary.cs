using Microsoft.Xna.Framework;

namespace COMP3401OO.EnginePackage.EntityManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to have access to Screen Size
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    interface ISetBoundary
    {
        #region PROPERTIES

        /// <summary>
        /// Property which can set value of screen window borders
        /// </summary>
        Vector2 WindowBorder { set; }

        #endregion
    }
}
