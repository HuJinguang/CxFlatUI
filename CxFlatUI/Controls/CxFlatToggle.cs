using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace CxFlatUI
{
    public class CxFlatToggle : CheckBox
    {
        #region 变量

        Timer AnimationTimer = new Timer { Interval = 1 };
        int PointAnimationNum = 4;

        #endregion

        #region  属性
        #endregion

        #region 事件

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AnimationTimer.Start();
        }

        protected override void OnResize(EventArgs e)
        {
            Height = 20; Width = 48;
            Invalidate();
        }

        #endregion

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Parent.BackColor);
            //
            //背景形状
            //
            var roundRectangle = new GraphicsPath();
            var radius = 9;
            roundRectangle.AddArc(11, 5, radius - 1, radius, 180, 90);
            roundRectangle.AddArc(Width - 21, 5, radius - 1, radius, -90, 90);
            roundRectangle.AddArc(Width - 21, Height - 14, radius - 1, radius, 0, 90);
            roundRectangle.AddArc(11, Height - 14, radius - 1, radius, 90, 90);
            roundRectangle.CloseAllFigures();
            //
            //背景
            //
            graphics.FillPath(new SolidBrush(Checked ? Color.FromArgb(100, ThemeColors.PrimaryColor) : ThemeColors.OneLevelBorder), roundRectangle);
            //
            //圆形
            //
            graphics.FillEllipse(new SolidBrush(Checked ? ThemeColors.PrimaryColor: ThemeColors.OneLevelBorder), new RectangleF(PointAnimationNum, 1, 18, 18));
            graphics.FillEllipse(new SolidBrush(Checked ? ThemeColors.PrimaryColor : Color.White), new RectangleF(PointAnimationNum+2, 3, 14, 14));
        }

        public CxFlatToggle()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer , true);
            DoubleBuffered = true;
            Height = 20; Width = 47;
            AnimationTimer.Tick += new EventHandler(AnimationTick);
        }

        //
        //动画
        //
        void AnimationTick(object sender, EventArgs e)
        {
            if (Checked)
            {
                if (PointAnimationNum < 24)
                {
                    PointAnimationNum += 2;
                    this.Invalidate();
                }
            }
            else if (PointAnimationNum > 4)
            {
                PointAnimationNum -= 2;
                this.Invalidate();
            }
        }
    }
}
