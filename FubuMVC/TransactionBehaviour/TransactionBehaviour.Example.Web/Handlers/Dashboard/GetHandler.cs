namespace TransactionBehaviour.Example.Web.Handlers.Dashboard
{
    public class GetHandler
    {
        public ViewModel Execute(GetInputModel inputModel)
        {
            return new ViewModel {Message = "Hello World"};
        
        }
    }

}