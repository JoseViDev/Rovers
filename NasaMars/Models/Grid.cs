using System;
using System.Collections.Generic;
using System.Text;

namespace NasaMars
{
    public sealed class Grid
    {
        public int LimitX { get; set; }
        public int LimitY { get; set; }

        private readonly static Grid _instance = new Grid();

        private Grid()
        {
        }

        public static Grid Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
