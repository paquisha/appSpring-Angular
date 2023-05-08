using ADReporting.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADReporting
{
    public class ReportingToolDAO
    {
        private readonly ReportingToolContext _context;
        public ReportingToolDAO(ReportingToolContext context) 
        {
            _context = context;
        }
        public List<Customer> GetAllCustomers()
        {
            var db = _context;
            return db.Customer.ToList();
        }
        public List<Alert> GetAllAlerts()
        {
            var db = _context;
            return db.Alerts.ToList();
        }

    }
}
