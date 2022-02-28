using Microsoft.Xna.Framework;

namespace COMP3401OO.EnginePackage.EntityManagement.Interfaces
{
    /// <summary>
    /// Interface that allows implementations to be an on-screen Entity
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public interface IEntity
    {
        #region PROPERTIES

        /// <summary>
        /// Property which can get and set value of an entity's position
        /// </summary>
        Vector2 Position { get; set; }

        /// <summary>
        /// Property which can get and set value of an entity's unique ID
        /// </summary>
        int UID { get; set; }

        /// <summary>
        /// Property which can get and set value of an entity's unique Name
        /// </summary>
        string UName { get; set; }

        #endregion
    }
}
