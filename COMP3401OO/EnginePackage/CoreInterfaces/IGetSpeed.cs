

namespace COMP3401OO.EnginePackage.CoreInterfaces
{
    /// <summary>
    /// Interface that allows implementations to have a read only speed value
    /// Author: William Smith
    /// Date: 24/02/22
    /// </summary>
    public interface IGetSpeed
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows only read access to a speed value
        /// </summary>
        float Speed { get; }

        #endregion 
    }
}
