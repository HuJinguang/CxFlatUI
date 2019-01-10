using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace CxFlatUI
{
    public class CxFlatStatusBar : ContainerControl
    {
        private bool mouseFlag = false;//鼠标状态
        private Point mousePoint;//鼠标位置
        private Rectangle minRectangle;//最小化按钮区域
        private Rectangle maxRectangle;//最大化按钮区域
        private Rectangle closeRectangle;//关闭按钮区域

        private Color _themeColor = ThemeColors.LightPrimary;//主题颜色
        private Image _iconImage = null;//应用图标
        #region 属性

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

        /// <summary>
        /// 是否显示最小化
        /// </summary>
        [DefaultValue(true)]
        [Category("获取或设置一个值，该值指示是否在窗体的标题栏中显示“最小化”按钮。")]
        public bool MinimizeBox
        {
            get
            {
                return ParentForm.MinimizeBox;
            }
        }

        /// <summary>
        /// 是否显示最大化
        /// </summary>
        [DefaultValue(true)]
        [Category("获取或设置一个值，该值指示是否在窗体的标题栏中显示“最大化”按钮。")]
        public bool MaximizeBox
        {
            get
            {
                return ParentForm.MaximizeBox;
            }
        }

        /// <summary>
        /// 控件框是否显示在标题中
        /// </summary>
        [DefaultValue(true)]
        [Category("获取或设置一个值，该值指示控件框是否显示在标题中")]
        public bool ControlBox
        {
            get
            {
                return ParentForm.ControlBox;
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
            Height = 40;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            ParentForm.FormBorderStyle = FormBorderStyle.None;
            ParentForm.AllowTransparency = false;
            ParentForm.FindForm().StartPosition = FormStartPosition.CenterScreen;
            ParentForm.MaximumSize = Screen.PrimaryScreen.WorkingArea.Size;
            Invalidate();
        }
        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Location = new Point(0, 0);
            Width = ParentForm.Width;

            Bitmap bitmap = new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.SmoothingMode = SmoothingMode.HighQuality;//消除锯齿
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;//高质量显示
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;//最高质量显示文本
            graphics.Clear(_themeColor);

            var icoFont = new Font("Marlett", 12);
            //
            //绘制应用图标
            //
            if (_iconImage != null)
            {
                graphics.DrawImage(_iconImage, new Rectangle(10, 10, 25, 25));
                //
                //绘制标题
                //
                graphics.DrawString(Text, new Font("微软雅黑", 12f), new SolidBrush(ThemeColors.FourLevelBorder), new Rectangle(45, 1, Width - 100, Height), StringAlign.Left);
            }
            else
            {
                //
                //绘制标题
                //
                graphics.DrawString(Text, new Font("微软雅黑", 12f), new SolidBrush(ThemeColors.FourLevelBorder), new Rectangle(15, 1, Width - 100, Height), StringAlign.Left);
            }

            if (ControlBox)
            {
                if (MinimizeBox)
                {
                    minRectangle = new Rectangle(Width - 54 - (MaximizeBox ? 1 : 0) * 22, (Height - 16) / 2, 18, 18);
                    //
                    //最小化按钮
                    //
                    if (minRectangle.Contains(mousePoint))
                    {
                        graphics.DrawString("0", icoFont, new SolidBrush(ThemeColors.TwoLevelBorder), minRectangle, StringAlign.Center);
                    }
                    else
                    {
                        graphics.DrawString("0", icoFont, new SolidBrush(Color.White), minRectangle, StringAlign.Center);
                    }
                }
                if (MaximizeBox)
                {
                    maxRectangle = new Rectangle(Width - 54, (Height - 16) / 2, 18, 18);
                    //
                    //最大化按钮
                    //
                    if (maxRectangle.Contains(mousePoint))
                    {
                        if (ParentForm.WindowState == FormWindowState.Normal)
                            graphics.DrawString("1", icoFont, new SolidBrush(ThemeColors.TwoLevelBorder), maxRectangle, StringAlign.Center);
                        else
                            graphics.DrawString("2", icoFont, new SolidBrush(ThemeColors.TwoLevelBorder), maxRectangle, StringAlign.Center);
                    }
                    else
                    {
                        if (ParentForm.WindowState == FormWindowState.Normal)
                            graphics.DrawString("1", icoFont, new SolidBrush(Color.White), maxRectangle, StringAlign.Center);
                        else
                            graphics.DrawString("2", icoFont, new SolidBrush(Color.White), maxRectangle, StringAlign.Center);
                    }
                }

                closeRectangle = new Rectangle(Width - 32, (Height - 16) / 2, 18, 18);
                //
                //关闭按钮
                //
                if (closeRectangle.Contains(mousePoint))
                {
                    graphics.DrawString("r", icoFont, new SolidBrush(ThemeColors.Danger), closeRectangle, StringAlign.Center);
                }
                else
                {
                    graphics.DrawString("r", icoFont, new SolidBrush(Color.White), closeRectangle, StringAlign.Center);
                }
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
            Height = 40;
            Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        }
    }
}