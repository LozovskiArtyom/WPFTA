using System;
using System.Collections.Generic;
using System.Text;

namespace WPFTA
{
    class Point
    {
        private int count;
        private int steps;

        public Point(int count, int steps)
        {
            this.count = count;
            this.steps = steps;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
