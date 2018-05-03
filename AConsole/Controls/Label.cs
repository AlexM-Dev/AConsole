using AConsole;
using AConsole.Drawing;
using AConsole.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AConsole.Controls {
    public class Label : Control {
        public override void Draw() {
            if (Visible) {
                void a() =>
                    ExtendedConsole.BoxTextDraw(Text, Size, Location);
                ExtendedConsole.ActionAt(a, Location);
            }
        }

        public override void Hide() {

        }

        public override void Show() {

        }
    }
}
