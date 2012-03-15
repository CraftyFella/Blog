using FubuMVC.Core;
using FubuMVC.Spark;
using TransactionBehaviour.Example.Web.Handlers;
using TransactionBehaviour.Example.Web.Handlers.Dashboard;

namespace TransactionBehaviour.Example.Web.Behaviour
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            // This line turns on the basic diagnostics and request tracing
            IncludeDiagnostics(true);

            Routes.
             HomeIs<GetInputModel>();

            // Match views to action methods by matching
            // on model type, view name, and namespace
            Views.TryToAttachWithDefaultConventions();

            ApplyHandlerConventions(typeof(HandlersMaker));
            ApplyConvention<TransactionBehaviourConfiguration>();
            this.UseSpark();


        }
    }
}