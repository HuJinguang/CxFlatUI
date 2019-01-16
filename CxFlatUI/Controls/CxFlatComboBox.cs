using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace CxFlatUI
{
    public class CxFlatComboBox : ComboBox
    {
        public CxFlatComboBox()
        {
            DrawItem += CxFlatComboBox_DrawItem;
            //SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            //DoubleBuffered = true;
            FlatStyle = FlatStyle.Flat;
            DrawMode = DrawMode.OwnerDrawFixed;

            Font = new Font("微软雅黑", 12F);
            ItemHeight = 30;
        }

        /// <summary>
        /// 返回hWnd参数所指定的窗口的设备环境
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll ")]//导入API函数
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        /// <summary>
        /// 函数释放设备上下文环境（DC）
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hDC"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll ")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //通过响应这条消息，所有者窗口可以通过使用给定的相关显示设备的句柄来设置编辑框的文本和背景颜色
            //windows消息值表：https://blog.csdn.net/zhangguofu2/article/details/19236081
            if (m.Msg == 0x000F //要求一个窗口重绘自己
                || m.Msg == 0x133 //当一个编辑型控件将要被绘制时发送此消息给它的父窗口；
                )
            {
                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0) //如果取设备上下文失败则返回
                {
                    return;
                }

                //建立Graphics对像
                Graphics graphics = Graphics.FromHdc(hDC);

                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.Clear(Parent.BackColor);

                var backPath = DrawHelper.CreateRoundRect(1, 1, Width - 2, Height - 2, 2);
                graphics.FillPath(new SolidBrush(Color.White), backPath);
                graphics.DrawPath(new Pen(ThemeColors.OneLevelBorder, 2), backPath);

                //绘制背景颜色
                graphics.FillRectangle(new SolidBrush(Color.White), new RectangleF(1, 1, Width - 2, Height - 2));

                //绘制文本
                graphics.DrawString(Text, Font, new SolidBrush(ThemeColors.PrimaryColor), new Point(6, 6));

                //绘制下拉箭头
                graphics.DrawString("6", new Font("Marlett", 12), new SolidBrush(SystemColors.ControlDark), new Rectangle(Width - 22, (Height - 18) / 2, 18, 18));
                //释放DC  
                ReleaseDC(m.HWnd, hDC);
            }
        }

        private void CxFlatComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            e.DrawFocusRectangle();

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //绘制被选择的项
                e.Graphics.FillRectangle(new SolidBrush(ThemeColors.ThreeLevelBorder), e.Bounds);
                //绘制文本
                e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(ThemeColors.PrimaryColor), e.Bounds, StringAlign.BottomLeft);
            }
            else
            {
                //绘制未被选择的项
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                var textColor = ThemeColors.MainText;
                //绘制文本
                e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(textColor), e.Bounds, StringAlign.BottomLeft);
            }
            e.Graphics.Dispose();
        }
    }
}