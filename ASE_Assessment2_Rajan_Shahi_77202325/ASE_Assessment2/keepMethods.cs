using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assessment2
{
    /// <summary>
    /// This method class is used to store methods given by the users
    /// </summary>
    public class keepMethods
    {
         Dictionary<string, string> variable = new Dictionary<string, string>();
        /// <summary>
        /// Parameters & Instruction for methods are stored provided by the user
        /// </summary>
        /// <param name="methodName">User defined method variable</param>
        /// <param name="methodValue">User defined method value</param>
        public void KeepData(String methodName, String methodValue)
        {
            variable.Add(methodName, methodValue);
        }
        /// <summary>
        /// Pulls user defined method parameters and instructions
        /// </summary>
        /// <param name="methodName">User defined method variable</param>
        /// <returns></returns>
        public String Commitdata(String methodName)
        {
            String x;
            variable.TryGetValue(methodName, out x);
            return x;
        }
        /// <summary>
        /// Summarize user provided method parameters and instructions
        /// </summary>
        /// <param name="methodName">User defined method variable</param>
        /// <returns></returns>
        public bool existingValue(String methodName)
        {
            String x;
            return variable.TryGetValue(methodName, out x);
        }
        /// <summary>
        /// Clears the value given by user
        /// </summary>
        public void RESET()
        {
            variable.Clear();
        }
    }
}
