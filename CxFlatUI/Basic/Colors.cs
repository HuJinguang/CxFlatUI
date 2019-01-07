using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CxFlatUI.Basic
{
    public class Colors
    {
        #region Main Color

        /// <summary>
        /// 主题颜色
        /// </summary>
        public static Color Main { get; set; } = ColorTranslator.FromHtml("#409EFF");

        #endregion

        #region Secondary Color

        /// <summary>
        /// 成功
        /// </summary>
        public static Color Success { get; set; } = ColorTranslator.FromHtml("#67C23A");
        /// <summary>
        /// 警告
        /// </summary>
        public static Color Warning { get; set; } = ColorTranslator.FromHtml("#E6A23C");
        /// <summary>
        /// 危险
        /// </summary>
        public static Color Danger { get; set; } = ColorTranslator.FromHtml("#F56C6C");
        /// <summary>
        /// 信息
        /// </summary>
        public static Color Info { get; set; } = ColorTranslator.FromHtml("#909399");

        #endregion

        #region Neutral Color
        /// <summary>
        /// 主要文字
        /// </summary>
        public static Color PrimaryText { get; set; } = ColorTranslator.FromHtml("#303133");
        /// <summary>
        /// 常规文字
        /// </summary>
        public static Color RegularText { get; set; } = ColorTranslator.FromHtml("#606266");
        /// <summary>
        /// 次要文字
        /// </summary>
        public static Color SecondaryText { get; set; } = ColorTranslator.FromHtml("#909399");
        /// <summary>
        /// 占位文字
        /// </summary>
        public static Color PlaceholderText { get; set; } = ColorTranslator.FromHtml("#C0C4CC");
        /// <summary>
        /// 一级边框
        /// </summary>
        public static Color BaseBorder { get; set; } = ColorTranslator.FromHtml("#DCDFE6");
        /// <summary>
        /// 二级边框
        /// </summary>
        public static Color LightBorder { get; set; } = ColorTranslator.FromHtml("#E4E7ED");
        /// <summary>
        /// 三级边框
        /// </summary>
        public static Color LighterBorder { get; set; } = ColorTranslator.FromHtml("#EBEEF5");
        /// <summary>
        /// 四级边框
        /// </summary>
        public static Color ExtraLightBorder { get; set; } = ColorTranslator.FromHtml("#F2F6FC");

        #endregion


        public static Color GetColorByButtonType(ButtonType type)
        {
            Color color = Color.White;
            switch (type)
            {
                case ButtonType.Default:
                    color = Color.White;
                    break;
                case ButtonType.Primary:
                    color = Main;
                    break;
                case ButtonType.Success:
                    color = Success;
                    break;
                case ButtonType.Info:
                    color = Info;
                    break;
                case ButtonType.Waring:
                    color = Warning;
                    break;
                case ButtonType.Danger:
                    color = Danger;
                    break;
            }
            return color;
        }
    }
}
