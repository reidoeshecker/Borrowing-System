using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Borrowing_System 
{
    public class SidebarButton : Button
    {
        // Custom Properties
        private int borderRadius = 15;
        private bool isActive = false;
        private Color indicatorColor = Color.ForestGreen;

        // New Border Properties
        private int buttonBorderSize = 2; 
        private Color buttonBorderColor = Color.Gainsboro;

        public int ButtonBorderSize
        {
            get { return buttonBorderSize; }
            set { buttonBorderSize = value; this.Invalidate(); }
        }

        public Color ButtonBorderColor
        {
            get { return buttonBorderColor; }
            set { buttonBorderColor = value; this.Invalidate(); }
        }

        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; this.Invalidate(); }
        }

        // Toggles the green line on the right side on/off
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; this.Invalidate(); }
        }

        public Color IndicatorColor
        {
            get { return indicatorColor; }
            set { indicatorColor = value; this.Invalidate(); }
        }

        public SidebarButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(220, 50);

            this.TextAlign = ContentAlignment.MiddleRight;
            this.ImageAlign = ContentAlignment.MiddleCenter;
            this.BackColor = Color.White;
            this.Padding = new Padding(15, 0, 0, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // 1. Cut out the rounded corners
            RectangleF rect = new RectangleF(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
            path.AddArc(rect.Right - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
            path.AddArc(rect.Right - borderRadius, rect.Bottom - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseFigure();

            this.Region = new Region(path);

            // 2. Let the normal button draw the background, text, and icon
            base.OnPaint(e);

            // 3. Draw the outer Gainsboro border
            if (buttonBorderSize >= 1)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(buttonBorderColor, buttonBorderSize))
                {
                    pen.Alignment = PenAlignment.Inset; // Keeps the border inside the button edges
                    e.Graphics.DrawPath(pen, path);
                }
            }

            // 4. Draw the rounded indicator line on the right side if active
            if (isActive)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int lineWidth = 4;
                int lineHeight = this.Height - 24;
                int lineX = this.Width - lineWidth - 15;
                int lineY = 12;

                using (Pen pen = new Pen(indicatorColor, lineWidth))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    e.Graphics.DrawLine(pen, lineX, lineY, lineX, lineY + lineHeight);
                }
            }
        }

        // Triggers the moment the user clicks down
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            this.BackColor = Color.ForestGreen;
            this.ForeColor = Color.White; // Turns text white so it pops against the dark green
        }

        // Triggers the moment the user releases the click
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            this.BackColor = Color.White;
            this.ForeColor = Color.ForestGreen; // Reverts text back to black
        }
    }
}