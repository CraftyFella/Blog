using System.Collections.Generic;
using System.Data;
using System.Linq;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;
using NHibernate;

namespace TransactionBehaviour.Example.Web.Behaviour
{
    public class TransactionBehaviour : IActionBehavior
    {
        private readonly ISession session;
        public IActionBehavior InnerBehavior { get; set; }

        public TransactionBehaviour(ISession session)
        {
            this.session = session;
        }

        public void Invoke()
        {
            using (var transaction = session.BeginTransaction())
            {
                InnerBehavior.Invoke();
                transaction.Commit();
            }
        }

        public void InvokePartial()
        {
            Invoke();
        }
    }

    public class TransactionBehaviourConfiguration : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            graph.Actions()
                .Where(x => x.HandlerType.HasInjected<ISession>())
                .Each(x => x.AddBefore(new Wrapper(typeof(TransactionBehaviour))));
        }
    }
}