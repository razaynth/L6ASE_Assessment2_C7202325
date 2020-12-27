using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ASE_Assessment2
{
    /// <summary>
    /// Class canvass to use many aspects to draw something on panel basically for 
    /// creating different shapes and modifying them
    /// </summary>
    
    public class Canvass
        
       
    { 
        //creating graphics which is use to make some shapes 
        public Graphics g;

        public cmdChecker cmd_chk;

        /// <summary>
        /// usign default pen 
        /// </summary>
        public Pen pen;
        /// <summary>
        /// Declaring xpositon and y position for pen positioning in the bitmap 
        /// </summary>
        public int Xpos, Ypos;
     
        /// <summary>
        /// A solid brush to fill shapes
        /// </summary>
        public SolidBrush brush;
        /// <summary>
        /// check whether user want to fill color or not
        /// </summary>
        public bool fil = false;
        /// <summary>
        /// check whether user feels some error or not
        /// </summary>
        public bool Error = false;
        public keepDictionary Ki;
        public keepMethods km;


        /// <summary>
        /// Intializing canvass with a pen at co-ordinate (0,0)
        /// </summary>
        /// <param name="g">Graphics to draw shapes on bitmap</param>


        public Canvass(Graphics g)
        {

            this.g = g;
            //initializing positions to zero to have something to start with
            Ki = new keepDictionary();
            km = new keepMethods();
            cmd_chk = new cmdChecker();
            Xpos = Ypos = 0;
            pen = new Pen(Color.Black, 1);
            g.DrawRectangle(pen, Xpos, Ypos, 1, 1);
            brush = new SolidBrush(Color.Black);
        }
        /// <summary>
        /// Move to method is used to initialize the position of x and y positions
        /// </summary>
        /// <param name="xpos">X-axis value</param>
        /// <param name="xpos">Y-axis value</param>
        public void moveTo(int xpos, int ypos)
        {
            Xpos = xpos;
            Ypos = ypos;
            g.DrawRectangle(pen, Xpos, Ypos, 1, 1);

        }
        /// <summary>
        /// Draw to method is used to create a line from point x and y
        /// </summary>
        /// <param name="xpos">X-axis value</param>
        /// <param name="ypos">Y-axis value</param>
        public void drawTo(int xpos, int ypos)
        {
            g.DrawLine(pen, Xpos, Ypos, xpos, ypos);
            Xpos = xpos;
            Ypos = ypos;

        }
        /// <summary>
        /// Set_Pencolor is used to set a color as user's choice 
        /// </summary>
        /// <param name="col">this variable is used by user to set a pen color</param>
        public void Set_Pencolor(Color col)
        {
            pen = new Pen(col, 1);
            brush = new SolidBrush(col);
        }
        /// <summary>
        /// To clears the output window box 
        /// </summary>
        public void CLEAR()
        {
            g.Clear(SystemColors.Control);
        }
        /// <summary>
        ///To resets the x and y co-ordinates & start from top position in the picture box
        /// </summary>
        public void RESET()
        {
            Xpos = Ypos = 0;
            pen = new Pen(Color.Black, 1);
            Error = false;
            fil = false;
            g.Clear(SystemColors.Control);
            g.DrawRectangle(pen, Xpos, Ypos, 1, 1);
        }
    }
}
