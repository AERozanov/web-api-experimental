using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_UnitOfWork_Core.Models
{
    //public class Book
    //{
    //    public virtual Guid Id { get; set; }
    //    public virtual string Title { get; set; }
    //}
    //public class BookMap : ClassMapping<Book>
    //{
    //    public BookMap()
    //    {
    //        Id(x => x.Id, x =>
    //        {
    //            x.Generator(Generators.Guid);
    //            x.Type(NHibernateUtil.Guid);
    //            x.Column("Id");
    //            x.UnsavedValue(Guid.Empty);
    //        });

    //        Property(b => b.Title, x =>
    //        {
    //            x.Length(50);
    //            x.Type(NHibernateUtil.StringClob);
    //            x.NotNullable(true);
    //        });

    //        Table("Books");
    //    }
    //}
}
