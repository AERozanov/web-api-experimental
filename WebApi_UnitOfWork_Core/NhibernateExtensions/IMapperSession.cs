using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_UnitOfWork_Core.Models;

namespace WebApi_UnitOfWork_Core.NhibernateExtensions
{
    //public interface IMapperSession
    //{
    //    void BeginTransaction();
    //    Task Commit();
    //    Task Rollback();
    //    void CloseTransaction();
    //    Task Save(Book entity);
    //    Task Delete(Book entity);

    //    IQueryable<Book> Books { get; }
    //}
    //public class NHibernateMapperSession : IMapperSession
    //{
    //    private readonly ISession _session;
    //    private ITransaction _transaction;

    //    public NHibernateMapperSession(ISession session)
    //    {
    //        _session = session;
    //    }

    //    public IQueryable<Book> Books => _session.Query<Book>();

    //    public void BeginTransaction()
    //    {
    //        _transaction = _session.BeginTransaction();
    //    }

    //    public async Task Commit()
    //    {
    //        await _transaction.CommitAsync();
    //    }

    //    public async Task Rollback()
    //    {
    //        await _transaction.RollbackAsync();
    //    }

    //    public void CloseTransaction()
    //    {
    //        if (_transaction != null)
    //        {
    //            _transaction.Dispose();
    //            _transaction = null;
    //        }
    //    }

    //    public async Task Save(Book entity)
    //    {
    //        await _session.SaveOrUpdateAsync(entity);
    //    }

    //    public async Task Delete(Book entity)
    //    {
    //        await _session.DeleteAsync(entity);
    //    }
    //}
}
