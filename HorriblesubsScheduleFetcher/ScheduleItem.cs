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
        private string seriesName;
        private string seriesId;

        private NodaTime.ZonedDateTime airTime;

        public ScheduleItem(string seriesName, string seriesId, ZonedDateTime airTime)
        {
            this.seriesName = seriesName;
            this.seriesId = seriesId;
            this.airTime = airTime;
        }
    }
}
