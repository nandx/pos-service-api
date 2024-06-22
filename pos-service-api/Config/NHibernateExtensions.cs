using FluentNHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace pos_service_api.Config
{
    public static class NHibernateExtensions
    {
        public static IServiceCollection AddNHibernate(this IServiceCollection services, string connectionString)
        {
            var mapper = new ModelMapper();
            var assembly = typeof(Models.IEntity).Assembly; // All entities implements IEntity interface, and saved in Entity Assembly
            mapper.AddMappings(assembly.ExportedTypes);

            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            var configuration = new Configuration();
            configuration.DataBaseIntegration(c =>
            {
                c.Dialect<MsSql2012Dialect>();
                c.Driver<MicrosoftDataSqlClientDriver>();
                c.ConnectionString = connectionString;
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = false;
            });

            configuration.AddMapping(domainMapping);

            var persistenceModel = new PersistenceModel();
            persistenceModel.AddMappingsFromAssembly(assembly);
            persistenceModel.Configure(configuration);

            var sessionFactory = configuration.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());
            services.AddScoped(factory => sessionFactory.OpenStatelessSession());

            return services;
        }
    }
}
