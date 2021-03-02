using Model;
using System.Collections.Generic;

namespace Services.Operations
{
    public class OperationsService : IOperationsService
    {
        private DbService db = DbService.GetInstance();

        public OperationsService(){}

        public bool DeleteOperation(int id)
        {
            return db.DeleteOperation(id);
        }

        public List<Operation> GetAllOperations()
        {
            return db.GetAllOperations();
        }

        public Operation GetOperation(int id)
        {
            return db.GetOperation(id);
        }

        public bool SaveOperation(Operation operation)
        {
            return db.SaveOperation(operation);
        }
    }
}
