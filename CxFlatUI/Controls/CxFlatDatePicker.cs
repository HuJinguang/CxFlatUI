using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace CxFlatUI.Controls
{
    public partial class CxFlatDatePicker : Control
    {
        public new Color BackColor { get { return ThemeColors.PrimaryColor; } set { } }

        private RectangleF TopDateRect;//顶部日期区域
        private RectangleF WeekRect;//显示星期区域

        private List<List<DateRect>> DateRectangles;//显示日期区域

        private RectangleF PreviousMonthRect;//上一月区域
        private RectangleF NextMonthRect;//下一月区域
        private RectangleF PreviousYearRect;//上一年区域
        private RectangleF NextYearRect;//下一年区域

        private DateTime CurrentDate;
        public DateTime Date { get { return CurrentDate; } set { CurrentDate = value; Invalidate(); } }
        

        private int DateRectDefaultSize;
        private int HoverX;
        private int HoverY;
        private int SelectedX;
        private int SelectedY;
        
        private bool previousYearHovered;
        private bool previousMonthHovered;
        private bool nextMonthHovered;
        private bool nextYearHovered;

        #region 事件
        public delegate void DateChanged(DateTime newDateTime);
        public event DateChanged onDateChanged;
        #endregion

        #region 重写事件
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (DateRectangles[i][j].Drawn)
                    {
                        if (DateRectangles[i][j].Rect.Contains(e.Location))
                        {
                            if (HoverX != i || HoverY != j)
                            {
                                HoverX = i;
                                previousYearHovered = false;
                                nextYearHovered = false;
                                HoverY = j;
                                Invalidate();
                            }
                            return;
                        }
                    }
                }
            }

            if (PreviousYearRect.Contains(e.Location))
            {
                previousYearHovered = true;
                HoverX = -1;
                Invalidate();
                return;
            }
            if (PreviousMonthRect.Contains(e.Location))
            {
                previousMonthHovered = true;
                HoverX = -1;
                Invalidate();
                return;
            }
            if (NextMonthRect.Contains(e.Location))
            {
                nextMonthHovered = true;
                HoverX = -1;
                Invalidate();
                return;
            }
            if (NextYearRect.Contains(e.Location))
            {
                nextYearHovered = true;
                HoverX = -1;
                Invalidate();
                return;
            }
            if (HoverX >= 0 || previousYearHovered || previousMonthHovered || nextMonthHovered || nextYearHovered)
            {
                HoverX = -1;
                previousYearHovered = false;
                previousMonthHovered = false;
                nextMonthHovered = false;
                nextYearHovered = false;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (HoverX >= 0)
            {
                SelectedX = HoverX;
                SelectedY = HoverY;
                CurrentDate = DateRectangles[SelectedX][SelectedY].Date;
                Invalidate();
                if (onDateChanged != null)
                {
                    onDateChanged(CurrentDate);
                }
                return;
            }

            if (PreviousYearRect.Contains(e.Location))
                CurrentDate = FirstDayOfMonth(CurrentDate.AddYears(-1));
            if (PreviousMonthRect.Contains(e.Location))
                CurrentDate = FirstDayOfMonth(CurrentDate.AddMonths(-1));
            if (NextMonthRect.Contains(e.Location))
                CurrentDate = FirstDayOfMonth(CurrentDate.AddMonths(1));
            if (NextYearRect.Contains(e.Location))
                CurrentDate = FirstDayOfMonth(CurrentDate.AddYears(1));
            CalculateRectangles();
            Invalidate();
            if (onDateChanged != null)
            {
                onDateChanged(CurrentDate);
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            HoverX = -1;
            HoverY = -1;
            previousYearHovered = false;
            previousMonthHovered = false;
            nextMonthHovered = false;
            nextYearHovered = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        #endregion

        private void CalculateRectangles()
        {
            //日期位置List
            DateRectangles = new List<List<DateRect>>();
            for (int i = 0; i < 7; i++)
            {
                DateRectangles.Add(new List<DateRect>());
                for (int j = 0; j < 7; j++)
                {
                    DateRectangles[i].Add(new DateRect(new RectangleF(10 + (j * (Width-20)/7), WeekRect.Y+WeekRect.Height + (i * DateRectDefaultSize), DateRectDefaultSize, DateRectDefaultSize)));
                }
            }
            DateTime FirstDay = FirstDayOfMonth(CurrentDate);
            var temp = 0;
            for(int i = FirstDay.DayOfWeek== DayOfWeek.Sunday?6:(int)FirstDay.DayOfWeek-1 ; i >0; i--,temp++)
            {
                DateRectangles[temp/7][temp%7].Drawn = false;
                DateRectangles[temp/7][temp%7].Date = FirstDay.AddDays(0-i);
            }
            for (DateTime date = FirstDay; date <= LastDayOfMonth(CurrentDate); date = date.AddDays(1),temp++)
            {
                if (date.DayOfYear == CurrentDate.DayOfYear && date.Year == CurrentDate.Year)
                {
                    SelectedX = temp/7;
                    SelectedY = temp%7;
                }
                DateRectangles[temp/7][temp%7].Drawn = true;
                DateRectangles[temp/7][temp%7].Date = date;
            }
            DateTime LastDay = LastDayOfMonth(CurrentDate);
            for(int i = 0; temp < 42; i++,temp++)
            {
                DateRectangles[temp / 7][temp % 7].Drawn = false;
                DateRectangles[temp / 7][temp % 7].Date = LastDay.AddDays(i + 1);
            }
        }


        protected override void OnResize(EventArgs e)
        {
            Width = 250;
            Height = 270;
        }

        public CxFlatDatePicker()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Width = 250;
            Height = 260;

            DateRectDefaultSize = (Width - 20) / 7;
            TopDateRect = new RectangleF(20, 5, Width - 40, DateRectDefaultSize);
            WeekRect = new RectangleF(0, TopDateRect.Y + TopDateRect.Height, DateRectDefaultSize, DateRectDefaultSize);

            PreviousYearRect = new RectangleF(10, TopDateRect.Y, 20, DateRectDefaultSize);
            PreviousMonthRect = new RectangleF(35, TopDateRect.Y+1, 20, DateRectDefaultSize);
            NextMonthRect = new RectangleF(Width -55, TopDateRect.Y+1, 20, DateRectDefaultSize);
            NextYearRect = new RectangleF(Width - 30 , TopDateRect.Y, 20, DateRectDefaultSize);

            CurrentDate = DateTime.Now;

            HoverX = -1;
            HoverY = -1;
            CalculateRectangles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var graphics = e.Graphics;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            graphics.Clear(Parent.BackColor);

            //绘制背景边框
            var bg = DrawHelper.CreateRoundRect(1f, 1f, Width - 2, Height -2, 3);
            graphics.FillPath(new SolidBrush(Color.White), bg);
            graphics.DrawPath(new Pen(ThemeColors.OneLevelBorder), bg);

            //绘制年月
            graphics.DrawString(string.Format("{0}年{1,2}月",CurrentDate.Year,CurrentDate.Month), new Font("微软雅黑",12f), new SolidBrush(ThemeColors.MainText), TopDateRect, StringAlign.Center);
            //绘制年月选择区域
            graphics.DrawString("7", new Font("webdings", 12f), new SolidBrush(previousYearHovered ? ThemeColors.PrimaryColor : ThemeColors.PlaceholderText), PreviousYearRect, StringAlign.Center);
            graphics.DrawString("3", new Font("webdings", 12f), new SolidBrush(previousMonthHovered ? ThemeColors.PrimaryColor : ThemeColors.PlaceholderText), PreviousMonthRect, StringAlign.Center);
            graphics.DrawString("4", new Font("webdings", 12f), new SolidBrush(nextMonthHovered ? ThemeColors.PrimaryColor : ThemeColors.PlaceholderText), NextMonthRect,StringAlign.Center);
            graphics.DrawString("8", new Font("webdings", 12f), new SolidBrush(nextYearHovered ? ThemeColors.PrimaryColor : ThemeColors.PlaceholderText), NextYearRect, StringAlign.Center);

            //绘制星期
            string s = "一二三四五六日";
            for (int i = 0; i < 7; i++)
            {
                graphics.DrawString(s[i].ToString(), new Font("微软雅黑", 10f), new SolidBrush(ThemeColors.RegularText), new RectangleF(10+i * (Width-20) / 7, WeekRect.Y, WeekRect.Width, WeekRect.Height), StringAlign.Center);
            }

            //绘制分割线
            graphics.DrawLine(new Pen(ThemeColors.TwoLevelBorder, 0.5f), 10, WeekRect.Y + WeekRect.Height, Width - 10, WeekRect.Y + WeekRect.Height);          

            //绘制日期
            DateTime FirstDay = FirstDayOfMonth(CurrentDate);
            for(int i = 0; i < 42; i++)
            {
                var tempDate = DateRectangles[i / 7][i % 7];
                var brush = new SolidBrush(ThemeColors.MainText);
                //突出显示鼠标所指
                if (HoverX == i / 7 && HoverY == i % 7)
                {
                    var rect1 = tempDate.Rect;
                    var bg1 = DrawHelper.CreateRoundRect(rect1.X + 2, rect1.Y + 2, rect1.Width - 4, rect1.Width - 4, 3);
                    graphics.FillPath(new SolidBrush(ThemeColors.ThreeLevelBorder), bg1);
                    //graphics.FillRectangle(new SolidBrush(ThemeColors.ThreeLevelBorder), new RectangleF(rect1.X + 3, rect1.Y + 3, rect1.Width - 6, rect1.Width - 6));
                }
                //突出显示今天
                if (tempDate.Date == DateTime.Today)
                {
                    brush = new SolidBrush(ThemeColors.DarkPrimary);
                }
                //突出显示所选日期
                if (tempDate.Date == Date)
                {
                    var rect1 = tempDate.Rect;
                    var bg1 = DrawHelper.CreateRoundRect(rect1.X + 2, rect1.Y + 2, rect1.Width - 4, rect1.Width - 4, 3);
                    graphics.FillPath(new SolidBrush(ThemeColors.PrimaryColor), bg1);

                    //graphics.FillRectangle(new SolidBrush(ThemeColors.PrimaryColor), new RectangleF(rect1.X+3,rect1.Y+3,rect1.Width-6,rect1.Width-6));
                    brush = new SolidBrush(Color.White);
                }
                graphics.DrawString(DateRectangles[i/7][i%7].Date.Day.ToString(), Font, DateRectangles[i/7][i%7].Drawn?brush: new SolidBrush(ThemeColors.SecondaryText), DateRectangles[i/7][i%7].Rect, StringAlign.Center);
            }
        }

        public DateTime FirstDayOfMonth(DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }

        public DateTime LastDayOfMonth(DateTime value)
        {
            return new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month));
        }

        private class DateRect
        {
            public RectangleF Rect;
            public bool Drawn = false;
            public DateTime Date;

            public DateRect(RectangleF pRect)
            {
                Rect = pRect;
            }
        }
    }
}
