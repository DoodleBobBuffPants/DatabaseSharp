namespace Core.Api.Exceptions;

public class NoParameterFoundException : Exception
{
    public NoParameterFoundException(string parameter) : base($"Parameter '{parameter}' is not configured") { }
}
