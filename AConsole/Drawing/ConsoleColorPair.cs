using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AConsole.Drawing {
    class ConsoleColorPair {
        public ConsoleColor BackgroundColor { get; set; }
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColorPair() { }
        public ConsoleColorPair(ConsoleColor background, 
            ConsoleColor foreground) {
            this.BackgroundColor = background;
            this.ForegroundColor = foreground;
        }
        public static ConsoleColorPair FromCurrent() { 
            return new ConsoleColorPair(Console.BackgroundColor,
                Console.ForegroundColor);
        }
        public void Set() {
            Console.BackgroundColor = this.BackgroundColor;
            Console.ForegroundColor = this.ForegroundColor;
        }
        public void Flip() {
            var back = this.BackgroundColor;

            this.BackgroundColor = this.ForegroundColor;
            this.ForegroundColor = back;
        }
        public void FlipAndSet() {
            Flip(); Set();
        }
    }
}
