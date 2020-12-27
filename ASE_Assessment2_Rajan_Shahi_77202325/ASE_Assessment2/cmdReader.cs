using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace ASE_Assessment2
{
    /// <summary>
    /// It hels to execute commands which is input by the user in the Input window
    /// </summary>
    public class cmdReader
    {

        int lne = 0;
        /// <summary>
        /// This help to check or reads command line if the line command is single or multiple commands
        /// </summary>
        /// <param name="command">Single Line command</param>
        /// <param name="multicmd">Multiple Line commands</param>
        /// <param name="NewCanvass">Display window to draw on</param>
        public void Cmd(String command, String multicmd, Canvass NewCanvass)
        {
            if (NewCanvass.Error)
            {
                NewCanvass.RESET();
                NewCanvass.Error = false;
            }
            if (multicmd.Length.Equals(0))
            {
                oneCommand(command, NewCanvass);
            }
            else if (command.Equals("run"))
            {
                manyCommand(multicmd, NewCanvass);

            }
            else
            {
                manyCommand(multicmd, NewCanvass);
            }
        }
        /// <summary>
        /// This helps to execute and run application which is based on the input command given by user
        /// <param name="command">used for single line command</param>
        /// <param name="newCanvass"> to display output window to draw on</param>
        public void oneCommand(String command, Canvass newCanvass)
        {
            String[] splitCommand = command.Split(' ');
            userCommands(splitCommand, newCanvass, -1);
        }
        /// <summary>
        /// This helps to run and reads application which is based on the input command given by user
        /// <param name="command">used for single line command</param>
        /// <param name="newCanvass"> to display output window to draw on</param>
        public void manyCommand(String command, Canvass newCanvass)
        {
            String[] splitMcommand = command.Split('\n');
            int n = 0;
            int x = 0;
            while (n < splitMcommand.Length)
            {
                String[] splitCommand = splitMcommand[n].Split(' ');
                if (splitCommand[0].Equals("while"))
                {
                    List<String> data = new List<string>();
                    do
                    {
                        x++;
                        data.Add(splitMcommand[n]);
                        n++;
                        splitCommand = splitMcommand[n].Split(' ');

                    }
                    while (!splitCommand[0].Equals("endwhile"));
                    while_Loop(data, newCanvass, n, x);

                }
                else if (splitCommand[0].Equals("loop"))
                {
                    List<String> data = new List<string>();
                    do
                    {
                        x++;
                        data.Add(splitMcommand[n]);
                        n++;
                        splitCommand = splitMcommand[n].Split(' ');
                    }
                    while (!splitCommand[0].Equals("endfor"));
                    for_Loop(data, newCanvass, n,x );
                  }
                else if (splitCommand[0].Equals("if"))
                {
                    List<String> data = new List<string>();
                    do
                    {
                        x++;
                        data.Add(splitMcommand[n]);
                        n++;
                        splitCommand = splitMcommand[n].Split(' ');
                    }
                    while (!splitCommand[0].Equals("endif"));
                    if_Condition(data, newCanvass, n, x);
                }
                else if (splitCommand[0].Equals("method"))
                {
                    List<String> data = new List<string>();
                    do
                    {
                        x++;
                        data.Add(splitMcommand[n]);
                        n++;
                        splitCommand = splitMcommand[n].Split(' ');
                    }

                    while (!splitCommand[0].Equals("endmethod"));
                    chooseMethod(data, newCanvass, n, x);
                }
                else
                {
                    userCommands(splitCommand, newCanvass, n);
                }
                n++;
            }
        }
        /// <summary>
        /// this create some conditon for user given by variable and data 
        /// <param name="data">data given by user's for some conditional method</param>
        /// <param name="newCanvass">displaying screen in which user given instructions is implemented</param>
        /// <param name="n">line where the program is currently running</param>
        /// <param name="z"></param>

        public void chooseMethod(List<String> data, Canvass newCanvass, int n, int z)

        {
            string VolataryData = string.Join("\n", data);
            String[] value = VolataryData.Split('\n');
            String[] cmd = value[0].Split(' ');
            String x = null;
            bool variable = false;
            String[] commandmethod = cmd[1].Split('(', ')');
            String[] methodValue = null;

            newCanvass.km.KeepData(commandmethod[0], commandmethod[1]);
            List<String> TempList = new List<string>();
            int TempInt = 1;
            while (TempInt < value.Length)
            {
                TempList.Add(value[TempInt]);
                TempInt++;
            }

            try
            {
                if (newCanvass.km.existingValue(commandmethod[0]))
                {
                    x = newCanvass.km.Commitdata(commandmethod[0]);
                    methodValue = x.Split(',');
                }
                else
                {
                    variable = true;
                }
                if (variable)
                {
                    newCanvass.cmd_chk.chk_var(false, cmd[1], n, newCanvass, lne);
                    lne = lne + 20;
                }
                else
                {
                    VolataryData = string.Join("\n", TempList);
                    String methodCommand = commandmethod[0] + "command";
                    newCanvass.km.KeepData(methodCommand, VolataryData);
                }
            }
            catch
            {
                newCanvass.cmd_chk.chk_var(false, "", n - z, newCanvass, lne);
                lne = lne + 20;
            }
        }
        /// <summary>
        /// The variable and data given by the user's input to create a loop condtion statement 
        /// <param name="data">user input data for 'for' condition</param>
        /// <param name="newCanvass">displaying screen in which user given instructions is implemented</param>
        /// <param name="n">line where the program is currently running</param>
        /// <param name="z"></param>
        public void for_Loop(List<String> data, Canvass newCanvass, int n, int z)
        {
            string VolataryData = string.Join("\n", data);
            String[] value = VolataryData.Split('\n');
            String[] cmd = value[0].Split(' ');
            int x = 0;
            bool variable = false;
            List<String> TempList = new List<string>();
            int TempInteger = 1;
            while (TempInteger < value.Length)
            {
                TempList.Add(value[TempInteger]);
                TempInteger++;
            }
            try
            {
                if (cmd[1].Equals("for"))
                {
                    if (!int.TryParse(cmd[2], out x))
                    {
                        if (!newCanvass.Ki.existingValue(cmd[2]))
                        {
                            variable = true;
                        }
                        else
                        {
                            x = newCanvass.Ki.Commitdata(cmd[2]);
                        }
                    }
                }

                if (variable)
                {
                    newCanvass.cmd_chk.chk_var(false, cmd[1], n, newCanvass, lne);
                    lne = lne + 20;
                }
                else
                {

                    for (int b = 0; b < x; b++)
                    {
                        VolataryData = string.Join("\n", TempList);
                        manyCommand(VolataryData, newCanvass);
                    }
                }
            }



            catch
            {
                newCanvass.cmd_chk.chk_var(false, "", n - z, newCanvass, lne);
                lne = lne + 20;
            }
        }
        /// <summary>
        /// Parameters and instructions given by the user creates a if condition statement
        /// </summary>
        /// <param name="data">user input data for 'if' condition</param>
        /// <param name="newCanvass">displaying screen in which user given instructions is implemented</param>
        /// <param name="n">line where the program is currently running</param>
        /// <param name="z"></param>
        public void if_Condition(List<String> data, Canvass newCanvass, int n, int z)

        {
            string VolataryData = string.Join("\n", data);
            String[] value = VolataryData.Split('\n');
            String[] cmd = value[0].Split(' ');
            int x = 0;
            bool variable = false;
            List<String> TempList = new List<string>();
            int TempInteger = 1;
            while (TempInteger < value.Length)
            {
                TempList.Add(value[TempInteger]);
                TempInteger++;
            }
            try
            {
                if (cmd[1].Split('<').Length > 1)
                {
                    String[] TempValue = cmd[1].Split('<');
                    if (!int.TryParse(TempValue[1], out x))
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[1]))
                        {
                            variable = true;
                        }
                        else
                        {
                            x = newCanvass.Ki.Commitdata(TempValue[1]);
                        }
                    }
                    if (variable)
                    {
                        newCanvass.cmd_chk.chk_var(false, TempValue[1], n, newCanvass, lne);
                        lne = lne + 20;
                    }
                    else
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[0]))
                        {
                            variable = true;
                        }
                        if (variable)
                        {
                            newCanvass.cmd_chk.chk_var(false, TempValue[0], n, newCanvass, lne);
                            lne = lne + 20;
                        }
                        else
                        {
                            if (newCanvass.Ki.Commitdata(TempValue[0]) < x)
                            {
                                VolataryData = string.Join("\n", TempList);
                                manyCommand(VolataryData, newCanvass);
                            }
                        }
                    }
                }
                else if (cmd[1].Split('>').Length > 1)
                {
                    String[] TempValue = cmd[1].Split('>');
                    if (!int.TryParse(TempValue[1], out x))
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[1]))
                        {
                            variable = true;
                        }
                        else
                        {
                            x = newCanvass.Ki.Commitdata(TempValue[1]);
                        }
                    }
                    if (variable)
                    {
                        newCanvass.cmd_chk.chk_var(false, TempValue[1], n, newCanvass, lne);
                        lne = lne + 20;
                    }
                    else
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[0]))
                        {
                            variable = true;
                        }
                        if (variable)
                        {
                            newCanvass.cmd_chk.chk_var(false, TempValue[0], n, newCanvass, lne);
                            lne = lne + 20;
                        }
                        else
                        {
                            if (newCanvass.Ki.Commitdata(TempValue[0]) > x)
                            {
                                VolataryData = string.Join("\n", TempList);
                                manyCommand(VolataryData, newCanvass);
                            }
                        }
                    }
                }
                else if (cmd[1].Split('=').Length > 1)
                {

                    String[] TempValue = cmd[1].Split('=');
                    if (!int.TryParse(TempValue[2], out x))
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[2]))
                        {
                            variable = true;
                        }
                        else
                        {
                            x = newCanvass.Ki.Commitdata(TempValue[2]);
                        }
                    }
                    if (variable)
                    {
                        newCanvass.cmd_chk.chk_var(false, TempValue[2], n, newCanvass, lne);
                        lne = lne + 20;
                    }
                    else
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[0]))
                        {
                            variable = true;
                        }
                        if (variable)
                        {
                            newCanvass.cmd_chk.chk_var(false, TempValue[0], n, newCanvass, lne);
                            lne = lne + 20;
                        }
                        else
                        {
                            if (newCanvass.Ki.Commitdata(TempValue[0]) == x)
                            {
                                VolataryData = string.Join("\n", TempList);
                                manyCommand(VolataryData, newCanvass);
                            }
                        }
                    }
                }
                else
                {
                    newCanvass.cmd_chk.chk_var(false, "", n - z, newCanvass, lne);
                    lne = lne + 20;
                }
            }
            catch
            {
                newCanvass.cmd_chk.chk_var(false, "", n - z, newCanvass, lne);
                lne = lne + 20;
            }
        }
        /// <summary>
        /// Parameters and instructions given by the user creates a while loop condition
        /// </summary>
        /// <param name="data">user input data for 'while' condition</param>
        /// <param name="newCanvass">displaying screen in which user given instructions is implemented</param>
        /// <param name="n">line where the program is currently running</param>
        /// <param name="z"></param>
        public void while_Loop(List<String> data, Canvass newCanvass, int n, int z)

        {
            string VolataryData = string.Join("\n", data);
            String[] value = VolataryData.Split('\n');
            String[] cmd = value[0].Split(' ');
            int x = 0;
            bool variable = false;
            List<String> TempList = new List<string>();
            int TempInt = 1;
            while (TempInt < value.Length)
            {

                TempList.Add(value[TempInt]);
                TempInt++;
            }

            try
            {
                if (cmd[1].Split('<').Length > 1)
                {
                    String[] TempValue = cmd[1].Split('<');
                    if (!int.TryParse(TempValue[1], out x))
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[1]))
                        {
                            variable = true;
                        }
                        else
                        {
                            x = newCanvass.Ki.Commitdata(TempValue[1]);
                        }
                    }
                    if (variable)
                    {
                        newCanvass.cmd_chk.chk_var(false, TempValue[1], n, newCanvass, lne);
                        lne = lne + 20;
                    }
                    else
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[0]))
                        {
                            variable = true;
                        }
                        if (variable)
                        {
                            newCanvass.cmd_chk.chk_var(false, TempValue[0], n, newCanvass, lne);
                            lne = lne + 20;
                        }
                        else
                        {
                            while (newCanvass.Ki.Commitdata(TempValue[0]) < x)
                            {
                                VolataryData = string.Join("\n", TempList);
                                manyCommand(VolataryData, newCanvass);
                            }
                        }
                    }
                }
                else if (cmd[1].Split('>').Length > 1)
                {
                    String[] TempValue = cmd[1].Split('>');
                    if (!int.TryParse(TempValue[1], out x))
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[1]))
                        {
                            variable = true;
                        }
                        else
                        {
                            x = newCanvass.Ki.Commitdata(TempValue[1]);
                        }
                    }
                    if (variable)
                    {
                        newCanvass.cmd_chk.chk_var(false, TempValue[1], n, newCanvass, lne);
                        lne = lne + 20;
                    }
                    else
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[0]))
                        {
                            variable = true;
                        }
                        if (variable)
                        {
                            newCanvass.cmd_chk.chk_var(false, TempValue[0], n, newCanvass, lne);
                            lne = lne + 20;
                        }
                        else
                        {
                            while (newCanvass.Ki.Commitdata(TempValue[0]) > x)
                            {
                                VolataryData = string.Join("\n", TempList);
                                manyCommand(VolataryData, newCanvass);
                            }
                        }
                    }
                }
                else if (cmd[1].Split('=').Length > 1)
                {
                    String[] TempValue = cmd[1].Split('=');
                    if (!int.TryParse(TempValue[2], out x))
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[2]))
                        {
                            variable = true;
                        }
                        else
                        {
                            x = newCanvass.Ki.Commitdata(TempValue[2]);
                        }
                    }
                    if (variable)
                    {
                        newCanvass.cmd_chk.chk_var(false, TempValue[2], n, newCanvass, lne);
                        lne = lne + 20;
                    }
                    else
                    {
                        if (!newCanvass.Ki.existingValue(TempValue[0]))
                        {
                            variable = true;
                        }
                        if (variable)
                        {
                            newCanvass.cmd_chk.chk_var(false, TempValue[0], n, newCanvass, lne);
                            lne = lne + 20;
                        }
                        else
                        {
                            while (newCanvass.Ki.Commitdata(TempValue[0]) == x)
                            {
                                VolataryData = string.Join("\n", TempList);
                                manyCommand(VolataryData, newCanvass);
                            }
                        }
                    }
                }
                else
                {
                    newCanvass.cmd_chk.chk_var(false, "", n - z, newCanvass, lne);
                    lne = lne + 20;
                }
            }
            catch
            {
                newCanvass.cmd_chk.chk_var(false, "", n - z, newCanvass, lne);
                lne = lne + 20;
            }


        }
        /// <summary>
        /// This help to execute application provided by user based on the instructions  
        /// </summary>
        /// <param name="splitCommand">User entered commands</param>
        /// <param name="newCanvass">Display window to draw on</param>
        public void userCommands(String[] splitCommand, Canvass newCanvass, int n)
        {
            cmdChecker commandCheck = new cmdChecker();
            try
            {
                String[] method = splitCommand[0].Split('(', ')');
                if (splitCommand[0].Equals("moveto"))
                {
                    String[] data = splitCommand[1].Split(',');
                    int x = 0;
                    int y = 0;
                    bool variable = false;

                    try
                    {
                        if (!int.TryParse(data[0], out x))
                        {
                            if (!newCanvass.Ki.existingValue(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                x = newCanvass.Ki.Commitdata(data[0]);
                            }
                            if (variable)

                            {
                                newCanvass.cmd_chk.chk_var(false, data[0], n, newCanvass, lne);
                                lne = lne + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out y))
                        {
                            if (!newCanvass.Ki.existingValue(data[1]))
                            {
                                variable = true;
                            }
                            else
                            {
                                y = newCanvass.Ki.Commitdata(data[1]);
                            }
                            if (variable)
                            {
                                newCanvass.cmd_chk.chk_var(false, data[1], n, newCanvass, lne);
                                lne = lne + 20;
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        newCanvass.cmd_chk.chk_var(e, newCanvass, n, lne);
                        lne = lne + 20;
                    }
                    if (!newCanvass.Error)
                    {
                        newCanvass.moveTo(x, y);
                    }
                }

                else if (splitCommand[0].Equals("drawto"))
                {
                    String[] data = splitCommand[1].Split(',');
                    int x = 0;
                    int y = 0;
                    bool variable = false;

                    try
                    {
                        if (!int.TryParse(data[0], out x))
                        {
                            if (!newCanvass.Ki.existingValue(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                x = newCanvass.Ki.Commitdata(data[0]);
                            }
                            if (variable)
                            {
                                newCanvass.cmd_chk.chk_var(false, data[0], n, newCanvass, lne);
                                lne = lne + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out y))
                        {
                            if (!newCanvass.Ki.existingValue(data[1]))
                            {
                                variable = true;
                            }
                            else
                            {
                                y = newCanvass.Ki.Commitdata(data[1]);
                            }
                            if (variable)
                            {
                                newCanvass.cmd_chk.chk_var(false, data[1], n, newCanvass, lne);
                                lne = lne + 20;
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        newCanvass.cmd_chk.chk_var(e, newCanvass, n, lne);
                        lne = lne + 20;
                    }
                    if (!newCanvass.Error)
                    {
                        newCanvass.drawTo(x, y);
                    }

                }

                else if (splitCommand[0].Equals("polygon"))
                {
                    String[] data = splitCommand[1].Split(',');
                    List<int> temporaryPoints = new List<int>();
                    int i = 0;
                    int x = 0;
                    int y = 0;
                    int z = 0;
                    bool var1 = false;
                    try
                    {
                        while (data.Length > i)
                        {
                            if (!int.TryParse(data[i], out x))
                            {
                                if (!newCanvass.Ki.existingValue(data[i]))
                                {
                                    var1 = true;
                                }
                                else
                                {
                                    temporaryPoints.Add(newCanvass.Ki.Commitdata(data[i]));
                                }
                                if (var1)
                                {
                                    newCanvass.cmd_chk.chk_var(false, data[i], n, newCanvass, lne);
                                    lne = lne + 20;
                                }
                            }
                            temporaryPoints.Add(x);
                            i++;
                        }
                    }
                    catch (Exception e)
                    {
                        newCanvass.cmd_chk.chk_var(e, newCanvass, n, lne);
                        lne = lne + 20;
                    }
                    if (!newCanvass.Error)
                    {
                        int[] arr = temporaryPoints.ToArray();
                        design poly = new drawPolygon(arr);
                        poly.draw(newCanvass);
                    }
                }
                else if (splitCommand[0].Equals("rectangle"))
                {
                    String[] data = splitCommand[1].Split(',');
                    int H = 0;
                    int W = 0;

                    bool variable = false;

                    try
                    {
                        if (!int.TryParse(data[0], out H))
                        {
                            if (!newCanvass.Ki.existingValue(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                H = newCanvass.Ki.Commitdata(data[0]);
                            }
                            if (variable)
                            {
                                newCanvass.cmd_chk.chk_var(false, data[0], n, newCanvass, lne);
                                lne = lne + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out W))
                        {
                            if (!newCanvass.Ki.existingValue(data[1]))
                            {
                                variable = true;
                            }
                            else
                            {

                                W = newCanvass.Ki.Commitdata(data[1]);
                            }
                            if (variable)
                            {
                                newCanvass.cmd_chk.chk_var(false, data[1], n, newCanvass, lne);
                                lne = lne + 20;
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        newCanvass.cmd_chk.chk_var(e, newCanvass, n, lne);
                        lne = lne + 20;
                    }
                    if (!newCanvass.Error)
                    {
                        design rectangle = new drawRectangle(H, W);
                        rectangle.draw(newCanvass);
                    }
                }

                //Square(s) command
                else if (splitCommand[0].Equals("square"))
                {
                    String[] data = splitCommand[1].Split(',');
                    int s = 0;

                    bool variable = false;

                    try
                    {
                        if (!int.TryParse(data[0], out s))
                        {
                            if (!newCanvass.Ki.existingValue(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                s = newCanvass.Ki.Commitdata(data[0]);
                            }
                            if (variable)
                            {
                                newCanvass.cmd_chk.chk_var(false, data[0], n, newCanvass, lne);
                                lne = lne + 20;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        newCanvass.cmd_chk.chk_var(e, newCanvass, n, lne);
                        lne = lne + 20;
                    }
                    if (!newCanvass.Error)
                    {
                        design square = new drawRectangle(s, s);
                        square.draw(newCanvass);
                    }

                }
                //Circle(r) command
                else if (splitCommand[0].Equals("circle"))
                {
                    String[] data = splitCommand[1].Split(',');
                    int R = 0;
                    bool variable = false;
                    try
                    {
                        if (!int.TryParse(data[0], out R))
                        {
                            if (!newCanvass.Ki.existingValue(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                R = newCanvass.Ki.Commitdata(data[0]);
                            }
                            if (variable)
                            {
                                newCanvass.cmd_chk.chk_var(false, data[0], n, newCanvass, lne);
                                lne = lne + 20;
                            }
                        }
                    }

                    catch (Exception e)
                    {
                        newCanvass.cmd_chk.chk_var(e, newCanvass, n, lne);
                        lne = lne + 20;
                    }
                    if (!newCanvass.Error)
                    {
                        design circle = new drawCircle(R);
                        circle.draw(newCanvass);
                    }
                }
                //Triangle(h,b,a) command
                else if (splitCommand[0].Equals("triangle"))
                {
                    String[] data = splitCommand[1].Split(',');
                    int h = 0;
                    int b = 0;
                    int a = 0;
                    bool variable = false;

                    try
                    {
                        if (!int.TryParse(data[0], out h))
                        {
                            if (!newCanvass.Ki.existingValue(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                h = newCanvass.Ki.Commitdata(data[0]);
                            }
                            if (variable)
                            {
                                newCanvass.cmd_chk.chk_var(false, data[0], n, newCanvass, lne);
                                lne = lne + 20;
                            }
                        }
                        if (!int.TryParse(data[1], out b))
                        {
                            if (!newCanvass.Ki.existingValue(data[1]))
                            {
                                variable = true;
                            }
                            else
                            {
                                b = newCanvass.Ki.Commitdata(data[1]);
                            }
                            if (variable)
                            {
                                newCanvass.cmd_chk.chk_var(false, data[1], n, newCanvass, lne);
                                lne = lne + 20;
                            }
                        }
                        if (!int.TryParse(data[0], out a))
                        {
                            if (!newCanvass.Ki.existingValue(data[0]))
                            {
                                variable = true;
                            }
                            else
                            {
                                a = newCanvass.Ki.Commitdata(data[0]);
                            }
                            if (variable)
                            {
                                newCanvass.cmd_chk.chk_var(false, data[0], n, newCanvass, lne);
                                lne = lne + 20;
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        newCanvass.cmd_chk.chk_var(e, newCanvass, n, lne);
                        lne = lne + 20;
                    }
                    if (!newCanvass.Error)
                    {
                        design triangle = new drawTriangle(h, b, a);
                        triangle.draw(newCanvass);
                    }

                }
                //Pen command
                else if (splitCommand[0].Equals("pen"))
                {

                    Color penColor = Color.FromName(splitCommand[1]);
                    if (penColor.IsKnownColor == false)
                    {
                        commandCheck.chk_var(false, splitCommand[1], n, newCanvass, lne);
                        lne = lne + 20;
                    }

                    if (!newCanvass.Error)
                    {
                        newCanvass.Set_Pencolor(penColor);
                    }
                }
                //Fill command
                else if (splitCommand[0].Equals("fill"))
                {
                    bool valueOn = splitCommand[1].Equals("on");
                    bool valueOff = splitCommand[1].Equals("off");

                    if (valueOn == false && valueOff == false)
                    {
                        commandCheck.chk_var(false, splitCommand[1], n, newCanvass, lne);
                        lne = lne + 20;
                    }
                    if (!newCanvass.Error)
                    {
                        if (valueOn)
                        {
                            newCanvass.fil = true;
                        }
                        else if (valueOff)
                        {
                            newCanvass.fil = false;
                        }
                    }
                }
                //Reset command
                else if (splitCommand[0].Equals("reset"))
                {
                    newCanvass.RESET();
                }

                //Clear command
                else if (splitCommand[0].Equals("clear"))
                {
                    newCanvass.CLEAR();
                }

                //Exit command
                else if (splitCommand[0].Equals("exit"))
                {
                    Application.Exit();
                }
                else if (newCanvass.km.existingValue(method[0]))
                {
                    String[] methodValue = (newCanvass.km.Commitdata(method[0])).Split(',');
                    String methodCmd = method[0] + "command";
                    String methodCommand = newCanvass.km.Commitdata(methodCmd);
                    String[] userValue = method[1].Split(',');
                    int x = 0;
                    while (methodValue.Length > x)
                    {
                        String[] valueStore = (methodValue[x] + " = " + userValue[x]).Split(' ');
                        userCommands(valueStore, newCanvass, n);
                        x++;
                    }
                    manyCommand(methodCommand, newCanvass);
                }


                else if (splitCommand[1].Equals("="))
                {

                    try
                    {
                        if (splitCommand[3].Equals("+"))
                        {
                            int variableValue;
                            int x = 0;
                            int y = 0;
                            bool variable = false;
                            try
                            {
                                if (!int.TryParse(splitCommand[2], out x))
                                {
                                    if (!newCanvass.Ki.existingValue(splitCommand[2]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        x = newCanvass.Ki.Commitdata(splitCommand[2]);
                                    }
                                }
                                if (!int.TryParse(splitCommand[4], out y))
                                {
                                    if (!newCanvass.Ki.existingValue(splitCommand[4]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        y = newCanvass.Ki.Commitdata(splitCommand[4]);
                                    }
                                }
                                if (variable)
                                {
                                    commandCheck.chk_var(false, splitCommand[2], n, newCanvass, lne);
                                    lne = lne + 20;
                                }

                            }
                            catch (Exception e)
                            {

                                commandCheck.chk_var(e, newCanvass, n, lne);
                                lne = lne + 20;
                            }
                            variableValue = x + y;
                            newCanvass.Ki.addValue(splitCommand[0], variableValue);
                        }
                        if (splitCommand[3].Equals("-"))
                        {
                            int variableValue;
                            int x = 0;
                            int y = 0;
                            bool variable = false;
                            try
                            {
                                if (!int.TryParse(splitCommand[2], out x))
                                {
                                    if (!newCanvass.Ki.existingValue(splitCommand[2]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        x = newCanvass.Ki.Commitdata(splitCommand[2]);
                                    }

                                }
                                if (!int.TryParse(splitCommand[4], out y))
                                {
                                    if (!newCanvass.Ki.existingValue(splitCommand[4]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        y = newCanvass.Ki.Commitdata(splitCommand[4]);
                                    }
                                }
                                if (variable)
                                {
                                    commandCheck.chk_var(false, splitCommand[2], n, newCanvass, lne);
                                    lne = lne + 20;
                                }

                            }
                            catch (Exception e)
                            {

                                commandCheck.chk_var(e, newCanvass, n, lne);
                                lne = lne + 20;
                            }
                            variableValue = x - y;
                            newCanvass.Ki.addValue(splitCommand[0], variableValue);
                        }
                        if (splitCommand[3].Equals("*"))
                        {
                            int variableValue;
                            int x = 0;
                            int y = 0;
                            bool variable = false;
                            try
                            {
                                if (!int.TryParse(splitCommand[2], out x))
                                {
                                    if (!newCanvass.Ki.existingValue(splitCommand[2]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        x = newCanvass.Ki.Commitdata(splitCommand[2]);
                                    }
                                }
                                if (!int.TryParse(splitCommand[4], out y))
                                {
                                    if (!newCanvass.Ki.existingValue(splitCommand[4]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        y = newCanvass.Ki.Commitdata(splitCommand[4]);
                                    }
                                }
                                if (variable)
                                {
                                    commandCheck.chk_var(false, splitCommand[2], n, newCanvass, lne);
                                    lne = lne + 20;
                                }
                            }
                            catch (Exception e)
                            {

                                commandCheck.chk_var(e, newCanvass, n, lne);
                                lne = lne + 20;
                            }
                            variableValue = x * y;
                            newCanvass.Ki.addValue(splitCommand[0], variableValue);
                        }
                        if (splitCommand[3].Equals("/"))
                        {
                            int variableValue;
                            int x = 0;
                            int y = 0;
                            bool variable = false;
                            try
                            {
                                if (!int.TryParse(splitCommand[2], out x))
                                {
                                    if (!newCanvass.Ki.existingValue(splitCommand[2]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        x = newCanvass.Ki.Commitdata(splitCommand[2]);
                                    }

                                }
                                if (!int.TryParse(splitCommand[4], out y))
                                {
                                    if (!newCanvass.Ki.existingValue(splitCommand[4]))
                                    {
                                        variable = true;
                                    }
                                    else
                                    {
                                        y = newCanvass.Ki.Commitdata(splitCommand[4]);
                                    }
                                }
                                if (variable)
                                {
                                    commandCheck.chk_var(false, splitCommand[2], n, newCanvass, lne);
                                    lne = lne + 20;
                                }

                            }
                            catch (Exception e)
                            {

                                commandCheck.chk_var(e, newCanvass, n, lne);
                                lne = lne + 20;
                            }
                            variableValue = x / y;
                            newCanvass.Ki.addValue(splitCommand[0], variableValue);
                        }
                    }
                    catch
                    {
                        int x = 0;

                        try
                        {
                            bool variable = false;
                            if (!int.TryParse(splitCommand[2], out x))
                            {
                                if (!newCanvass.Ki.existingValue(splitCommand[2]))
                                {
                                    variable = true;
                                }
                                else
                                {
                                    x = newCanvass.Ki.Commitdata(splitCommand[2]);
                                }
                                if (variable)
                                {
                                    newCanvass.cmd_chk.chk_var(false, splitCommand[2], n, newCanvass, lne);
                                    lne = lne + 20;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            newCanvass.cmd_chk.chk_var(e, newCanvass, n, lne);
                            lne = lne + 20;
                        }
                        if (!newCanvass.Error)
                        {
                            if (!newCanvass.Ki.existingValue(splitCommand[0]))
                            {
                                newCanvass.Ki.KeepData(splitCommand[0], x);
                            }
                            else
                            {
                                newCanvass.Ki.addValue(splitCommand[0], x);
                            }

                        }
                    }
                }
                ///Executes if the given data is not recognized by the application
                else
                {
                    commandCheck.chk_cmd(newCanvass, n, lne);
                    lne = lne + 20;

                }
            }
            catch
            {
                commandCheck.chk_cmd(newCanvass, n, lne);
                lne = lne + 20;
            }
        }
    }
}













                
                            