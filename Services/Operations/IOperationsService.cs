using System.Collections.Generic;
using Model;

namespace Services.Operations
{
    public interface IOperationsService
    {
        bool SaveOperation(Operation operation);
        Operation GetOperation(int id);
        List<Operation> GetAllOperations();
        bool DeleteOperation(int id);
    }
}
