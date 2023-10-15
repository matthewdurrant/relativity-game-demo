using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativityDemo
{
    public static class Extensions
    {
        static Random rand = new Random();

        public static TItem Random<TItem>(this List<TItem> items)
        {
            return items[rand.Next(items.Count)];
        }


        public static string PrettyPrintTimeSpan(this TimeSpan timeSpan)
        {
            int years = timeSpan.Days / 365; // Approximate number of years
            int months = (timeSpan.Days % 365) / 30; // Approximate number of months
            int days = timeSpan.Days % 30; // Remaining days

            string prettyString = $"{years} years, {months} months, and {days} days";
            return prettyString;
        }
    }
}
