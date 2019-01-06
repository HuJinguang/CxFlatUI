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
        #region 变量
        bool enterFlag = false;
        bool clickFlag = false;
        #endregion

        #region 属性

        [RefreshProperties(RefreshProperties.Repaint)]
        public ButtonType ButtonType { get; set; } = ButtonType.Primary;

        [RefreshProperties(RefreshProperties.Repaint)]
        public Color TextColor { get; set; } = Color.White;

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
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Parent.BackColor);

            if (ButtonType == ButtonType.Default)
            {
                var BG = DrawHelper.CreateRoundRect(0.5f, 0.5f, Width - 1, Height - 1, 3);
                graphics.FillPath(new SolidBrush(enterFlag ? Color.FromArgb(25, ThemeColors.PrimaryColor) : Color.White), BG);
                graphics.DrawPath(new Pen(clickFlag ? ThemeColors.PrimaryColor : ThemeColors.OneLevelBorder,1), BG);
                graphics.DrawString(Text, Font, new SolidBrush(enterFlag?ThemeColors.PrimaryColor:ThemeColors.MainText), new RectangleF(0, 0, Width, Height), StringAlign.Center);
            }
            else
            {
                var BG = DrawHelper.CreateRoundRect(0, 0, Width, Height, 3);
                var backColor = ThemeColors.PrimaryColor;
                switch (ButtonType)
                {
                    case ButtonType.Primary:
                        backColor = ThemeColors.PrimaryColor;
                        break;
                    case ButtonType.Success:
                        backColor = ThemeColors.Success;
                        break;
                    case ButtonType.Info:
                        backColor = ThemeColors.Info;
                        break;
                    case ButtonType.Waring:
                        backColor = ThemeColors.Warning;
                        break;
                    case ButtonType.Danger:
                        backColor = ThemeColors.Danger;
                        break;
                    default:
                        break;
                }
                
                var brush = new SolidBrush(enterFlag ? (clickFlag ? backColor : Color.FromArgb(225, backColor)) : backColor);
                graphics.FillPath(brush, BG);
                if (!Enabled)
                {
                    graphics.FillPath(new SolidBrush(Color.FromArgb(125, ThemeColors.OneLevelBorder)), BG);
                }
                graphics.DrawString(Text, Font, new SolidBrush(Color.White), new RectangleF(0, 0, Width, Height), StringAlign.Center);
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