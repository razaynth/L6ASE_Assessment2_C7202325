using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Assessment2
{
    /// <summary>
    /// To draws a triangle on a output window based on the formula of hypotenus, baseside and adjacent side used by the user
    /// </summary>
    class drawTriangle : design
    {
        public int hypotenuse;
        public int baseside;
        public int adjacent;
        /// <summary>
        /// For setting a hypotenuse, base and adjacent for the triangle
        /// </summary>
        /// <param name="h">hypotenuse side of the triangle</param>
        /// <param name="b">baseside side of the triangle</param>
        /// <param name="a">adjacent side of the triangle</param>
        public drawTriangle(int h, int b, int a) : base(h, b)
        {
            hypotenuse = h;
            baseside = b;
            adjacent = a;

        }
        /// <summary>
        /// To draws a triangle on the output windowwith the given hypotenuse, base and adjacent side by the user
        /// </summary>
        /// <param name="newCanvass">Display window to draw on</param>
        public override void draw(Canvass newCanvass)
        {
            PointF h = new Point(newCanvass.Xpos, newCanvass.Ypos);
            PointF b = new Point(newCanvass.Xpos + baseside, newCanvass.Ypos);
            PointF a = new PointF(newCanvass.Xpos + baseside, newCanvass.Ypos + adjacent);
            PointF[] point = { h, b, a };
            newCanvass.g.DrawPolygon(newCanvass.pen, point);
            // To draws a triangle in a output window
            if (newCanvass.fil) //if condition to know whether to fill shape or not
            {

                newCanvass.g.FillPolygon(newCanvass.brush, point);
                //To draws a filled triangle if fill is true
              }
          }
       }

   }
