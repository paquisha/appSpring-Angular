using ADReporting;
using ADReporting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEReportingTool
{
    public class ReportingTool
    {
        private readonly ReportingToolDAO _dao;
        public ReportingTool(ReportingToolContext context)
        {
            _dao = new ReportingToolDAO(context);
        }
        public List<Customer> GetCustomers() 
        {
            return _dao.GetAllCustomers(); 
        }
        public List<Alert> GetAlerts()
        {
            return _dao.GetAllAlerts();
        }
    }
}
