using ADScomLive.Entities;

namespace ADScomLive
{
    public class LiveDAO
    {
        private readonly OperationsManagerContext _context;
        public LiveDAO(OperationsManagerContext context)
        {
            _context = context;
        }
        public List<AlertView> GetAlertViews()
        {
            var db = _context;

            return db.AlertViews.Where(x=>x.TimeRaised>(DateTime.Now.AddHours(-24))).Take(5).ToList();
        }
    }
}