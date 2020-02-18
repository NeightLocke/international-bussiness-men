using InternationalBusinessServiceLibrary.Unity;
using Microsoft.Practices.Unity;
using Unity.Wcf;

namespace InternationalBusinessService.Unity
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            ConfigureUnity.Configure(container);
        }
    }
}