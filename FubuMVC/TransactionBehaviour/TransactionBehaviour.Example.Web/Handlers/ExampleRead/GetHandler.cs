using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TransactionBehaviour.Example.Web.Entities;

namespace TransactionBehaviour.Example.Web.Handlers.ExampleRead
{
    public class GetHandler
    {
        private readonly ISession session;

        public GetHandler(ISession session)
        {
            this.session = session;
        }

        public ViewModel Execute(GetInputModel inputModel)
        {
            var message = string.Format("There are {0} customers in the system.", session.Query<Customer>().Count());
            return new ViewModel { Message = message };
        }
    }

}