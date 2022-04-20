using System;

namespace COMP3401OO_Engine.Exceptions
{
    /// <summary>
    /// Exception class used for testing if a class exists within a program
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public class ClassDoesNotExistException : Exception
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of ClassDoesNotExistException, calls base constructor passing exception message as a parameter
        /// </summary>
        /// <param name="pMessage"> string value used to display error message to user </param>
        public ClassDoesNotExistException(string pMessage) : base(pMessage)
        {
            // EMPTY CONSTRUCTOR, FUNCTIONALITY WITHIN DECLARATION
        }

        #endregion
    }
}
