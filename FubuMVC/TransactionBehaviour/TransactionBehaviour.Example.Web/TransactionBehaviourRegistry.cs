using System;
using System.IO;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using StructureMap;
using StructureMap.Configuration.DSL;
using TransactionBehaviour.Example.Web.Entities;

namespace TransactionBehaviour.Example.Web
{
    public class TransactionBehaviourRegistry: Registry
    {
        private const string DbName = @"c:\temp\example.db";

        public TransactionBehaviourRegistry()
        {
            ForSingletonOf<ISessionFactory>().Use(CreateSessionFactory);
            For<ISession>().HttpContextScoped().Use(x => x.GetInstance<ISessionFactory>().OpenSession());
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                 .Database(
                     SQLiteConfiguration.Standard
                         .UsingFile(DbName)
                 )
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                 .ExposeConfiguration(BuildSchema)
                 .BuildSessionFactory();
        }

        private void BuildSchema(Configuration config)
        {
            // Only create once
            if (File.Exists(DbName))
              return;

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            //new SchemaExport(config).Execute(true, true, true, ObjectFactory.Container.GetInstance<ISession>().Connection, Console.Out); 
            new SchemaExport(config)
                .Create(false, true);
        }
    }
}