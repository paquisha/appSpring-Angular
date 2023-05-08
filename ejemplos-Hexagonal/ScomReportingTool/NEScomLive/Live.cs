using ADScomLive;
using ADScomLive.Entities;

namespace NEScomLive
{
    public class Live
    {
        private readonly LiveDAO _dao;
        public Live(OperationsManagerContext context)
        {
            _dao = new LiveDAO(context);
        }
        public List<AlertView> GetAlertViews()
        {
            return _dao.GetAlertViews();
        }
    }
}