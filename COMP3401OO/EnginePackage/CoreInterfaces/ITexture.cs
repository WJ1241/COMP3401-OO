using Microsoft.Xna.Framework.Graphics;

namespace COMP3401OO.EnginePackage.CoreInterfaces
{
    /// <summary>
    /// Interface that allows implementations to have a texture
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface ITexture
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows access to get or set value of 'texture'
        /// </summary>
        Texture2D Texture { get;  set; }

        #endregion
    }
}
