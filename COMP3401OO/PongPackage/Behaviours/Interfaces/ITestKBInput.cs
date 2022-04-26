

namespace COMP3401OO.PongPackage.Behaviours.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to have their keyboard inputs tested
    /// Author: William Smith
    /// Date: 26/02/22
    /// </summary>
    public interface ITestKBInput
    {
        #region PROPERTIES

        /// <summary>
        /// Property which gives caller write access to what key is pressed
        /// </summary>
        string SetKeyPressed { set; }

        #endregion
    }
}
