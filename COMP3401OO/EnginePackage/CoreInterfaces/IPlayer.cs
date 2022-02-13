using Microsoft.Xna.Framework;

namespace COMP3401OO.EnginePackage.CoreInterfaces
{
    /// <summary>
    /// Interface that allows implementations to store a PlayerIndex value
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IPlayer
    {
        #region PROPERTIES

        /// <summary>
        /// Property which can set value of a PlayerIndex
        /// </summary>
        PlayerIndex PlayerNum { set; }

        #endregion
    }
}
