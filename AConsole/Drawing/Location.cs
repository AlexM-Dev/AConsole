using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AConsole.Drawing {
    public class Location : IComparable<Location> {
        public int X { get; set; }
        public int Y { get; set; }
        public Location(int x, int y) {
            this.X = x;
            this.Y = y;
        }
        public Location() { }

        public int CompareTo(Location other) {
            if (other == null) return 1;

            if (other.X < this.X &&
                other.Y < this.Y) return 0;

            return 1;
        }
    }
}
