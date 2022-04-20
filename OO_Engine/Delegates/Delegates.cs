

namespace COMP3401OO_Engine.Delegates
{
    //----------------------------------------//

    /// <summary>
    /// C# File to store Delegate Methods related to the engine
    /// Author: William Smith
    /// Date: 06/04/22
    /// </summary>

    //----------------------------------------//

    /// <summary>
    /// Delegate used for Creation
    /// </summary>
    public delegate void CreateDelegate();

    /// <summary>
    /// Delegate used for Creation of multiple objects
    /// </summary>
    /// <param name="pInt"> Any integer to be used to create 'pInt' objects" </param>
    public delegate void CreateMultipleDelegate(int pInt);

    /// <summary>
    /// Delegate used for Deletion with a string parameter
    /// </summary>
    /// <param name="pString"> Any string to be used for deletion process (Object Ref) </param>
    public delegate void DeleteDelegate(string pString);

    /// <summary>
    /// Delegate used for Deletion with an integer parameter
    /// </summary>
    /// <param name="pInt">any integer to be used for deletion process (Integer, Object Ref)</param>
    public delegate void DeleteMultipleDelegate(int pInt);
}
