using ExamADO.NET.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ExamADO.NET.Models
{
    public abstract class DbDataAccess<T> : IDisposable
    {
        protected readonly DbProviderFactory factory;
        protected readonly DbConnection connection;

        public DbDataAccess()
        {
            factory = DbProviderFactories.GetFactory("ConnectedProvider");
            connection = factory.CreateConnection();
            connection.ConnectionString = ConfigurationService.Configuration["DataAccessConnectionString"];
            connection.Open();
        }
        public abstract void Insert(T entity);
        public abstract void Update(T entity);
        public abstract void Delete(T entity);
        public abstract ICollection<T> Select(T entity);

        public void ExecuteTransaction(params DbCommand[] commands)
        {
            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    foreach (var command in commands)
                    {
                        command.Transaction = transaction;
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                catch (DbException)
                {
                    transaction.Rollback();
                }
            }
        }
        public void Dispose()
        {
            connection.Close();
        }
    }
}
