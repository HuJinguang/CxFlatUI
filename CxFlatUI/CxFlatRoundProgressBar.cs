using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace CxFlatUI
{
    public class CxFlatRoundProgressBar : Control
    {
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

        private Color _themeColor = Color.Blue;
        public Color ThemeColor
        {
            get { return _themeColor; }
            set
            {
                _themeColor = value;
                Invalidate();
            }
        }

        private float _roundWidth = 10;
        public float RoundWidth
        {
            get { return _roundWidth; }
            set
            {
                _roundWidth = value < 5 ? 5 : value;
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
            graphics.Clear(Color.White);

            //绘制扇形
            graphics.FillEllipse(new SolidBrush(Color.FromArgb(55, _themeColor)), new RectangleF(0, 0, Width, Height));
            graphics.FillPie(new SolidBrush(_themeColor), new Rectangle(0, 0, Width, Width), 0, _valueNumber * 3.6f);
            //绘制文字
            graphics.FillEllipse(new SolidBrush(Color.White), new RectangleF(_roundWidth, _roundWidth, Width - _roundWidth * 2, Width - _roundWidth * 2));
            graphics.DrawString(_valueNumber.ToString() + "%", Font, new SolidBrush(_themeColor), new RectangleF(_roundWidth, _roundWidth, Width - _roundWidth * 2, Width - _roundWidth * 2), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });
        }

        public CxFlatRoundProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }
    }
}