using AConsole.Events;
using AConsole.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AConsole {
    public class Form : Control {
        public List<Control> Controls { get; set; } =
            new List<Control>();
        public bool Running { get; set; } = false;
        public int MinDuration { get; set; } = 100;

        private int currentIndex { get; set; } = 0;
        private new Size Size { get; set; }
        private new Location Location { get; set; }

        public override void Draw() {
            Clear();

            Controls = Controls.OrderBy(control => control.Index).ToList();
            foreach (Control c in Controls) {
                c.Parent = this;
                c.Draw();
            }
        }

        public override void Hide() {
            Running = false;
        }

        public override void Show() {
            Running = true;
            Draw();
            while (Running) {
                // Get user info.
                ConsoleKeyInfo cInfo = Console.ReadKey(true);
                Console.Title = currentIndex.ToString();
                if (currentIndex > Controls.Count - 1) continue;
                switch (cInfo.Key) {
                    case ConsoleKey.UpArrow:
                        if (currentIndex - 1 >= 0 &&
                            Controls[currentIndex - 1].Enabled) currentIndex--;
                        Controls[currentIndex].OnFocus();
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentIndex + 1 < Controls.Count &&
                            Controls[currentIndex + 1].Enabled) currentIndex++;
                        Controls[currentIndex].OnFocus();
                        break;
                    default:
                        if (currentIndex < Controls.Count &&
                            Controls[currentIndex].Enabled)
                            Controls[currentIndex]
                                .OnKeyPress(new KeyEventArgs(cInfo));
                        break;
                }
                Draw();
            }
        }

        public Form() {
            Init();
        }
        public Form(Control[] controls) {
            Controls.AddRange(controls);

            Init();
        }

        private void Init() {
            // Remove the scrollbars.
            Console.SetBufferSize(Console.WindowWidth,
                Console.WindowHeight);

            // Hide the caret, as this is Console forms.
            Console.CursorVisible = false;
        }

        private void Clear() {
            Console.Clear();
        }
    }
}
