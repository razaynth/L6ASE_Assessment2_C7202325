using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assessment2
{ /// <summary>
  /// Draw circle is method used to create an ellipse
  /// </summary>
    class drawCircle : design
    {
        public int Rad;
        /// <summary>
        /// used to put  a radius for the circle
        /// </summary>
        /// <param name="R">Radius of the circle</param>
        public drawCircle(int R) : base(R, 0)
        {
            Rad = R;
        }
        /// <summary>
        /// Draws a circle on the canvass with the given radius by the user
        /// </summary>
        /// <param name="newCanvass">Display window to draw on</param>
        public override void draw(Canvass newCanvass)
        {
            newCanvass.g.DrawEllipse(newCanvass.pen, newCanvass.Xpos, newCanvass.Ypos, (Rad * 2), (Rad * 2));

            if (newCanvass.fil) ////If conditon to know whether to fill shape or not
            {
                newCanvass.g.FillEllipse(newCanvass.brush, newCanvass.Xpos, newCanvass.Ypos, (Rad * 2), (Rad * 2));
            }

        }
    }
}
