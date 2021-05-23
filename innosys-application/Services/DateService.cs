using System;
using System.Text;

namespace innosys_application.Services
{
    public class DateService : IDateService
    {
        public DateTime CaluclateBusinessDueDate(DateTime startDate, int duration)
        {
            double durationInMinutes = duration * 60;

            DateTime dueDate = startDate;

            while (durationInMinutes >= 0)
            {
                DateTime endOfDayDateTime = dueDate.Date + new TimeSpan(16, 0, 0);

                var differenceInMintues = endOfDayDateTime.Subtract(dueDate).TotalMinutes;

                if (differenceInMintues < durationInMinutes)
                {
                    dueDate = dueDate.AddDays(1);

                    while (dueDate.DayOfWeek == DayOfWeek.Saturday || dueDate.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dueDate = dueDate.AddDays(1);
                    }

                    dueDate = dueDate.Date + new TimeSpan(8, 30, 0);
                }
                else
                {
                    int minutesToHours = Convert.ToInt32(durationInMinutes / 60);

                    dueDate = dueDate.AddHours(minutesToHours);
                }

                durationInMinutes = durationInMinutes - differenceInMintues;
            }

            return dueDate;
        }

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
