using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.MapperInterfaces
{
    public interface IMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(Book entity);
        Task Delete(Book entity);

        IQueryable<Book> Books { get; }
    }
    public interface IOrderMapperSession
    {
        void BeginTransaction();
        Task Commit();
        Task Rollback();
        void CloseTransaction();
        Task Save(OrderItem entity);
        Task Delete(OrderItem entity);

        IQueryable<OrderItem> OrderItems { get; }
    }
}
