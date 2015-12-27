using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
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
