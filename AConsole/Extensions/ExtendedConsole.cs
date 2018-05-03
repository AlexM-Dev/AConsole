using AConsole.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AConsole.Extensions {
    class ExtendedConsole {
        public static void ActionAt(Action a, Location l) {
            Location old = CurrentPos();

            Console.SetCursorPosition(l.X, l.Y);
            a.Invoke();
            Console.SetCursorPosition(old.X, old.Y);
        }
        public static Location CurrentPos() {
            return new Location(Console.CursorLeft, Console.CursorTop);
        }

        public static Control[,] GetGrid(List<Control> controls) {
            int maxX = 0, maxY = 0;
            foreach (Control c in controls) {
                if (c.Location.X > maxX) maxX = c.Index.X + 1;
                if (c.Location.Y > maxY) maxY = c.Index.Y + 1;
            }
            Control[,] grid = new Control[maxX + 1, maxY + 1];
            foreach (Control c in controls)
                grid[c.Index.X, c.Index.Y] = c;
            return grid;
        }
        public static void BoxTextDraw(string text, Size s, Location l) {
            var cList = text.ToCharArray().ToList()
                        .ChunkBy(s.Width - 2);
            for (int i = 0; i < cList.Count; i++) {
                if (i < s.Height - 2) {
                    Console.SetCursorPosition(l.X + 1,
                        ++Console.CursorTop);
                    Console.Write(new string(cList[i].ToArray()));
                }
            }
        }
    }
}
