using System.Collections.Generic;
using System.Data.Entity;
using Models;

namespace Services
{
    public class CalcContext : DbContext
    {
        public CalcContext()
            : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Результаты операций
        /// </summary>
        public DbSet<OperationResult> OperationResults { get; set; }

        /// <summary>
        /// Операции
        /// </summary>
        public DbSet<Operation> Operations { get; set; }

    }
}