using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CxFlatUI
{
    public class CxFlatPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            var graphics = pe.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Color.White);

            if (Image == null)
            {
                graphics.FillRectangle(new SolidBrush(ThemeColors.PlaceholderText), new RectangleF(5, 5, Width - 10, Height - 10));
            }
            base.OnPaint(pe);

            var backPath = DrawHelper.CreateRoundRect(1, 1, Width - 2, Height - 2, 3);
            graphics.DrawPath(new Pen(Color.White, 8), backPath);
            graphics.DrawPath(new Pen(ThemeColors.OneLevelBorder), backPath);
        }


        public CxFlatPictureBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
        }
    }
}