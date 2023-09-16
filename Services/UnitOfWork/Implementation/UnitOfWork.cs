using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _dbConnection;
        private IDbTransaction _dbTransaction;
        public UnitOfWork(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void BeginTransaction()
        {
            _dbTransaction = _dbConnection.BeginTransaction();

        }

        public void CommitTransaction()
        {
            _dbTransaction.Commit();
        }

        public void Dispose() 
        {
            if (_dbConnection.State == ConnectionState.Open)
                _dbConnection.Close();

            _dbConnection?.Dispose();
        }
    }
}
