using NUnit.Framework;
using SOLID.ISP.Config;

namespace SOLID.UnitTests
{
    [TestFixture]
    public class ReportTests
    {
        [Test]
        public void Generate_ValidInput_GeneratesReport()
        {
            IReportsConfig appConfig = new TestableReportsAppConfig()
            {
                Income = 10,
                Outcome = 100,              
                TotalRevenue = 1000
            };

            Report sut = new Report(appConfig);
            string report = sut.Generate();

            Assert.AreEqual(
                $"Income:10" + "\n" +
                $"Outcome:100" + "\n" +
                $"Total Revenue:1000",
                report);
        }
    }

    public class TestableReportsAppConfig : IReportsConfig
    {
        public decimal Income { get; set; }
        public decimal Outcome { get; set; }
        public decimal TotalRevenue { get; set; }
    }


    public class TestableAppConfig : IAppConfig
    {
        public string ServerId { get; set; }
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
        public int LoggingSwitch { get; set; }
        public int AppSkinId { get; set; }
        public decimal Income { get; set; }
        public decimal Outcome { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
