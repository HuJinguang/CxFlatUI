using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace CxFlatUI
{
    public class CxFlatSwitch : CheckBox
    {
        #region 变量

        Timer AnimationTimer = new Timer { Interval = 1 };
        int PointAnimationNum = 3;

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
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.Clear(Parent.BackColor);
            //
            //背景形状
            //
            var backRect = new GraphicsPath();
            backRect.AddArc(new RectangleF(0.5f, 0.5f, Height - 1, Height - 1), 90, 180);
            backRect.AddArc(new RectangleF(Width - Height + 0.5f, 0.5f, Height - 1, Height - 1), 270, 180);
            backRect.CloseAllFigures();
            //
            //背景
            //
            graphics.FillPath(new SolidBrush(Checked ? ThemeColors.PrimaryColor : ThemeColors.OneLevelBorder), backRect);
            //
            //圆形
            //
            graphics.FillEllipse(new SolidBrush(Color.White), new RectangleF(PointAnimationNum, 2, 16, 16));
        }

        public CxFlatSwitch()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer , true);
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
}
