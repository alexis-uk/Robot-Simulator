using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    /// <summary>
    /// A tabletop class
    /// </summary>
    public class Tabletop
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Tabletop(int height, int width) {
            this.Height = height;
            this.Width = width;
        }
    }
}
