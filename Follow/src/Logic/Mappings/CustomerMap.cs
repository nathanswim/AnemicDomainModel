using FluentNHibernate.Mapping;
using Logic.Entities;
using System;

namespace Logic.Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);

            Map(x => x.Name).CustomType<string>().Access.CamelCaseField(Prefix.Underscore);
            Map(x => x.Email).CustomType<string>().Access.CamelCaseField(Prefix.Underscore);
            //Map(x => x.Status).CustomType<int>();
            //Map(x => x.StatusExpirationDate).CustomType<DateTime?>().Access.CamelCaseField(Prefix.Underscore).Nullable();
            Map(x => x.MoneySpent).CustomType<decimal>().Access.CamelCaseField(Prefix.Underscore);

            Component(x => x.Status, y =>
            {
                y.Map(x => x.Type, "Status").CustomType<int>();
                y.Map(x => x.ExpirationDate, "StatusExpirationDate")
                    .CustomType<DateTime?>()
                    .Access.CamelCaseField(Prefix.Underscore)
                    .Nullable();
            });

            HasMany(x => x.PurchasedMovies).Access.CamelCaseField(Prefix.Underscore);
        }
    }
}
