// ----------------------------------------------------------------------------
// Data.Module.cs
// Created by Paulo Gemniczak on 11/05/2018
// Copyright © 2018 Method's Informática LTDA.
// All rights reserved.
// ----------------------------------------------------------------------------

using Data.Repositories;
using Domain.Repositories;
using Ninject;

namespace Data.IoC
{
    public static class Module
    {
        public static void ConfigureKernel(IKernel kernel)
        {
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            kernel.Bind<IRitmoRepository>().To<RitmoRepository>();
            kernel.Bind<IMedicoRepository>().To<MedicoRepository>();
            kernel.Bind<IConclusaoRepository>().To<ConclusaoRepository>();
            kernel.Bind<IConvenioRepository>().To<ConvenioRepository>();
            kernel.Bind<IPacienteRepository>().To<PacienteRepository>();
            kernel.Bind<ILaudoRepository>().To<LaudoRepository>();
            kernel.Bind<IRelatorioRepository>().To<RelatorioRepository>();
            kernel.Bind<IBlogPostRepository>().To<BlogPostRepository>();
        }
    }
}
