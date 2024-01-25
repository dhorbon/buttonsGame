using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buttonsGame
{
    internal class BButton : Button
    {
        public int x, y;
        public bool state = false;

        public BButton(int x, int y) : base()
        {
            this.x = x;
            this.y = y;
        }

        public void ClickFun()
        {
            if (!state)
            {
                this.BackgroundColor = new Color(255, 0, 0);
            }
            else
            {
                this.BackgroundColor = new Color(255,255,255);
            }

            state = !state;
        }
    }
}
