using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace COMP3401OO.EnginePackage.CoreInterfaces
{
    /// <summary>
    /// Interface which allows implementations to return a IDictionary<string, Texture2D>
    /// Author: William Smith
    /// Date: 25/02/22
    /// </summary>
    public interface IRtnTextureDict
    {
        #region METHODS

        /// <summary>
        /// Returns a reference to a string, Texture Dictionary
        /// </summary>
        /// <returns> IDictionary<string, Texture2D> object </returns>
        IDictionary<string, Texture2D> ReturnTextureDict();

        #endregion
    }
}
