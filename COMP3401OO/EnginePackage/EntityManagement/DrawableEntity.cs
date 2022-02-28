using COMP3401OO.EnginePackage.CoreInterfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace COMP3401OO.EnginePackage.EntityManagement
{
    /// <summary>
    /// Class for entities that require a texture to be drawn on screen
    /// Author: William Smith
    /// Date: 25/02/22
    /// </summary>
    public class DrawableEntity : Entity, IDraw, IRotation, ITexture
    {
        #region FIELD VARIABLES

        // DECLARE a Texture2D, name it '_texture':
        protected Texture2D _texture;

        // DECLARE a Point, name it '_texSize':
        protected Point _texSize;

        // DECLARE a Vector2, name it '_origin':
        protected Vector2 _origin;

        // DECLARE a float, name it '_rotAngle':
        protected float _rotAngle;

        #endregion


        #region IMPLEMENTATION OF IDRAW

        /// <summary>
        /// When called, draws entity's texture on screen
        /// </summary>
        /// <param name="pSpriteBatch">Needed to draw entity's texture on screen</param>
        public void Draw(SpriteBatch pSpriteBatch)
        {
            // DRAW given texture, given location, colour, angle and origin:
            pSpriteBatch.Draw(_texture, _position, null, Color.AntiqueWhite, _rotAngle, _origin, 1f, SpriteEffects.None, 1f);
        }

        #endregion


        #region IMPLEMENTATION OF IROTATION

        /// <summary>
        /// Property which allows read and write access to a Vector2 containing drawing position
        /// </summary>
        public Vector2 Origin
        {
            get
            {
                // RETURN value of _origin:
                return _origin;
            }
            set
            {
                // SET value of _origin to incoming value:
                _origin = value;
            }
        }

        /// <summary>
        /// Property which allows read and write access to a rotation angle value
        /// </summary>
        public float RotationAngle
        {
            get
            {
                // RETURN value of _rotAngle:
                return _rotAngle;
            }
            set
            {
                // SET value of _rotAngle to incoming value:
                _rotAngle = value;
            }
        }

        #endregion


        #region IMPLEMENTATION OF ITEXTURE

        /// <summary>
        /// Property which allows access to get or set value of 'texture'
        /// </summary>
        public virtual Texture2D Texture
        {
            get
            {
                // RETURN value of current texture:
                return _texture;
            }
            set
            {
                // SET value of _texture to incoming value:
                _texture = value;

                // SET value of _texSize to a new Point passing _texture's dimensions as parameters:
                // SAVES NEEDING TO SET SIZE FROM OUTSIDE, CAN BE CHANGED BY USING PROPERTY
                _texSize = new Point(_texture.Width, _texture.Height);
            }
        }

        /// <summary>
        /// Property which allows access to get or set value of size of 'texture'
        /// </summary>
        public Point TexSize
        {
            get
            {
                // RETURN value of _texSize:
                return _texSize;
            }

            set
            {
                // SET value of _texSize to incoming value:
                _texSize = value;
            }
        }

        #endregion


        #region IMPLEMENTATION OF ITERMINATE

        /// <summary>
        /// Disposes resources to the garbage collector
        /// </summary>
        public override void Termination()
        {
            // No functionality, MonoGame deals with object and texture in garbage collector already
        }

        #endregion
    }
}
