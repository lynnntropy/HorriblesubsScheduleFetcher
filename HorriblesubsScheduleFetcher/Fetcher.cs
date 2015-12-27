using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Supremes.Nodes;
using NodaTime;

namespace HorriblesubsScheduleFetcher
{
    public class Fetcher
    {
        private static string SCHEDULE_PAGE_URL = "http://horriblesubs.info/release-schedule/";

        public Document schedulePage;
        public List<Element> dayScheduleTables = new List<Element>();
        public List<ScheduleItem> scheduleItems = new List<ScheduleItem>();

        public void FetchPage()
        {
            using (WebClient webClient = new WebClient())
            {
                string schedulePageHtml = webClient.DownloadString(SCHEDULE_PAGE_URL);
                this.schedulePage = Supremes.Parsers.Parser.Parse(schedulePageHtml, SCHEDULE_PAGE_URL);
            }
        }

        public void FetchTables()
        {
            foreach (var weekdayTable in this.schedulePage.Select("table.schedule-today-table"))
            {
                dayScheduleTables.Add(weekdayTable);
            }

            // remove the 'to be scheduled' table
            dayScheduleTables.RemoveAt(dayScheduleTables.Count - 1);
        }

        public void FetchScheduleItems()
        {
            foreach (var table in dayScheduleTables)
            {
                var items = table.Select("tr.schedule-page-item");

                foreach (var item in items)
                {
                    var id = item.Select("a[href]").Attr("href");
                    var title = item.Select("a[href]").Text;

                    var rawTimeString = item.Select("td.schedule-time").Text;
                    var pstHours = int.Parse(rawTimeString.Split(':')[0]);
                    var pstMinutes = int.Parse(rawTimeString.Split(':')[1]);

                    //var losAngeles = DateTimeZoneProviders.Tzdb["America/Los_Angeles"];
                    //var time = new ZonedDateTime(new LocalDateTime(1, 1, 1, pstHours, pstMinutes), losAngeles, )

                    // I'm too fucking tired right now
                    // to write code that works with timezones.
                }
            }
        }

        public List<ScheduleItem> Fetch()
        {
            return null;
        }
    }
}
