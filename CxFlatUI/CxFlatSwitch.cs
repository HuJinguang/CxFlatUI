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

public class CxFlatSwitch : CheckBox
{
    #region 变量

    Timer AnimationTimer = new Timer { Interval = 1 };
    int PointAnimationNum = 3;

    #endregion

    #region  属性
    private Color _themeColor = Color.RoyalBlue;
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

    #region 事件

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);
        AnimationTimer.Start();
    }

    protected override void OnResize(EventArgs e)
    {
        Height = 20; Width = 40;
        Invalidate();
    }

    #endregion

    protected override void OnPaint(PaintEventArgs pevent)
    {
        var graphics = pevent.Graphics;
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
        graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
        graphics.Clear(Color.White);
        //
        //背景形状
        //
        var backRect = new GraphicsPath();
        backRect.AddArc(new RectangleF(0, 0, Height, Height), 90, 180);
        backRect.AddArc(new RectangleF(Width - Height, 0, Height, Height), 270, 180);
        backRect.CloseAllFigures();
        //
        //背景
        //
        graphics.FillPath(new SolidBrush(Checked ?  _themeColor: ThemeColors.OneLevelBorder), backRect);
        //
        //圆形
        //
        graphics.FillEllipse(new SolidBrush(Color.White), new RectangleF(PointAnimationNum, 2, 16, 16));
    }

    public CxFlatSwitch()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Height = 20; Width = 42;
        AnimationTimer.Tick += new EventHandler(AnimationTick);
    }

    //
    //动画
    //
    void AnimationTick(object sender, EventArgs e)
    {
        if (Checked)
        {
            if (PointAnimationNum < 21)
            {
                PointAnimationNum += 2;
                this.Invalidate();
            }
        }
        else if (PointAnimationNum > 3)
        {
            PointAnimationNum -= 2;
            this.Invalidate();
        }
    }
}

