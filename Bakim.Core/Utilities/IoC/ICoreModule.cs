using Microsoft.Extensions.DependencyInjection;

namespace Bakim.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
