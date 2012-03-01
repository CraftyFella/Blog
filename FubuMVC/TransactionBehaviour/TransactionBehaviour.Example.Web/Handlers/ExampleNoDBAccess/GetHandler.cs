using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using TransactionBehaviour.Example.Web.Entities;

namespace TransactionBehaviour.Example.Web.Handlers.ExampleNoDBAccess
{
    public class GetHandler
    {
        public ViewModel Execute(GetInputModel inputModel)
        {
            return new ViewModel { Message = "Does have access to ISession" };
        }
    }

}