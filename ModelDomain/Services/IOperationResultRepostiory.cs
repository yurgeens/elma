using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOperationResultRepostiory : IEntityRepostiory<OperationResult>
    {
        Operation FindOperByName(string name);
        /// <summary>
        /// Создать результат операции
        /// </summary>
        /// <returns></returns>
       /* OperationResult Create();
        OperationResult Load(int Id);
        bool Delete(int Id);
        void Update(OperationResult operResult);

        IEnumerable<OperationResult> GetAll();
        */
    }
}