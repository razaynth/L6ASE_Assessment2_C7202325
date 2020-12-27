using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Assessment2
{ /// <summary>
  /// this class is used for checking commands which is provided by the user  to check errors or exceptions
  /// </summary>
    public class cmdChecker
    {/// <summary>
     /// This Class is used to display some error when user's input command doesn't found
     /// </summary>
     /// <param name="newCanvass">Canvass used to display error message</param>
     /// <param name="line">the line number of the command to checl</param>
     /// <param name="location">location of output window where error message is displayed</param>
        public void chk_cmd(Canvass newCanvass, int line, int location)
        {
            Font newFont = new Font("Arial", 10);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            line++;
            if (line != 0)
            {
                if (location == 0)
                {
                    newCanvass.RESET();
                }
                newCanvass.g.DrawString("Command on line " + (line) + " doesn't exist", newFont, solidBrush, 0, 0 + location);
            }
            else
            {
                newCanvass.g.DrawString("Command doesn't exist", newFont, solidBrush, 0, 0 + location);
            }
            newCanvass.Error = true;
        }
        /// <summary>
        /// Displays error when enetered parameters are not valid in the context
        /// </summary>
        /// <param name="parameter">Boolean value which gets value accordingly to check valid parameters</param>
        /// <param name="data">invalid parameter</param>
        /// <param name="line">line number of the command</param>
        /// <param name="newCanvass">Canvass used to display error message</param>
        /// <param name="location">location of canvass where error message is displayed</param>
        public void chk_var(bool parameter, String data, int line, Canvass newCanvass, int location)
        {
            if (!parameter)
            {
                Font parameterFont = new Font("Arial", 10);
                SolidBrush solidBrush = new SolidBrush(Color.Black);
                if (location == 0)
                { 
                    newCanvass.RESET();
                }
                if ((line + 1) == 0)
                {
                    newCanvass.g.DrawString("Invalid Parameters on " + data, parameterFont, solidBrush, 0, 0 + location);
                }
                else
                {
                    newCanvass.g.DrawString("Parameter " + data + " on line " + (line+ 1) + " is invalid", parameterFont, solidBrush, 0, 0 + location);

                }
                newCanvass.Error = true;
            }
        }
        /// <summary>
        /// To check Syntax used for exception when the value are input by the user
        /// </summary>
        /// <param name="e">Exception</param>
        /// <param name="newCanvass">Display window to draw on</param>
        public void chk_var(Exception e, Canvass newCanvass, int line, int location)
        {
            Font paramenterFont = new Font("Arial", 10);
            SolidBrush solidBrush = new SolidBrush(Color.Black);
            if (location== 0)
            {
                newCanvass.RESET();
            }
            if ((line + 1) == 0)
            {
                newCanvass.g.DrawString("Wrong number of parameters inserted", paramenterFont, solidBrush, 0, 0 + location);
            }
            else
            {
                newCanvass.g.DrawString("Wrong number of parameters inserted on line" + (line + 1), paramenterFont, solidBrush, 0, 0 + location);
            }

            newCanvass.Error = true;
        }
    }
}