// ----------------------------------------------------------------------------
// AppServices.Module.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using AppServices.Interfaces;
using AppServices.Service;
using Ninject;

namespace AppServices.IoC
{
    public static class Module
    {
        public static void ConfigureKernel(IKernel kernel)
        {
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
            kernel.Bind<IRitmoAppService>().To<RitmoAppService>();
            kernel.Bind<IMedicoAppService>().To<MedicoAppService>();
            kernel.Bind<IConclusaoAppService>().To<ConclusaoAppService>();
            kernel.Bind<IConvenioAppService>().To<ConvenioAppService>();
            kernel.Bind<IPacienteAppService>().To<PacienteAppService>();
            kernel.Bind<ILaudoAppService>().To<LaudoAppService>();
            kernel.Bind<IRelatorioAppService>().To<RelatorioAppService>();
            kernel.Bind<IBlogPostAppService>().To<BlogPostAppService>();
        }
    }
}
