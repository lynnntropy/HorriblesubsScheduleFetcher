using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DownloaderTest()
        {
            var fetcher = new HorriblesubsScheduleFetcher.Fetcher();
            fetcher.FetchPage();

            Assert.IsNotNull(fetcher.schedulePage);
            Assert.AreNotEqual(fetcher.schedulePage.ToString().Trim(), "");
        }

        [TestMethod]
        public void TablesTest()
        {
            var fetcher = new HorriblesubsScheduleFetcher.Fetcher();
            fetcher.FetchPage();
            fetcher.FetchTables();

            Assert.IsTrue(fetcher.dayScheduleTables.Count == 7);

            var pass = true;
            foreach (var dayScheduleTable in fetcher.dayScheduleTables)
            {
                if (dayScheduleTable == null || dayScheduleTable.Text == null || dayScheduleTable.Text.Trim() == "")
                {
                    pass = false;
                    break;
                }
            }

            Assert.IsTrue(pass);
        }

        [TestMethod]
        public void ListItemsTest()
        {
            var fetcher = new HorriblesubsScheduleFetcher.Fetcher();
            fetcher.FetchPage();
            fetcher.FetchTables();
            fetcher.FetchScheduleItems();

            Assert.IsTrue(fetcher.scheduleItems != null);
            Assert.IsTrue(fetcher.scheduleItems.Count > 0);

            foreach (var scheduleItem in fetcher.scheduleItems)
            {
                Assert.IsTrue(scheduleItem.seriesName.Trim() != "");
                Assert.IsTrue(scheduleItem.seriesId.Trim() != "");
                Assert.IsNotNull(scheduleItem.airTime);
                Assert.IsNotNull(scheduleItem.weekday);

                Console.WriteLine(scheduleItem.ToString());
            }
        }

        [TestMethod]
        public void FetcherTest()
        {
            var fetcher = new HorriblesubsScheduleFetcher.Fetcher();
            var items = fetcher.Fetch();

            Assert.IsTrue(items != null);
            Assert.IsTrue(items.Count > 0);

            foreach (var scheduleItem in items)
            {
                Assert.IsTrue(scheduleItem.seriesName.Trim() != "");
                Assert.IsTrue(scheduleItem.seriesId.Trim() != "");
                Assert.IsNotNull(scheduleItem.airTime);
                Assert.IsNotNull(scheduleItem.weekday);

                Console.WriteLine(scheduleItem.ToString());
            }
        }
    }
}
