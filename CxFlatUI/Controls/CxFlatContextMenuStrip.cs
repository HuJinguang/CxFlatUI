using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;


namespace CxFlatUI
{
    public class CxFlatContextMenuStrip : ContextMenuStrip
    {
        public CxFlatContextMenuStrip()
        {
            Renderer = new CxFlatToolStripRender();

            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            BackColor = Color.White;
        }
    }

    public class CxFlatToolStripRender : ToolStripProfessionalRenderer
    {
        public CxFlatToolStripRender()
        {
            base.RoundedEdges = true;
        }
        
        /// <summary>
        /// 绘制整个背景
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            e.ToolStrip.ForeColor = ThemeColors.MainText;
            if (e.ToolStrip is ToolStripDropDown)
            {
                var g = e.Graphics;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                g.Clear(Color.White);
                var bg = DrawHelper.CreateRoundRect(0.5f, 0.5f, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1, 3);
                g.DrawPath(new Pen(ThemeColors.OneLevelBorder, 1), bg);
                g.FillPath(new SolidBrush(Color.White), bg);
            }
            else
            {
                base.OnRenderToolStripBackground(e);
            }
        }

        /// <summary>
        /// 绘制菜单项的背景
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if(e.ToolStrip is MenuStrip)
            {
                //如果被选中或被按下
                if (e.Item.Selected || e.Item.Pressed)
                {
                    e.Graphics.FillRectangle(new SolidBrush(ThemeColors.FourLevelBorder), 0, 0, e.Item.Size.Width, e.Item.Height);
                }
                else
                {
                    base.OnRenderMenuItemBackground(e);
                }
            }
            else if(e.ToolStrip is ToolStripDropDown)
            {
                if (e.Item.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(ThemeColors.FourLevelBorder), 0, 0, e.Item.Size.Width, e.Item.Height);
                }
            }
            else
            {
                base.OnRenderMenuItemBackground(e);
            }
        }

        /// <summary>
        /// 绘制菜单项的分割线
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(ThemeColors.OneLevelBorder,1.5f), 5, 2.75f, e.Item.Width-5, 2.75f);
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }

        /// <summary>
        /// 绘制菜单项文字
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var itemRect = GetItemRect(e.Item);
            var textRect = new Rectangle(0, itemRect.Y, itemRect.Width, itemRect.Height);
            g.DrawString(
                e.Text,
                new Font("微软雅黑", 11f),
                new SolidBrush(e.Item.Selected ? ThemeColors.PrimaryColor : ThemeColors.RegularText),
                textRect,
                StringAlign.Center);
        }

        /// <summary>
        /// 绘制边框
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            var g = e.Graphics;
            g.DrawRectangle(new Pen(ThemeColors.OneLevelBorder), new Rectangle(e.AffectedBounds.X, e.AffectedBounds.Y, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1));
        }

        /// <summary>
        /// 绘制箭头
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = ThemeColors.PlaceholderText;
            base.OnRenderArrow(e);
        }

        private Rectangle GetItemRect(ToolStripItem item)
        {
            return new Rectangle(0, item.ContentRectangle.Y, item.ContentRectangle.Width + 4, item.ContentRectangle.Height);
        }
    }
}