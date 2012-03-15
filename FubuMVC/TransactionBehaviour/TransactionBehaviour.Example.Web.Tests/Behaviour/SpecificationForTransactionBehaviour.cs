using System.Data;
using FubuMVC.Core.Behaviors;
using NHibernate;
using NSubstitute;
using NUnit.Framework;

namespace TransactionBehaviour.Example.Web.Tests.Behaviour
{
    abstract class SpecificationForTransactionBehaviour : SpecificationFor<Web.Behaviour.TransactionBehaviour>
    {
        protected IActionBehavior InnerBahaviour;
        protected ISession Session;
        protected ITransaction Transaction;

        protected override Web.Behaviour.TransactionBehaviour CreateClassUnderTest()
        {
            return new Web.Behaviour.TransactionBehaviour(Session) {InnerBehavior = InnerBahaviour};
        }

        protected override void SetupDependencies()
        {
            InnerBahaviour = Substitute.For<IActionBehavior>();
            Session = Substitute.For<ISession>();
            Transaction = Substitute.For<ITransaction>();
            Session.BeginTransaction().Returns(Transaction);
        }

        protected override void Because()
        {
            ClassUnderTest.Invoke();
        }

        [Test]
        public void Then_inner_behaviour_should_be_invoked()
        {
            InnerBahaviour.Received().Invoke();
        }

        [Test]
        public void Then_transaction_should_be_created()
        {
            Session.Received().BeginTransaction();
        }

        [Test]
        public void Then_transaction_is_disposed()
        {
            Transaction.Received().Dispose();
        }
    }
}