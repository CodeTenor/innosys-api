using System;
using System.Text;

namespace innosys_application.Services
{
    public class DateService : IDateService
    {
        public DateTime StringToDateTime(string date)
        {
            string formatString = "yyyyMMddHHmmss";

            StringBuilder sb = new StringBuilder(date.Trim('\''));

            sb.Remove(8, 1);

            string dateString = sb.ToString();

            return DateTime.ParseExact($"{dateString}00", formatString, null);
        }
    }
}
