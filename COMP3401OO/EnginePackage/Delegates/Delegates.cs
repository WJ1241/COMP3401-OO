using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3401OO.EnginePackage.Delegates
{
    //----------------------------------------//

    /// <summary>
    /// C# File to store Delegate Methods related to the engine
    /// Author: William Smith
    /// Date: 13/02/22
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
}
