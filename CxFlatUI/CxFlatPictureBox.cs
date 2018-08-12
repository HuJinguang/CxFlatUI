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

public class CxFlatPictureBox : PictureBox
{
    protected override void OnPaint(PaintEventArgs pe)
    {
        var graphics = pe.Graphics;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        graphics.Clear(Color.White);

        var backPath = DrawHelper.CreateRoundRect(1, 1, Width - 2, Height - 2, 3);
        graphics.FillPath(new SolidBrush(Color.White), backPath);
        graphics.DrawPath(new Pen(ThemeColors.OneLevelBorder), backPath);
        if (Image == null)
        {
            graphics.FillRectangle(new SolidBrush(ThemeColors.PlaceholderText), new RectangleF(5, 5, Width - 10, Height - 10));
        }
        else
        {
            graphics.DrawImage(Image, 5, 5, Width - 10, Height - 10);
        }

        
    }


    public CxFlatPictureBox()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
    }
}