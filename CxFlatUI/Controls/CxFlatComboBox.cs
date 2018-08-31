using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace CxFlatUI
{
    public class CxFlatComboBox:ComboBox
    {
        public CxFlatComboBox()
        {
            DrawItem += CxFlatComboBox_DrawItem;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            FlatStyle = FlatStyle.Flat;
            DrawMode = DrawMode.OwnerDrawFixed;
            
            Font = new Font("微软雅黑", 12F);
            ItemHeight = 30;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var bitmap = new Bitmap(Width, Height);
            var graphics = Graphics.FromImage(bitmap);
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            
            graphics.Clear(Parent.BackColor);
            var backPath = DrawHelper.CreateRoundRect(1, 1, Width-2, Height-2, 2);
            graphics.FillPath(new SolidBrush(Color.White), backPath);
            graphics.DrawPath(new Pen(ThemeColors.OneLevelBorder,2), backPath);

            //绘制背景颜色
            graphics.FillRectangle(new SolidBrush(Color.White), new RectangleF(0,0,Width,Height));

            //绘制文本
            graphics.DrawString(Text, Font, new SolidBrush(ThemeColors.PrimaryColor), new Point(4, 4));

            //绘制下拉箭头
            graphics.DrawString("6", new Font("Marlett", 12), new SolidBrush(SystemColors.ControlDark), new Rectangle(Width - 18, 6, 18, 18));

            //graphics.Dispose();
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
            bitmap.Dispose();
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
                e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(ThemeColors.PrimaryColor), e.Bounds, StringAlign.TopCenter);
            }
            else
            {
                //绘制未被选择的项
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                var textColor = ThemeColors.MainText;
                //绘制文本
                e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), Font, new SolidBrush(textColor), e.Bounds, StringAlign.TopCenter);
            }
            e.Graphics.Dispose();
        }
    }
}