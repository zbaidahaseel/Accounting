using Autofac;
using System.Reflection;

namespace Accounting_Api.AutoFac
{
    public class AutoFacBootStrapper
    {
        protected List<string> MainNamespace = new List<string> { "Accounting_Business" };

        protected readonly List<string> _supportedAutoRegisteredTypes = new List<string> { "Manager", "Service", "Mapper", "Validator" };

        private readonly ContainerBuilder _builder;

        public AutoFacBootStrapper(ContainerBuilder builder)
        {
            _builder = builder;
        }

        public void RegisterDependencies()
        {
            Assembly assembly2 = GetType().Assembly;
            IEnumerable<Assembly> source = (from assembly in assembly2.GetReferencedAssemblies()
                                            where MainNamespace.Any((string mainNamespace) => assembly.FullName.StartsWith(mainNamespace))
                                            select assembly).Select(Assembly.Load);
            Assembly[] assemblies = source.Append(assembly2).Distinct().ToArray();
            _builder.RegisterAssemblyTypes(assemblies).Where(delegate (Type t)
            {
                Type t2 = t;
                return _supportedAutoRegisteredTypes.Any((string a) => t2.Name.EndsWith(a));
            }).AsImplementedInterfaces()
                .AsSelf()
                .InstancePerLifetimeScope();
            RegisterCustomImplementations(_builder);
        }

        protected virtual void RegisterCustomImplementations(ContainerBuilder builder)
        {
        }

        public ContainerBuilder GetBuilder()
        {
            RegisterDependencies();
            return _builder;
        }
    }
}
