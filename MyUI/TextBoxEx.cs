using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyUI
{
    public class TextBoxEx : TextBox
    {
        public int Age { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            RectangleF rect = new RectangleF(ClientRectangle.X,
                                         ClientRectangle.Y,
                                         ClientRectangle.Width,
                                         ClientRectangle.Height);
            e.Graphics.DrawString(this.Text, Font, new SolidBrush(ForeColor), rect);
        }
    }
}
