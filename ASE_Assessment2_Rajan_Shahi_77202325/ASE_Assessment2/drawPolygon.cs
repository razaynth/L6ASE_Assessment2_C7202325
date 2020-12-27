using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_Assessment2
{    /// <summary>
     /// Draw polygon is used to create a shape 
     /// </summary>
    class drawPolygon : design

    {
        PointF[] pnts;
        /// <summary>
        ///  To Set a coordinates of polygon value
        /// </summary>
        /// <param name="x">Coordinate of Polygon</param>
        public drawPolygon(int[] x) : base(x[0], x[1])
        {
            int i = 0;
            PointF[] p = new PointF[x.Length];
            while (x.Length > i)
            {
                if ((i + 1) == x.Length)
                {
                    p[i] = new PointF(x[i], x[0]);
                }
                else
                {
                    p[i] = new PointF(x[i], x[i + 1]);
                }
                i++;
            }
            pnts = p;
        }
        /// <summary>
        /// To draw a polygon according to user choice coordinates vlaue
        /// </summary>
        /// <param name="newCanvass">Canvass in which the polygon is drawn</param>
        public override void draw(Canvass newCanvass)
        {
            newCanvass.g.DrawPolygon(newCanvass.pen, pnts);
            // To draw a polygon
            if (newCanvass.fil) //If conditon to know whether to fill shape or not
            {
                newCanvass.g.FillPolygon(newCanvass.brush, pnts);
                //To draws a filled polygon if fill is true
            }
        }
    }
}
