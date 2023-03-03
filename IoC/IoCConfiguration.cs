using Ninject;

namespace IoC
{
    public static class IoCConfiguration
    {
        public static void ConfigureKernel(IKernel kernel)
        {
            DomainServices.IoC.Module.ConfigureKernel(kernel);
            Data.IoC.Module.ConfigureKernel(kernel);
            AppServices.IoC.Module.ConfigureKernel(kernel);
        }
    }
}
