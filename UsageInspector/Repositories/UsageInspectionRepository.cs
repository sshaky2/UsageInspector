using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Features.AttributeFilters;
using Dapper;
using UsageInspector.DTO;
using UsageInspector.Managers;

namespace UsageInspector.Repositories
{
    class UsageInspectionRepository
    {
        private readonly IConnectionManager _connectionManagerFe;
        private readonly IConnectionManager _connectionManagerBe;


        public UsageInspectionRepository([KeyFilter("FE")] IConnectionManager connectionManagerFe, [KeyFilter("BE")] IConnectionManager connectionManagerBe)
        {
            _connectionManagerFe = connectionManagerFe;
            _connectionManagerBe = connectionManagerBe;
        }

        public IEnumerable<UsageData> GetUsageHistory()
        {
            using (var con = _connectionManagerBe.GetOpenConnection())
            {
                const string sql = @"
                    SELECT [UsageTotalsDailyId]
                          ,tutd.[SIMID]
                          ,[UsageDate]
                          ,[DailyGPRSTotal]
                          ,[DailySMSTotal]
                          ,[DailyVoiceTotal]
                          ,[BillingCDRStartDate]
	                      ,tc.EnterpriseID
                    FROM [DEV6_FE].[dbo].[tbl_usage_totals_daily] tutd 
                    join tbl_sims ts on ts.SIMID = tutd.SIMID
                    join tbl_locations tl on tl.LocationID = ts.LocationID
                    join tbl_company tc on tc.EnterpriseID = tl.EnterpriseID
                    where tc.EnterpriseID = 310 and ts.SIMStatus = 'Active'";

                return con.Query<UsageData>(sql);
            }
        }

       
    }
}
