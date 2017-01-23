using Web.Models;

namespace Web.Services
{
    /// <summary>
    /// Хранилище операций, которое базируется на общем хранилище
    /// </summary>
    public interface IOperationRepostiory : IEntityRepostiory<Operation>
    {

    }
}