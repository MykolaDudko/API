namespace ClassLibrary.Exceptions;

public class ObjectNotFoundException : Exception
{
    public ObjectNotFoundException() : base("Object has not been found")
    {

    }
    public ObjectNotFoundException(string exception) : base(exception)
    {

    }
}
