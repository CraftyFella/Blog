using System;
using NSubstitute;
using NUnit.Framework;

namespace TransactionBehaviour.Example.Web.Tests.Behaviour
{
    class When_invoking_transaction_behaviour_and_inner_behaviour_errors : SpecificationForTransactionBehaviour
    {

        protected override void SetupDependencies()
        {
            base.SetupDependencies();
            InnerBahaviour.When(x=> x.Invoke()).Do(x => { throw new Exception("Boom!"); });
        }
        protected override void Because()
        {
            try { base.Because();} catch(Exception) { }
        }

        [Test]
        public void Then_transaction_should_not_be_commited()
        {
            Transaction.DidNotReceive().Commit();
        }
    }
}