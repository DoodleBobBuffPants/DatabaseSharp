namespace Core.Api.Exceptions;

public class NoDatabaseFoundException : Exception
{
    public NoDatabaseFoundException(Configuration configuration) : base($"No database found for the provided configuration:{Environment.NewLine}{configuration}") { }
}
