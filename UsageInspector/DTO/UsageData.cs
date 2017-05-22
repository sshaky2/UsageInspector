using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsageInspector.DTO
{
    class UsageData
    {
        public long UsageTotalDailyId { get; set; }
        public long SimId { get; set; }
        public DateTime UsageDate { get; set; }
        public long DailyGprsTotal { get; set; }
        public int DailySmsTotal { get; set; }
        public int DailyVoiceTotal { get; set; }
        public DateTime BilingCdrStartDate { get; set; }
        public int EnterpriseId { get; set; }
    }
}
