using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace CxFlatUI
{
    public class CxFlatRadioButton : RadioButton
    {
        #region 变量
        Color EnabledCheckedColor;
        Color EnabledUnCheckedColor = ColorTranslator.FromHtml("#9c9ea1");
        Color DisabledColor = ColorTranslator.FromHtml("#c4c6ca");
        Color EnabledStringColor = ColorTranslator.FromHtml("#929292");
        Color DisabledStringColor = ColorTranslator.FromHtml("#babbbd");
        int SizeAnimationNum = 0;
        int PointAnimationNum = 10;
        Timer SizeAnimationTimer = new Timer { Interval = 35 };
        bool enterFalg = false;
        #endregion

        private Color _checkedColor = ThemeColors.PrimaryColor;

        #region 属性
        [Category("选中时的颜色")]
        public Color CheckedColor
        {
            get { return _checkedColor; }
            set
            {
                _checkedColor = value;
                Invalidate();
            }
        }
        #endregion

        #region 事件
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SizeAnimationTimer.Start();
        }

        protected override void OnResize(EventArgs e)
        {
            Height = 20;
            Width = 25 + (int)CreateGraphics().MeasureString(Text, Font).Width;
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);
            enterFalg = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);
            enterFalg = false;
            Invalidate();
        }
        #endregion

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Parent.BackColor);

            Rectangle BGEllipse = new Rectangle(1, 1, 18, 18);
            EnabledCheckedColor = _checkedColor;
            SolidBrush BG = new SolidBrush(Enabled ? (Checked || enterFalg ? EnabledCheckedColor : EnabledUnCheckedColor) : DisabledColor);

            graphics.FillEllipse(BG, BGEllipse);
            graphics.FillEllipse(new SolidBrush(Color.White), new Rectangle(3, 3, 14, 14));

            graphics.FillEllipse(BG, new Rectangle(PointAnimationNum, PointAnimationNum, SizeAnimationNum, SizeAnimationNum));

            //绘制文本
            graphics.DrawString(Text, Font, new SolidBrush(Checked ? _checkedColor : Color.Black), new RectangleF(22, 0, Width - 22, Height), StringAlign.Center);
        }

        //
        //选择动画
        //
        private void AnimationTick(object sender, EventArgs e)
        {
            if (Checked)
            {
                if (SizeAnimationNum < 8)
                {
                    SizeAnimationNum += 2;
                    PointAnimationNum -= 1;
                    this.Invalidate();
                }
            }
            else if (SizeAnimationNum != 0)
            {
                SizeAnimationNum -= 2;
                PointAnimationNum += 1;
                this.Invalidate();
            }
        }


        public CxFlatRadioButton()
        {
            SizeAnimationTimer.Tick += new EventHandler(AnimationTick);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12);
        }
    }
}