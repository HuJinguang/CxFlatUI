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


public class CxFlatStatusBar : ContainerControl
{
    private bool mouseFlag = false;//鼠标状态
    private Point mousePoint;//鼠标位置
    private Rectangle minRectangle;//最小化按钮区域
    private Rectangle maxRectangle;//最大化按钮区域
    private Rectangle closeRectangle;//关闭按钮区域

    private Color _titleColor = Color.FromArgb(255, 255, 255);//标题颜色
    private Color _themeColor = Color.FromArgb(50, 55, 60);//主题颜色
    private Image _iconImage = null;//应用图标

    #region 属性
    [Category("标题颜色")]
    public Color TitleColor
    {
        get { return _titleColor; }
        set
        {
            _titleColor = value;
            Invalidate();
        }
    }

    [Category("背景颜色")]
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
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left)
        {
            mouseFlag = true;
            mousePoint = e.Location;
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (mouseFlag)
        {
            Parent.Location = new Point(
                MousePosition.X - mousePoint.X,
                MousePosition.Y - mousePoint.Y);
        }
        else
        {
            mousePoint = e.Location;
            Invalidate();
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        mouseFlag = false;
    }

    protected override void OnClick(EventArgs e)
    {
        base.OnClick(e);
        if (minRectangle.Contains(mousePoint))
        {
            ParentForm.WindowState = FormWindowState.Minimized;
        }
        if (maxRectangle.Contains(mousePoint))
        {
            if (ParentForm.WindowState == FormWindowState.Maximized)
            {
                ParentForm.WindowState = FormWindowState.Normal;
            }
            else
            {
                ParentForm.WindowState = FormWindowState.Maximized;
            }
        }
        if (closeRectangle.Contains(mousePoint))
        {
            Environment.Exit(0);
        }
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Height = 45;
    }

    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        ParentForm.FormBorderStyle = FormBorderStyle.None;
        ParentForm.AllowTransparency = false;
        ParentForm.FindForm().StartPosition = FormStartPosition.CenterScreen;
        Invalidate();
    }
    #endregion

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Location = new Point(0, 0);
        Width = ParentForm.Width;
        minRectangle = new Rectangle(Width - 76, 14, 18, 18);
        maxRectangle = new Rectangle(Width - 54, 14, 18, 18);
        closeRectangle = new Rectangle(Width - 32, 14, 18, 18);

        Bitmap bitmap = new Bitmap(Width, Height);
        Graphics graphics = Graphics.FromImage(bitmap);

        graphics.SmoothingMode = SmoothingMode.HighQuality;//消除锯齿
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;//高质量显示
        graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;//最高质量显示文本
        graphics.Clear(_themeColor);

        //
        //绘制应用图标
        //
        if (_iconImage != null)
        {
            graphics.DrawImage(_iconImage, new Rectangle(10, 10, 25, 25));
        }

        //
        //绘制标题
        //
        graphics.DrawString(Text, Font, new SolidBrush(_titleColor), new Rectangle(45, 11, Width, Height));

        //
        //最小化按钮
        //
        if (minRectangle.Contains(mousePoint))
        {
            graphics.DrawString("0", new Font("Marlett", 12), new SolidBrush(Color.Blue), minRectangle);
        }
        else
        {
            graphics.DrawString("0", new Font("Marlett", 12), new SolidBrush(Color.White), minRectangle);
        }

        //
        //最大化按钮
        //
        if (maxRectangle.Contains(mousePoint))
        {
            if (ParentForm.WindowState == FormWindowState.Normal)
                graphics.DrawString("1", new Font("Marlett", 12), new SolidBrush(Color.Blue), maxRectangle);
            else
                graphics.DrawString("2", new Font("Marlett", 12), new SolidBrush(Color.Blue), maxRectangle);
        }
        else
        {
            if (ParentForm.WindowState == FormWindowState.Normal)
                graphics.DrawString("1", new Font("Marlett", 12), new SolidBrush(Color.White), maxRectangle);
            else
                graphics.DrawString("2", new Font("Marlett", 12), new SolidBrush(Color.White), maxRectangle);
        }

        //
        //关闭按钮
        //
        if (closeRectangle.Contains(mousePoint))
        {
            graphics.DrawString("r", new Font("Marlett", 12), new SolidBrush(Color.Red), closeRectangle);
        }
        else
        {
            graphics.DrawString("r", new Font("Marlett", 12), new SolidBrush(Color.White), closeRectangle);
        }

        base.OnPaint(e);
        graphics.Dispose();
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
        bitmap.Dispose();
    }

    public CxFlatStatusBar()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
        DoubleBuffered = true;
        Font = new Font("Segoe UI", 12);
        Height = 45;
        Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
    }
}

