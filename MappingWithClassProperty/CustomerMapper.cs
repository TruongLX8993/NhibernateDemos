using FluentNHibernate.Mapping;
using NHibernate.Mapping;

namespace MappingWithClassProperty;

public class CustomerMapper : ClassMap<Customer>
{
    public CustomerMapper()
    {
        Id(cus => cus.Id);
        Map(cus => cus.Name);
        Component(c => c.Address, c =>
        {
            c.Map(c => c.City, "City");
            c.Map(c => c.Street, "Street");
        });
    }
}