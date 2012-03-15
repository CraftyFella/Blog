using System;
using System.Linq;

namespace TransactionBehaviour.Example.Web.Behaviour
{
    public static class TypeExtensions
    {
        public static bool HasInjected<T>(this Type type)
        {
            return
                type
                    .GetConstructors()
                    .Any(x => x.GetParameters()
                                  .Any(y => y.ParameterType.IsAssignableFrom(typeof (T))));
        }
    }
}