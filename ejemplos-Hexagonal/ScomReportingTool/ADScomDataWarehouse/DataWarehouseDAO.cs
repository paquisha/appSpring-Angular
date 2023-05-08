using ADScomDataWarehouse.Entities;

namespace ADScomDataWarehouse
{
    public class DataWarehouseDAO
    {
        private readonly OperationsManagerDwContext _context;
        public DataWarehouseDAO(OperationsManagerDwContext context)
        {
            _context = context;
        }
        public List<VManagedEntity> GetAllVManagedEntities()
        {
            var db = _context;

            return db.VManagedEntities.Take(5).ToList();
        }
    }
}