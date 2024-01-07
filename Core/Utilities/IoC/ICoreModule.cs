using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //Core katmanında bağımlılıklarımı bağlayabilceğim bir interface oluşturdum 
        void Load(IServiceCollection serviceCollection);
    }
}
