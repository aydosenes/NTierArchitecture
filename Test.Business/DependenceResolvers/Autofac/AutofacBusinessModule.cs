using Test.Business.DependenceResolvers.Autofac;
using Microsoft.AspNetCore.Http;
using Autofac;
using Test.Data.Repositories;
using Test.Core.Repositories;
using Test.Business.Managers;
using Test.Core.Services;

namespace Test.Business.DependenceResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        //protected override void Load(ContainerBuilder builder)
        //{
        //    builder.RegisterType<TestRepositoryDal>().As<ITestRepositoryDal>();
        //    builder.RegisterType<TestManager>().As<ITestService>();


        //}
    }
}
