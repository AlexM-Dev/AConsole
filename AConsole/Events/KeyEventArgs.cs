using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AConsole.Events {
    public class KeyEventArgs : EventArgs {
        public ConsoleKeyInfo KeyInfo { get; set; }
        public KeyEventArgs(ConsoleKeyInfo keyInfo) => KeyInfo = keyInfo;
    }
}
