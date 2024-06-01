using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Shared.Extensions
{
    public static class ProjectTools
    {
        public static async Task<decimal> GetTax(decimal amount)
        {
            await Task.CompletedTask;
            var newAmount = (amount * 9) / 100;
            return Math.Floor(newAmount);
        }
        public static string ConvertToJalaliDate(DateTime date)
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            PersianCalendar pCalender = new PersianCalendar();
            string Jalali = pCalender.GetYear(date).ToString() + "/" +
            pCalender.GetMonth(date) + "/" +
            pCalender.GetDayOfMonth(date);
            //Jalali = Jalali + " " + date.ToLongTimeString();
            return Jalali;
        }
        public static string ConvertToJalaliDateTime(DateTime date)
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            PersianCalendar pCalender = new PersianCalendar();
            string Jalali = pCalender.GetYear(date).ToString() + "/" +
            pCalender.GetMonth(date) + "/" +
            pCalender.GetDayOfMonth(date);
            Jalali = Jalali + " " + date.ToLongTimeString();
            return Jalali;
        }
    }
}
