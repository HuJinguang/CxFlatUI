using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;



public class CxFlatGroupBox : GroupBox
{
    private Color _themeColor = Color.Blue;

    #region 属性
    public Color ThemeColor
    {
        get { return _themeColor; }
        set
        {
            _themeColor = value;
            Invalidate();
        }
    }
    #endregion

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics graphics = e.Graphics;
        graphics.SmoothingMode = SmoothingMode.HighQuality;//消除锯齿
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;//高质量显示
        graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;//最高质量显示文本
        graphics.Clear(Color.White);

        var BG = DrawHelper.CreateRoundRect(1, 1, Width - 2, Height - 2, 3);
        var tempColor = ColorTranslator.FromHtml("#dadcdf");
        graphics.FillPath(new SolidBrush(Color.White), BG);
        graphics.DrawPath(new Pen(tempColor), BG);
        graphics.FillRectangle(new SolidBrush(_themeColor), new Rectangle(0, 0, 5, 45));
        graphics.FillRectangle(new SolidBrush(tempColor), new Rectangle(5, 0, Width - 5, 45));
        graphics.DrawString(Text, Font, new SolidBrush(Color.Black), new RectangleF(25, 0, Width - 25, 45), new StringFormat
        {
            Alignment = StringAlignment.Near,
            LineAlignment = StringAlignment.Center
        });

    }

    public CxFlatGroupBox()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 12);
    }
}

