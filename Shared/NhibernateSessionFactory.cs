using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
namespace Shared;

public class NhibernateSessionFactory
{
    private readonly ISessionFactory _factory;

    public NhibernateSessionFactory(string connectionString,
        Assembly mappingAssembly)
    {
        _factory = CreateSessionFactory(connectionString, mappingAssembly);
    }

    public ISession Create()
    {
        return _factory.OpenSession();
    }

    public IStatelessSession OpenStateLessSession()
    {
        return _factory.OpenStatelessSession();
    }
        
    private static ISessionFactory CreateSessionFactory(
        string connectionString,
        Assembly assembly)
    {
        var cfg = MsSqlConfiguration.MsSql2012
            .ConnectionString(c =>
                c.Is(connectionString));

        return Fluently.Configure()
            .Database(
                cfg
            )
            .Mappings(m => m.FluentMappings
                .AddFromAssembly(assembly))
            .BuildSessionFactory();
    }

    public void Close()
    {
        _factory.CloseAsync();
    }

    public void Dispose()
    {
        _factory?.Close();
    }
}