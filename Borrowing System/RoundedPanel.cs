using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Borrowing_System.RoundedPanel
{
    internal class RoundedPanel : Panel
    {
        //Fields
        private int borderSize = 2;
        private int borderRadius = 20;
        private Color borderColor = Color.Gainsboro;

        public RoundedPanel()
        {
            this.Size = new Size(150, 40);
            this.BackColor = Color.White;
            this.ForeColor = Color.White;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a rectangle representing the panel's area
            RectangleF rect = new RectangleF(0, 0, this.Width, this.Height);

            // Create the rounded path
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
            path.AddArc(rect.Right - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
            path.AddArc(rect.Right - borderRadius, rect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseFigure();

            // Set the panel's region to the rounded path
            this.Region = new Region(path);

            // Draw the border if a border size is specified
            if (borderSize >= 1)
            {
                using (Pen pen = new Pen(borderColor, borderSize))
                {
                    pen.Alignment = PenAlignment.Inset;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }
    } 
}
