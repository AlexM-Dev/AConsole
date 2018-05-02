using AConsole.Events;
using AConsole.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AConsole.Extensions;

namespace AConsole {
    public class Form : Control {
        private ClearConsole clr = new ClearConsole();
        public List<Control> Controls { get; set; } =
            new List<Control>();
        public bool Running { get; set; } = false;
        public int MinDuration { get; set; } = 100;

        private Location currentIndex { get; set; } = new Location(0, 0);
        private new Size Size { get; set; }
        private new Location Location { get; set; }

        public override void Draw() {
            Clear();

            // Controls = Controls.OrderBy((control) => 
            //     control.Index).ToList();
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
            DateTime lastPressedTime = DateTime.MinValue;
            while (Running) {
                // Get user info.
                ConsoleKeyInfo cInfo = Console.ReadKey(true);
                if (DateTime.Now > 
                    lastPressedTime.AddMilliseconds(MinDuration)) {
                    // Bidirectional index.
                    Control[,] grid = ExtendedConsole.GetGrid(Controls);
                    Control current = grid[currentIndex.X, currentIndex.Y];
                    if (!current.RequireArrows) {
                        switch (cInfo.Key) {
                            case ConsoleKey.RightArrow:
                                xMove(grid, current, true);
                                break;
                            case ConsoleKey.LeftArrow:
                                xMove(grid, current, false);
                                break;
                            case ConsoleKey.DownArrow:
                                yMove(grid, current, true);
                                break;
                            case ConsoleKey.UpArrow:
                                yMove(grid, current, false);
                                break;
                            default:
                                current.OnKeyPress(new KeyEventArgs(cInfo));
                                break;
                        }
                    } else current.OnKeyPress(new KeyEventArgs(cInfo));
                    Draw();
                }
                lastPressedTime = DateTime.Now;
            }
        }

        private void xMove(Control[,] grid, Control current, bool up = true) {
            int x = 1, y = currentIndex.Y;
            Location l = null;

            // While the program has not found a location.
            while (l == null) {
                // Get the dimensions of the grid.
                int xlen = grid.GetLength(0),
                    ylen = grid.GetLength(1);
                int diff = currentIndex.X + (up ? x : -x);

                // If it's a valid point: i.e.
                // - if it's within the grid,
                // - if it's a valid control,
                // - if it's enabled.
                if ((up ? (diff < xlen) : (diff >= 0))
                    && grid[diff, y] != null &&
                    grid[diff, y].Enabled) {
                    // Create new location from the control index.
                    l = new Location(diff, y);

                    // Raise lost focus event.
                    current.OnLostFocus();
                    // Set current index to the new location.
                    currentIndex = l;
                    // Raise got focus event.
                    grid[l.X, l.Y].OnFocus();
                    break;
                }
                if ((up ? (diff < xlen) : (diff >= 0))) x++;
                else break;
            }
        }
        private void yMove(Control[,] grid, Control current, bool up = true) {
            int x = currentIndex.X, y = 1;
            Location l = null;

            // While the program has not found a location.
            while (l == null) {
                // Get the dimensions of the grid.
                int xlen = grid.GetLength(0),
                    ylen = grid.GetLength(1);
                int diff = currentIndex.Y + (up ? y : -y);

                // If it's a valid point: i.e.
                // - if it's within the grid,
                // - if it's a valid control,
                // - if it's enabled.
                if ((up ? (diff < ylen) : (diff >= 0))
                    && grid[x, diff] != null &&
                    grid[x, diff].Enabled) {
                    // Create new location from the control index.
                    l = new Location(x, diff);

                    // Raise lost focus event.
                    current.OnLostFocus();
                    // Set current index to the new location.
                    currentIndex = l;
                    // Raise got focus event.
                    grid[l.X, l.Y].OnFocus();
                    break;
                }
                if ((up ? (diff < ylen) : (diff >= 0))) y++;
                else break;
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
        private void Clear() => clr.Clear();
    }
}
