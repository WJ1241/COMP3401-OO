using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using COMP2451Project.EnginePackage.CoreInterfaces;
using COMP2451Project.EnginePackage.EntityManagement;

namespace COMP2451Project.PongPackage
{
    /// <summary>
    /// Abstract class for Pong Entities to inherit from
    /// </summary>
    public abstract class PongEntity : Entity, IDraw, IUpdatable, ITexture, IVelocity
    {
        #region FIELD VARIABLES

        // DECLARE a Texture2D, call it '_texture':
        protected Texture2D _texture;

        // DECLARE a Vector2, call it '_velocity':
        protected Vector2 _velocity;

        // DECLARE a float, call it 'speed':
        protected float _speed;

        #endregion


        #region IMPLEMENTATION OF IDRAW

        /// <summary>
        /// When called, draws entity's texture on screen
        /// </summary>
        /// <param name="spritebatch">Needed to draw entity's texture on screen</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // DRAW given texture, given location, and colour
            spriteBatch.Draw(_texture, _position, Color.AntiqueWhite);
        }

        #endregion


        #region IMPLEMENTATION OF IUPDATE

        /// <summary>
        /// Updates object when a frame has been rendered on screen
        /// </summary>
        /// <param name="gameTime">holds reference to GameTime object</param>
        public abstract void Update(GameTime gameTime);

        #endregion


        #region IMPLEMENTATION OF ITEXTURE

        /// <summary>
        /// Property which allows access to get or set value of 'texture'
        /// </summary>
        public Texture2D Texture
        {
            get
            {
                // RETURN value of current texture:
                return _texture;
            }
            set
            {
                // ASSIGNMENT give texture value of whichever class is modifying value:
                _texture = value;
            }
        }

        #endregion


        #region IMPLEMENTATION OF IVELOCITY

        /// <summary>
        /// Property which allows access to get value of an entity's velocity
        /// </summary>
        public Vector2 Velocity
        {
            get
            {
                // RETURN value of _velocity(x,y)
                return _velocity;
            }
        }

        #endregion


        #region PROTECTED METHODS

        /// <summary>
        /// Used when an object hits a boundary, possibly to change direction or stop
        /// </summary>
        protected abstract void Boundary();

        #endregion
    }
}
