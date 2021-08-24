using Autofac;
using LinksoftStudy.Common.Interfaces;
using LinksoftStudy.Common.Services;
using LinksoftStudy.Data;
using LinksoftStudy.Data.Interfaces;
using LinksoftStudy.Data.Repositories;
using LinksoftStudy.Services.Interfaces;
using LinksoftStudy.Services.Services;
using LinksoftStudy.Web.AutoMapper;
using LinksoftStudy.Web.Interfaces;
using LinksoftStudy.Web.Processors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LinksoftStudy.Web.IoC
{
    public class LinksoftStudyModule : Module
    {
        private readonly IConfiguration configuration;

        public LinksoftStudyModule(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            // automapper
            builder.Register(context => AutoMapperConfig.Initialize()).AsSelf().SingleInstance();

            // common services
            builder.RegisterType<InputDataService>().As<IInputDataService>();

            // services
            builder.RegisterType<PersonService>().As<IPersonService>();

            // processors
            builder.RegisterType<InputDataProcessor>().As<IInputDataProcessor>();
            builder.RegisterType<PersonProcessor>().As<IPersonProcessor>();

            // repositories
            builder.RegisterType<PersonRepository>().As<IPersonRepository>().InstancePerLifetimeScope();

            // Database
            builder.Register(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<Context>();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("LinksoftStudyDatabase"));
                return new Context(optionsBuilder.Options);
            }).InstancePerLifetimeScope();
        }
    }
}
