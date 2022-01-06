namespace UsingMultipleInterfaces.Services
{
    using System.Collections.Generic;

    public interface IInterfaceService
    {
        public IEnumerable<string?>? GetInterfaceVersions(string path);
    }
}
