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
        private AlertType _type = AlertType.Success;
        [Description("消息框的类型")]
        public AlertType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                Invalidate();
            }
        }

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

        #region 事件
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

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Color.White);

            var backBrush = new SolidBrush(ThemeColors.Theme);
            var textBrush = new SolidBrush(ThemeColors.Theme);
            switch (_type)
            {
                case AlertType.Success:
                    backBrush = new SolidBrush(Color.FromArgb(50, ThemeColors.Success));
                    textBrush = new SolidBrush(ThemeColors.Success);
                    break;
                case AlertType.Warning:
                    backBrush = new SolidBrush(Color.FromArgb(50, ThemeColors.Warning));
                    textBrush = new SolidBrush(ThemeColors.Warning);
                    break;
                case AlertType.info:
                    backBrush = new SolidBrush(Color.FromArgb(50, ThemeColors.Info));
                    textBrush = new SolidBrush(ThemeColors.Info);
                    break;
                case AlertType.Error:
                    backBrush = new SolidBrush(Color.FromArgb(50, ThemeColors.Danger));
                    textBrush = new SolidBrush(ThemeColors.Danger);
                    break;
                default:
                    break;
            }

            var back = DrawHelper.CreateRoundRect(0, 0, Width, Height, 2);
            graphics.FillPath(backBrush, back);
            graphics.DrawString(Text, Font, textBrush, new RectangleF(20, 0, Width - 40, Height), new StringFormat
            {
                Alignment = StringAlignment.Near,
                LineAlignment = StringAlignment.Center
            });
            graphics.DrawString("r", new Font("Marlett", 10), new SolidBrush(DrawHelper.DarkBackColor), new Rectangle(Width - 34, 0, 34, 34), new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });

        }
        public CxFlatAlertBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Font = new Font("微软雅黑", 12);
        }


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
            _type = type;
            Text = text;
            Visible = true;
            _Timer = new Timer();
            _Timer.Interval = Interval;
            _Timer.Enabled = true;
        }
    }
}