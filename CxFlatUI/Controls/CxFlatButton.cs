using CxFlatUI.Basic;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace CxFlatUI.Controls
{
    public class CxFlatButton : Control
    {
        #region 属性
        [Description("按钮类型"), Category("自定义属性"), RefreshProperties(RefreshProperties.Repaint)]
        public ButtonType Type { get; set; } = ButtonType.Default;

        [Description("是否为朴素按钮"), Category("自定义属性"), RefreshProperties(RefreshProperties.Repaint)]
        public bool Plain { get; set; } = false;

        [Description("是否为圆角按钮"), Category("自定义属性"), RefreshProperties(RefreshProperties.Repaint)]
        public bool Round { get; set; } = false;
        #endregion

        #region 变量
        bool enterFlag = false;
        bool clickFlag = false;
        #endregion

        #region 事件
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            enterFlag = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            enterFlag = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            clickFlag = true;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            clickFlag = false;
            Invalidate();
        }
        #endregion
        
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Helper.DrawHelper.HighQualityGraphics(ref graphics);
            graphics.Clear(Parent.BackColor);

            var color = Colors.GetColorByButtonType(Type);
            //边框颜色
            var borderColor = color;
            //背景颜色
            var backColor = color;
            //遮罩颜色
            var maskColor = Color.FromArgb(35, 255, 255, 255);
            //文本颜色
            var textColor = Color.White;
            
            if (Type == ButtonType.Default)
            {
                borderColor = enterFlag ? (Plain ? Colors.Main : Color.FromArgb(100, Colors.Main)) : Colors.BaseBorder;
                borderColor = clickFlag ? Colors.Main : borderColor;
                backColor = Color.White;
                maskColor = Plain ? Color.FromArgb(35, 255, 255, 255) : Color.FromArgb(35, Colors.Main);
                textColor = enterFlag ? Colors.Main : Colors.PrimaryText;
            }
            else
            {
                if (Plain)
                {
                    borderColor = Color.FromArgb(200, color);
                    backColor = Color.FromArgb(35, color);
                    textColor = enterFlag ? Color.White : color;
                    maskColor = clickFlag ? color : Color.FromArgb(235, color);
                }
                else
                {
                    maskColor = clickFlag ? Color.FromArgb(35, 0, 0, 0) : maskColor;
                }
            }

            GraphicsPath path;
            if (Round)
            {
                path = new GraphicsPath();
                path.AddArc(new RectangleF(0.5f, 0.5f, Height - 1, Height - 1), 90, 180);
                path.AddArc(new RectangleF(Width - Height + 0.5f, 0.5f, Height - 1, Height - 1), 270, 180);
                path.CloseAllFigures();
            }
            else
            {
                path = Helper.DrawHelper.CreateRoundRect(0.5f, 0.5f, Width - 1, Height - 1, 3);
            }

            graphics.FillPath(new SolidBrush(backColor), path);
            graphics.DrawPath(new Pen(borderColor, 1), path);
            if (enterFlag)
            {
                graphics.FillPath(new SolidBrush(maskColor), path);
            }
            graphics.DrawString(Text, Font, new SolidBrush(textColor), new RectangleF(Height / 2, 0, Width - Height, Height), StringAlign.Center);
            if (!Enabled)
            {
                graphics.FillPath(new SolidBrush(Color.FromArgb(100, 255, 255, 255)), path);
            }
        }

        public CxFlatButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Font = new Font("Segoe UI", 12);
        }
    }
}