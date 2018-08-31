using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace CxFlatUI
{
    public class CxFlatRoundProgressBar : Control
    {
        #region 变量
        #endregion

        private int tempValue = 0;
        private int _valueNumber = 0;
        public int ValueNumber
        {
            get { return _valueNumber; }
            set
            {
                _valueNumber = value > 100 ? 100 : (value < 0 ? 0 : value);
                Invalidate();
            }
        }

        private float _roundWidth = 6;

        private bool _isError = false;
        public bool IsError
        {
            get { return _isError; }
            set
            {
                _isError = value;
                Invalidate();
            }
        }

        #region 事件
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Width = Height;
        }
        #endregion
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Parent.BackColor);

            graphics.FillEllipse(new SolidBrush(ThemeColors.OneLevelBorder), new Rectangle(0, 0, Width, Height));

            if(_isError)
            {
                //绘制扇形
                graphics.FillPie(new SolidBrush(ThemeColors.Danger), new Rectangle(0, 0, Width, Width), 0, _valueNumber * 3.6f);
                //绘制文字
                graphics.FillEllipse(new SolidBrush(Color.White), new RectangleF(_roundWidth, _roundWidth, Width - _roundWidth * 2, Width - _roundWidth * 2));
                graphics.DrawLine(new Pen(ThemeColors.Danger, 2f), Width / 2 - 6, Height / 2 - 6, Width / 2 + 6, Height / 2 + 6);
                graphics.DrawLine(new Pen(ThemeColors.Danger, 2f), Width / 2 - 6, Height / 2 + 6, Width / 2 + 6, Height / 2 - 6);
            }
            else
            {
                if(_valueNumber==100)
                {
                    graphics.FillPie(new SolidBrush(ThemeColors.Success), new Rectangle(0, 0, Width, Width), 0, _valueNumber * 3.6f);  
                    graphics.FillEllipse(new SolidBrush(Color.White), new RectangleF(_roundWidth, _roundWidth, Width - _roundWidth * 2, Width - _roundWidth * 2));
                    graphics.DrawLine(new Pen(ThemeColors.Success, 2f), Width / 2 - 6, Height / 2, Width / 2-3, Height / 2 + 6);
                    graphics.DrawLine(new Pen(ThemeColors.Success, 2f), Width / 2 + 6, Height / 2 - 6, Width / 2-3, Height / 2 + 6);
                }
                else
                {
                    graphics.FillPie(new SolidBrush(ThemeColors.PrimaryColor), new Rectangle(0, 0, Width, Width), 0, _valueNumber * 3.6f);
                    graphics.FillEllipse(new SolidBrush(Color.White), new RectangleF(_roundWidth, _roundWidth, Width - _roundWidth * 2, Width - _roundWidth * 2));
                    graphics.DrawString(_valueNumber.ToString()+"%", new Font("微软雅黑", 12f), new SolidBrush(ThemeColors.PrimaryColor), new RectangleF(_roundWidth, _roundWidth, Width - (_roundWidth * 2), Width - (_roundWidth * 2)), StringAlign.Center);
                }
            }
        }

        public CxFlatRoundProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }
    }
}