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
    }
}
