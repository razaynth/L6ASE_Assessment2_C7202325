using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assessment2
{
    /// <summary>
    /// To draw square or rectangle on output window based on the height and width as user choice
    /// </summary>
    class drawRectangle : design
    {
        
         public int Width;
        public int Height;
        /// <summary>
        /// For setting a width and height for the square or rectangle
        /// </summary>
        /// <param name="w">width of the rectangle</param>
        /// <param name="h">height of the rectangle</param>


        public drawRectangle(int w, int h) : base(w, h)
        {
            Width = w;
            Height = h;

        }
        /// <summary>
        ///  To draw a rectangle or square on the output window with the given width and height by the user
        /// </summary>
        /// <param name="newCanvass">Display window to draw on</param>
        public override void draw(Canvass newCanvass)
        {
            newCanvass.g.DrawRectangle(newCanvass.pen, newCanvass.Xpos, newCanvass.Ypos, Width, Height);

            if (newCanvass.fil)//if condition to know whether to fill shape or not
            {
                newCanvass.g.FillRectangle(newCanvass.brush, newCanvass.Xpos, newCanvass.Ypos, Width, Height);
            }
        }
    }

}
