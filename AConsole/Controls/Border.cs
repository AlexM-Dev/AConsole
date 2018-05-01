using AConsole.Drawing;
using AConsole.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AConsole.Controls {
    public class Border : Control {
        public BorderStyle BorderStyle { get; set; } = BorderStyle.Single;
        public override void Draw() {
            if (Visible) {
                Action a = () => {
                    char[] c = styleToArray(BorderStyle);
                    string line = new string(c[4], Size.Width - 2);

                    Console.Write(c[0] + line + c[1]);

                    for (int i = 1; i < Size.Height - 1; i++) {
                        Console.SetCursorPosition(Location.X, Location.Y + i);
                        Console.Write(c[5]);
                        Console.SetCursorPosition(Location.X +
                            Size.Width - 1, Location.Y + i);
                        Console.Write(c[5]);
                    }
                    Console.SetCursorPosition(Location.X, Size.Height - 1);
                    Console.Write(c[2] + line + c[3]);
                };
                ExtendedConsole.ActionAt(a, Location);
            }
        }

        public override void Hide() {
        }

        public override void Show() {
        }

        // Private methods

        private char[] styleToArray(BorderStyle style) {
            switch (style) {
                case BorderStyle.Single:
                    return "┌┐└┘─│".ToCharArray();
                case BorderStyle.Double:
                    return "╔╗╚╝═║".ToCharArray();
                default:
                    return "      ".ToCharArray();
            }
        }
    }
}
