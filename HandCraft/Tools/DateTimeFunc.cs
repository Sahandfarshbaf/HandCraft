using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HandCraft.Tools
{
    class DateTimeFunc
    {


        public static string MiladiToShamsi(DateTime miladiTarikh)
        {
            PersianCalendar pc = new System.Globalization.PersianCalendar();
            string shamsiTarikh = string.Format("{0}/{1}/{2}",
                pc.GetYear(miladiTarikh),
               Convert.ToString(pc.GetMonth(miladiTarikh)).PadLeft(2, '0'),
                Convert.ToString(pc.GetDayOfMonth(miladiTarikh)).PadLeft(2, '0'));


            return shamsiTarikh;

        }

        public static string ShamsiToMiladi(string shamsiTarikh)
        {

            PersianCalendar p = new PersianCalendar();
            var a = shamsiTarikh.Split("/");
            var b = p.ToDateTime(short.Parse(a[0]), short.Parse(a[1]), short.Parse(a[2]), 0, 0, 0, 0)
                .ToString("MM/dd/yyyy");
            return b;

        }

        public static string TimeTickToMiladi(long ticks)
        {

            DateTime myDate = new DateTime(ticks);

            return myDate.ToString("MM/dd/yyyy");

        }

        public static string TimeTickToShamsi(long ticks)
        {

            DateTime myDate = new DateTime(ticks);


            return MiladiToShamsi(myDate);

        }

        public static long ShamsiToTimeTick(string shamsiTarikh)
        {
            var a = shamsiTarikh.Split("/");
            PersianCalendar pc = new PersianCalendar();
            DateTime thisDate = pc.ToDateTime(short.Parse(a[0]), short.Parse(a[1]), short.Parse(a[2]), 0, 0, 0, 0);
            return thisDate.Ticks;

        }

        public static long MiladiToTimeTick(DateTime miladiTarikh)
        {

            return miladiTarikh.Ticks;

        }

        public static string AddDayToShamsi(int day, string shamsiTarikh)
        {

            PersianCalendar p = new PersianCalendar();
            var a = shamsiTarikh.Split("/");
            var b = p.ToDateTime(short.Parse(a[0]), short.Parse(a[1]), short.Parse(a[2]), 0, 0, 0, 0);
            b = b.AddDays(day);
            return MiladiToShamsi(b);

        }

        public static long TwoShamsiDateDiffAsDay(string shamsiBegin, string shamsiEnd)

        {
            PersianCalendar p1 = new PersianCalendar();
            var a1 = shamsiBegin.Split("/");
            var b1 = p1.ToDateTime(short.Parse(a1[0]), short.Parse(a1[1]), short.Parse(a1[2]), 0, 0, 0, 0);

            PersianCalendar p2 = new PersianCalendar();
            var a2 = shamsiEnd.Split("/");
            var b2 = p2.ToDateTime(short.Parse(a2[0]), short.Parse(a2[1]), short.Parse(a2[2]), 0, 0, 0, 0);

            TimeSpan span = b2 - b1;
            return span.Days;

        }




    }
}
