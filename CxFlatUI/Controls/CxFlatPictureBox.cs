using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
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
            graphics.Clear(Parent.BackColor);

            if (Image == null)
            {
                graphics.FillRectangle(new SolidBrush(ThemeColors.PlaceholderText), new RectangleF(0, 0, Width, Height));
            }
            base.OnPaint(pe);

            var backPath = DrawHelper.CreateRoundRect(0, 00, Width, Height, 4);
            graphics.DrawPath(new Pen(Parent.BackColor,4), backPath);
        }


        public CxFlatPictureBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
        }
    }
}