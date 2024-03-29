﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;
using NHibernate;

namespace Domain.MapperInterfaces
{
  public  class OrderMapperSession : IOrderMapperSession
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public OrderMapperSession(ISession session)
        {
            _session = session;
        }

        public IQueryable<OrderItem> OrderItems => _session.Query<OrderItem>();

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public async Task Commit()
        {
            await _transaction.CommitAsync();
        }

        public async Task Rollback()
        {
            await _transaction.RollbackAsync();
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task Save(OrderItem entity)
        {
            await _session.SaveOrUpdateAsync(entity);
        }

        public async Task Delete(OrderItem entity)
        {
            await _session.DeleteAsync(entity);
        }
    }
}
