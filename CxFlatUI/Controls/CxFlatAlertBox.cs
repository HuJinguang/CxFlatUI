using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CxFlatUI
{
    public class CxFlatAlertBox : Control
    {
        #region 变量
        public enum AlertType
        {
            Success = 0,
            Warning = 1,
            info = 2,
            Error = 3
        };
        #endregion

        #region 属性

        [Description("消息框的类型")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public AlertType Type { get; set; } = AlertType.Success;

        private Timer _timer;
        private Timer _Timer
        {
            get { return _timer; }
            set
            {
                if (_timer != null)
                {
                    _timer.Tick -= Timer_Tick;
                }
                _timer = value;
                if (_timer != null)
                {
                    _timer.Tick += Timer_Tick;
                }
            }

        }

        #endregion

        #region 重写事件
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 34;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Visible = false;
        }
        #endregion

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Parent.BackColor);

            var backBrush = new SolidBrush(ThemeColors.PrimaryColor);
            var textBrush = new SolidBrush(ThemeColors.PrimaryColor);
            switch (Type)
            {
                case AlertType.Success:
                    backBrush = new SolidBrush(Color.FromArgb(25, ThemeColors.Success));
                    textBrush = new SolidBrush(ThemeColors.Success);
                    break;
                case AlertType.Warning:
                    backBrush = new SolidBrush(Color.FromArgb(25, ThemeColors.Warning));
                    textBrush = new SolidBrush(ThemeColors.Warning);
                    break;
                case AlertType.info:
                    backBrush = new SolidBrush(Color.FromArgb(25, ThemeColors.Info));
                    textBrush = new SolidBrush(ThemeColors.Info);
                    break;
                case AlertType.Error:
                    backBrush = new SolidBrush(Color.FromArgb(25, ThemeColors.Danger));
                    textBrush = new SolidBrush(ThemeColors.Danger);
                    break;
                default:
                    break;
            }

            var back = DrawHelper.CreateRoundRect(0.5f, 0.5f, Width-1, Height-1, 3);
            graphics.FillPath(new SolidBrush(Color.White), back);
            graphics.FillPath(backBrush, back);
            graphics.DrawPath(new Pen(textBrush, 1f), back);
            graphics.DrawString(Text, Font, textBrush, new RectangleF(20, 0, Width - 40, Height), StringAlign.Left);
            graphics.DrawString("r", new Font("Marlett", 10), new SolidBrush(DrawHelper.DarkBackColor), new Rectangle(Width - 34, 0, 34, 34), StringAlign.Center);
        }

        #endregion

        #region 构造函数

        public CxFlatAlertBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("微软雅黑", 12);
        }

        #endregion


        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
            _Timer.Enabled = false;
            _Timer.Dispose();
        }

        /// <summary>
        /// 显示AlertBox
        /// </summary>
        /// <param name="type">AlertBox类型</param>
        /// <param name="text">要显示的文本</param>
        /// <param name="Interval">显示时间（毫秒）</param>
        public void ShowAlertBox(AlertType type, string text, int Interval)
        {
            Type = type;
            Text = text;
            Visible = true;
            _Timer = new Timer();
            _Timer.Interval = Interval;
            _Timer.Enabled = true;
        }
    }
}