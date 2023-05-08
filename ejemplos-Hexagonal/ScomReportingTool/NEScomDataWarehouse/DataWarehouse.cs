using ADScomDataWarehouse;
using ADScomDataWarehouse.Entities;

namespace NEScomDataWarehouse
{
    public class DataWarehouse
    {
        private readonly DataWarehouseDAO _dao;
        public DataWarehouse(OperationsManagerDwContext context)
        {
            _dao = new DataWarehouseDAO(context);
        }
        public List<VManagedEntity> GetAllVManagedEntities()
        {
            return _dao.GetAllVManagedEntities();
        }
    }
}