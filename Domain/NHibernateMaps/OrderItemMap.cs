using System;
using System.Collections.Generic;
using System.Text;
using Data.Model;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace Domain.NHibernateMaps
{
  public  class OrderItemMap : ClassMapping<OrderItem>
    {
        public OrderItemMap()
        {
            Id(x => x.id, x =>
            {
                x.Generator(Generators.Guid);
                x.Type(NHibernateUtil.Guid);
                x.Column("Id");
                x.UnsavedValue(Guid.Empty);
            });

            Property(b => b.sku, x =>
            {
                x.Length(50);
                x.Column("sku");
                x.Type(NHibernateUtil.StringClob);
                x.NotNullable(false);
            });

            Table("OrderItem");
        }
    }
}
