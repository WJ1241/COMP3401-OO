using Microsoft.Xna.Framework;

namespace COMP2451Project.EnginePackage.CoreInterfaces
{
    /// <summary>
    /// Interface that allows implementations to store a PlayerIndex value
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
