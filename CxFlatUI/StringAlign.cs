using System.Drawing;

namespace CxFlatUI
{
    /// <summary>
    /// 文本位置
    /// </summary>
    public static class StringAlign
    {
        /// <summary>
        /// 左上
        /// </summary>
        public static StringFormat TopLeft { get => new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near }; }
        /// <summary>
        /// 中上
        /// </summary>
        public static StringFormat TopCenter { get => new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near }; }
        /// <summary>
        /// 右上
        /// </summary>
        public static StringFormat TopRight { get => new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Near }; }
        /// <summary>
        /// 左中
        /// </summary>
        public static StringFormat Left { get => new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center }; }
        /// <summary>
        /// 正中
        /// </summary>
        public static StringFormat Center { get => new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }; }
        /// <summary>
        /// 右中
        /// </summary>
        public static StringFormat Right { get => new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center }; }
        /// <summary>
        /// 左下
        /// </summary>
        public static StringFormat BottomLeft { get => new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Far }; }
        /// <summary>
        /// 中下
        /// </summary>
        public static StringFormat BottomCenter { get => new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far }; }
        /// <summary>
        /// 右下
        /// </summary>
        public static StringFormat BottomRight { get => new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far }; }
    }
}