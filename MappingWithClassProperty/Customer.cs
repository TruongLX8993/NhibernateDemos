namespace MappingWithClassProperty;

public class Customer
{
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual Address Address { get; set; }
}