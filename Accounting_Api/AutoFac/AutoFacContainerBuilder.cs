using Autofac;

namespace Accounting_Api.AutoFac
{
    public class AutoFacContainerBuilder : AutoFacBootStrapper
    {
        public AutoFacContainerBuilder(ContainerBuilder builder) : base(builder)
        {
        }
    }
}
