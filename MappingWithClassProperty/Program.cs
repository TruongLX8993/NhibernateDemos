using Newtonsoft.Json;
using Shared;

namespace MappingWithClassProperty;

public static class Program
{
    public static void Main(string[] args)
    {
        var connectionString =
            "data source=103.74.123.8;initial catalog=rwtfgrxz_motor;user id=rwtfgrxz_sa;password=Motor@123;MultipleActiveResultSets=True;";
        var nhibernateSessionFactory = new NhibernateSessionFactory(connectionString, typeof(Program).Assembly);
        var session = nhibernateSessionFactory.Create();
        var res = session.Query<Customer>()
            .Where(cus => cus.Name == "truonglx")
            .ToList();
        Console.WriteLine(JsonConvert.SerializeObject(res));
    }
}