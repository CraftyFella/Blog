using NSubstitute;
using NUnit.Framework;

namespace TransactionBehaviour.Example.Web.Tests.Behaviour
{
    class When_invoking_transaction_behaviour_and_inner_behaviour_doesnt_error : SpecificationForTransactionBehaviour
    {
        [Test]
        public void Then_transaction_should_be_commited()
        {
            Transaction.Received().Commit();
        }
    }
}