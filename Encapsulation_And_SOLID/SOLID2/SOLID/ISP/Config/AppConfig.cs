using System.IO;
using System.Runtime.Serialization;

namespace SOLID.ISP.Config
{
    public class Report
    {
        private readonly IReportsConfig _reportsConfig;

        public Report(IReportsConfig reportsConfig)
        {
            _reportsConfig = reportsConfig;
        }
        public string Generate()
        {
            return $"Income:{_reportsConfig.Income}" + "\n" +
                   $"Outcome:{_reportsConfig.Outcome}" + "\n" +
                   $"Total Revenue:{_reportsConfig.TotalRevenue}";
        }
    }

    public interface IAppConfig
    {
        string ServerId { get; set; }
        string ServerIP { get; set; }
        string ServerPort { get; set; }
        int LoggingSwitch { get; set; }
        int AppSkinId { get; set; }        
    }

    public interface IReportsConfig
    {
        decimal Income { get; set; }
        decimal Outcome { get; set; }
        decimal TotalRevenue { get; set; }
    }

    [DataContract(Namespace = "")]
    public class AppConfig : IAppConfig, IReportsConfig
    {
        private AppConfig()
        {            
        }

        [DataMember(IsRequired = true)]
        public string ServerId { get; set; }

        [DataMember(IsRequired = true)]
        public string ServerIP { get; set; }

        [DataMember(IsRequired = true)]
        public string ServerPort { get; set; }

        [DataMember(IsRequired = true)]
        public int LoggingSwitch { get; set; }

        [DataMember(IsRequired = true)]
        public int AppSkinId { get; set; }

        [DataMember(IsRequired = true)]
        public decimal Income { get; set; }

        [DataMember(IsRequired = true)]
        public decimal Outcome { get; set; }

        [DataMember(IsRequired = true)]
        public decimal TotalRevenue { get; set; }

        public static AppConfig Config { get; private set; }

        public static void Initialize()
        {
            using (Stream s = File.OpenRead("config.xml"))
            {
                Config = (AppConfig) new DataContractSerializer(typeof(AppConfig)).ReadObject(s);
            }            
        }
    }
}
