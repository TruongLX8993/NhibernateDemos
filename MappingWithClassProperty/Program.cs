using Newtonsoft.Json;
using Shared;

namespace MappingWithClassProperty;

public static class Program
{
    public static void Main(string[] args)
    {
        var connectionString =
            "";
        var nhibernateSessionFactory = new NhibernateSessionFactory(connectionString, typeof(Program).Assembly);
        var session = nhibernateSessionFactory.Create();
        var res = session.Query<Customer>()
            .Where(cus => cus.Name == "truonglx")
            .ToList();
        Console.WriteLine(JsonConvert.SerializeObject(res));
    }
}
