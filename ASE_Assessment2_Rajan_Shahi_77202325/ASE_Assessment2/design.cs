using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Assessment2
{     /// <summary>
      /// using Abstract class for Design 
      /// </summary>
    abstract class design
    {
        int Height;
        int Width;

        /// <summary>
        /// For putiing values for Height and Width
        /// </summary>
        /// <param name="H">Height</param>
        /// <param name="W">Width</param>
        public design(int H, int W)

        {

            Height = H;
            Width = W;

        }
        /// <summary>
        /// using Abstract method to create a design
        /// </summary>
        /// <param name="newCanvass">Display some bitmap picture to draw on output window</param>
        public abstract void draw(Canvass newCanvass);
    }
}
