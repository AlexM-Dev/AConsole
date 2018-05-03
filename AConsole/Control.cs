using AConsole.Events;
using AConsole.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AConsole {
    public abstract class Control {
        /* Properties */
        public BorderStyle BorderStyle { get; set; } = BorderStyle.Single;
        public string Name { get; set; }
        public string Text { get; set; }
        public Location Location { get; set; }
        public Size Size { get; set; }
        public bool Enabled { get; set; } = true;
        public bool RequireArrows { get; set; } = false;
        public bool Visible { get; set; } = true;
        public Location Index { get; set; }
        public Control Parent { get; set; }

        /* Event handlers */
        public event EventHandler Focus = new EventHandler((e, a) => { });
        public event EventHandler LostFocus = new EventHandler((e, a) => { });
        public event EventHandler<KeyEventArgs> KeyPress =
            new EventHandler<KeyEventArgs>((e, a) => { });

        public void OnKeyPress(KeyEventArgs e) => KeyPress(this, e);
        public void OnFocus() => Focus(this, new EventArgs());
        public void OnLostFocus() => LostFocus(this, new EventArgs());

        // Non-interactive method for writing to the console.
        public abstract void Draw();
        public abstract void Show();
        public abstract void Hide();
    }
}
