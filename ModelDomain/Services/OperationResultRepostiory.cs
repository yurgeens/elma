using Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Services
{
    public class OperationResultRepostiory  : IOperationResultRepostiory
    {
        //public Operation
        public OperationResult Create()
        {
            using (var db = new CalcContext())
            {
                return db.OperationResults.Create();
            }
        }

        public bool Delete(int Id)
        {
            var item = Load(Id);
            if (item == null)
                return false;
            using (var db = new CalcContext())
            {
                db.OperationResults.Remove(item);
                db.SaveChanges();
            }
            return true;
        }

        public OperationResult Load(int Id)
        {
            using (var db = new CalcContext())
            {
                return db.OperationResults.FirstOrDefault(o => o.Id == Id);
            }
        }

        public void Update(OperationResult operResult)
        {
            using (var db = new CalcContext())
            {
                db.Entry<OperationResult>(operResult).State =
                    operResult.Id == 0 ? EntityState.Added : EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IEnumerable<OperationResult> GetAll()
        {
            var operations = new List<OperationResult>();

            using (var db = new CalcContext())
            {
                operations = db.OperationResults
                    .Include("Operation")
                    .AsNoTracking() // не следить за изменениями
                    .ToList();

                // все данные вытаскиваем и затем на клиенте фильтруеем
                //IEnumerable<OperationResult> ops = db.OperationResults;
                //var result = ops.Where(o => o.Id > 3);

                // данные фильтрует БД
                //IQueryable<OperationResult> qops = db.OperationResults;
                //var qresult = qops.Where(o => o.Id > 3);

            }

            return operations;
        }

        public Operation FindOperByName(string name)
        {
            var operation = new Operation();
            using (var db = new CalcContext())
            {
                operation = db.Operations.AsNoTracking().FirstOrDefault(o => o.Name == name);
            }
            return operation;
        }
    }
}