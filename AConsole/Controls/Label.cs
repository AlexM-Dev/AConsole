using AConsole;
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
                void a() {
                    var cList = Text.ToCharArray().ToList()
                                .ChunkBy(Size.Width);
                    for (int i = 0; i < cList.Count; i++) {
                        if (i < Size.Height) {
                            Console.Write(new string(cList[i].ToArray()));
                            Console.SetCursorPosition(Location.X,
                                ++Console.CursorTop);
                        }
                    }
                }
                ExtendedConsole.ActionAt(a, Location);
            }
        }

        public override void Hide() {
            
        }

        public override void Show() {

        }
    }
}
