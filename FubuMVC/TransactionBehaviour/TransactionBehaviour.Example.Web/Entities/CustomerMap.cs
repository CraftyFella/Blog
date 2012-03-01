using FluentNHibernate.Mapping;

namespace TransactionBehaviour.Example.Web.Entities
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Name);
        }
    }
}