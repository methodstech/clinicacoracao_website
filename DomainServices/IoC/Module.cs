// ----------------------------------------------------------------------------
// DomainServices.Module.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using DomainServices.Interfaces;
using DomainServices.Services;
using Ninject;

namespace DomainServices.IoC
{
    public static class Module
    {
        public static void ConfigureKernel(IKernel kernel)
        {
            kernel.Bind<IUsuarioDomainService>().To<UsuarioDomainService>();
            kernel.Bind<IRitmoDomainService>().To<RitmoDomainService>();
            kernel.Bind<IMedicoDomainService>().To<MedicoDomainService>();
            kernel.Bind<IConclusaoDomainService>().To<ConclusaoDomainService>();
            kernel.Bind<IConvenioDomainService>().To<ConvenioDomainService>();
            kernel.Bind<IPacienteDomainService>().To<PacienteDomainService>();
            kernel.Bind<ILaudoDomainService>().To<LaudoDomainService>();
            kernel.Bind<IRelatorioDomainService>().To<RelatorioDomainService>();
            kernel.Bind<IBlogPostDomainService>().To<BlogPostDomainService>();
        }
    }
}
