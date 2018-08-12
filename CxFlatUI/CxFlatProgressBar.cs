using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace CxFlatUI
{
    public class CxFlatProgressBar : Control
    {
        private bool _showTip = false;
        public bool ShowTip
        {
            get { return _showTip; }
            set
            {
                _showTip = value;
                Invalidate();
            }
        }

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


        #region 事件
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_showTip)
            {
                Height = Height < 32 ? 32 : Height;
            }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Color.White);

            if (_showTip)
            {
                var x = _valueNumber * (Width - 32) / 100 + 16f;
                var y = 25;
                graphics.FillPolygon(new SolidBrush(Color.FromArgb(255, _themeColor)), new PointF[]
                {
            new PointF(x,y),new PointF(x+5,y-5),new PointF(x+16,y-5),new PointF(x+16,y-25),new PointF(x-16,y-25),new PointF(x-16,y-5),new PointF(x-5,y-5)
                });
                graphics.DrawString(_valueNumber != 100 ? _valueNumber.ToString() + "%" : "ok!", Font, new SolidBrush(Color.White), new RectangleF(x - 16, y - 25, 32, 20), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });

                graphics.FillRectangle(new SolidBrush(Color.FromArgb(55, _themeColor)), new RectangleF(16, 25, Width - 32, Height - 25));
                graphics.FillRectangle(new SolidBrush(_themeColor), new RectangleF(16, 25, x - 16, Height - 25));
            }
            else
            {
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(55, _themeColor)), new RectangleF(0, 0, Width, Height));
                graphics.FillRectangle(new SolidBrush(_themeColor), new RectangleF(0, 0, _valueNumber * Width / 100, Height));
            }
        }

        public CxFlatProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 10);
        }
    }
}