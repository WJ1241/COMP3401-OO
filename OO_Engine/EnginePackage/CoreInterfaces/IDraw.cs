using Microsoft.Xna.Framework.Graphics;

namespace COMP3401OO_Engine.CoreInterfaces
{
    /// <summary>
    /// Interface that allows implementations to draw an object on screen
    /// Author: William Smith
    /// Date: 23/02/22
    /// </summary>
    public interface IDraw
    {
        #region METHODS

        /// <summary>
        /// When called, draws entity's texture on screen
        /// </summary>
        /// <param name="pSpriteBatch">Needed to draw entity's texture on screen</param>
        void Draw(SpriteBatch pSpriteBatch);

        #endregion

    }
}
