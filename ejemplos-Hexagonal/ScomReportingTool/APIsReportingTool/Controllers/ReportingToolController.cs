using ADReporting;
using ADReporting.Entities;
using ADScomDataWarehouse.Entities;
using ADScomLive.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NEReportingTool;
using NEScomDataWarehouse;
using NEScomLive;
using System.Collections;

namespace APIsReportingTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingToolController : ControllerBase
    {
        private readonly ReportingTool _reportingTool;
        private readonly DataWarehouse _dataWarehouse;
        private readonly Live _live;
        public ReportingToolController(ReportingToolContext context, OperationsManagerDwContext dwContext, OperationsManagerContext liveContext) 
        {
            _reportingTool = new ReportingTool(context);
            _dataWarehouse = new DataWarehouse(dwContext);
            _live = new Live(liveContext);
        }
        // Métodos APIs
        [HttpGet]
        [Route("GetCustomers")]
        public IEnumerable<Customer> GetCustomers() => _reportingTool.GetCustomers();
        [HttpGet]
        [Route("GetAlerts")]
        public IEnumerable<ADReporting.Entities.Alert> GetAlerts() => _reportingTool.GetAlerts();
        [HttpGet]
        [Route("ManagedEntities")]
        public IEnumerable<VManagedEntity> GetManagedEntities() => _dataWarehouse.GetAllVManagedEntities();
        [HttpGet]
        [Route("RealTimeAlerts")]
        public IEnumerable<AlertView> GetRealTimeAlerts() => _live.GetAlertViews();
    }
}
