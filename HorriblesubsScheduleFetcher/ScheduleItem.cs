using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NodaTime;

namespace HorriblesubsScheduleFetcher
{
    public class ScheduleItem
    {
        public enum Weekday
        {
            Monday = 0,
            Tuesday = 1,
            Wednesday = 2,
            Thursday = 3,
            Friday = 4,
            Saturday = 5,
            Sunday = 6
        }

        public string seriesName;
        public string seriesId;
        public Weekday weekday;

        public NodaTime.ZonedDateTime airTime;

        public ScheduleItem(string seriesName, string seriesId, Weekday weekday, ZonedDateTime airTime)
        {
            this.seriesName = seriesName;
            this.seriesId = seriesId;
            this.weekday = weekday;
            this.airTime = airTime;
        }

        public new string ToString()
        {
            return string.Format("{4} | {0:00}:{1:00} | {2} | {3}", this.airTime.Hour, this.airTime.Minute, this.seriesId, this.seriesName, this.weekday);
        }
    }
}
