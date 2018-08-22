using System.Drawing;

namespace CxFlatUI
{
    public static class ThemeColors
    {
        /// <summary>
        /// 主色
        /// </summary>
        public static Color PrimaryColor = ColorTranslator.FromHtml("#409eff");
        public static Color LightPrimary = ColorTranslator.FromHtml("#5cadff");
        public static Color DarkPrimary = ColorTranslator.FromHtml("#2b85e4");

        #region 辅助色
        /// <summary>
        /// 成功
        /// </summary>
        public static Color Success = ColorTranslator.FromHtml("#67c23a");
        /// <summary>
        /// 警告
        /// </summary>
        public static Color Warning = ColorTranslator.FromHtml("#e6a23c");
        /// <summary>
        /// 危险
        /// </summary>
        public static Color Danger = ColorTranslator.FromHtml("#f56c6c");
        /// <summary>
        /// 信息
        /// </summary>
        public static Color Info = ColorTranslator.FromHtml("#909399");
        #endregion

        #region 文字颜色
        /// <summary>
        /// 主要文字
        /// </summary>
        public static Color MainText = ColorTranslator.FromHtml("#303133");
        /// <summary>
        /// 常规文字
        /// </summary>
        public static Color RegularText = ColorTranslator.FromHtml("#606266");
        /// <summary>
        /// 次要文字
        /// </summary>
        public static Color SecondaryText = ColorTranslator.FromHtml("#909399");
        /// <summary>
        /// 占位文字
        /// </summary>
        public static Color PlaceholderText = ColorTranslator.FromHtml("#c0c4cc");
        #endregion

        #region 边框颜色
        /// <summary>
        /// 一级边框
        /// </summary>
        public static Color OneLevelBorder = ColorTranslator.FromHtml("#dcdfe6");
        /// <summary>
        /// 二级边框
        /// </summary>
        public static Color TwoLevelBorder = ColorTranslator.FromHtml("#e4e7ed");
        /// <summary>
        /// 三级边框
        /// </summary>
        public static Color ThreeLevelBorder = ColorTranslator.FromHtml("#ebeef5");
        /// <summary>
        /// 四级边框
        /// </summary>
        public static Color FourLevelBorder = ColorTranslator.FromHtml("#f2f6fc");
        #endregion
    }
}