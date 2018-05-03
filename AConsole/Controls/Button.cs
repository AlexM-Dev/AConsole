using AConsole.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AConsole.Controls {
    class Button : Control {
        public event EventHandler Click =
            new EventHandler((o, e) => { });
        protected void onClick() => 
            Click.Invoke(this, new EventArgs());

        public Button() {
            KeyPress += keyPress;
        }
        public override void Draw() {

        }

        public override void Hide() {
            throw new NotImplementedException();
        }

        public override void Show() {
            throw new NotImplementedException();
        }
        private void keyPress(object sender, KeyEventArgs e) {
            if (e.KeyInfo.Key == ConsoleKey.Enter) onClick();
        }
    }
}
