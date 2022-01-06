namespace UsingMultipleInterfaces.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class InterfaceService : IInterfaceService
    {
        public IEnumerable<string?>? GetInterfaceVersions(string path)
        {
            IEnumerable<string?>? namespaces = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Namespace.StartsWith(path))
                .Select(t => t.Namespace.Replace(path, "").Replace("_", ""))
                .OrderBy(t => t)
                .Distinct();
            return namespaces;
        }
    }
}
