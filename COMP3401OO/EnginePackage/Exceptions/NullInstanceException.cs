using System;

namespace COMP3401OO.EnginePackage.Exceptions
{
    /// <summary>
    /// Exception class used for testing if a passed in instance is null
    /// Author: William Smith
    /// Date: 23/02/22
    /// </summary>
    public class NullInstanceException : Exception
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of NullInstanceException, calls base constructor passing exception message as a parameter
        /// </summary>
        /// <param name="pMessage"> string value used to display error message to user </param>
        public NullInstanceException(string pMessage) : base(pMessage)
        {
            // EMPTY CONSTRUCTOR, FUNCTIONALITY WITHIN DECLARATION
        }

        #endregion
    }
}
