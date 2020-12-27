using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assessment2
{
    /// <summary>
    /// This keepDictionary class is used to keep provided parameters and values for the user.
    /// </summary>
    public class keepDictionary
    {
        Dictionary<string, int> variable = new Dictionary<string, int>();
        /// <summary>
        /// To store data or value which is provided by user as variable or value 
        /// </summary>
        /// <param name="Name">User defined variable</param>
        /// <param name="Value">User defined value</param>
        public void KeepData(String Name, int Value)
        {
            variable.Add(Name, Value);
        }
        /// <summary>
        /// To Commit user's defined values and parameters
        /// </summary>
        /// <param name="Name">User defined variable</param>
        /// <returns></returns>
        public int Commitdata(String Name)
        {
            int x;
            variable.TryGetValue (Name, out x);
            return x;

        }
        /// <summary>
        /// To re-calculate user given variable  and values
        /// </summary>
        /// <param name="Name">User defined variable</param>
        /// <returns></returns>
        public bool existingValue(String Name)
        {
            int x;
            return variable.TryGetValue(Name, out x);
        }
        /// <summary>
        /// To add user input variable  and value
        /// </summary>
        /// <param name="Name">User defined variable</param>
        /// <param name="Value">User defined value</param>
        public void addValue(String Name, int Value)
        {
            variable[Name] = Value;
        }

        /// <summary>
        /// To clears the value given by user
        /// </summary>
        public void RESET()
        {
            variable.Clear();
        }
    }
}
