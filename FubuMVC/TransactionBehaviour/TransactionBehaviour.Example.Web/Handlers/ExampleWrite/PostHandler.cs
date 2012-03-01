using System.Linq;
using FubuMVC.Core.Continuations;
using NHibernate;
using NHibernate.Linq;
using TransactionBehaviour.Example.Web.Entities;

namespace TransactionBehaviour.Example.Web.Handlers.ExampleWrite
{
    public class PostHandler
    {
        private readonly ISession session;

        public PostHandler(ISession session)
        {
            this.session = session;
        }

        public FubuContinuation Execute(PostInputModel inputModel)
        {
            using (var tran = session.BeginTransaction())
            {
                var customer = new Customer {Name = inputModel.Name};
                session.Save(customer);
                tran.Commit();
            }

            return FubuContinuation.RedirectTo(new GetInputModel());
        }
    }

}